using System.Diagnostics;
using System.Reflection;
using System.Xml.Linq;

namespace IoC.Adapter
{
    [DebuggerDisplay($"{{Name,nq}}")]
    public class AdapterInfo
    {
        #region Constants

        private const string _release = "Release";
        private const string _debug = "Debug";
        private const string _none = "None";  

        #endregion


        #region Fields

        private Type? _type;            // Type of the adapter
        private Assembly? _assembly;    // Assembly implementing the adapter

        #endregion


        #region Properties
        #pragma warning disable CS8618

        public string Name { get; init; }

        public string Version { get; init; }

        public string PackageId { get; init; }

        public string PackageName { get; init; }

        public string Url { get; init; }

        public string Description { get; init; }

        public string TargetFramework { get; init; }

#pragma warning restore CS8618
        #endregion


        #region Public Services


        public virtual Type? GetType(string name)
            => (_assembly ?? LoadAssembly()).DefinedTypes.FirstOrDefault(t => name.Equals(t.Name));

        /// <summary>
        /// Creates <see cref="RegistrationDescriptor"/>
        /// </summary>
        /// <param name="contractType"><see cref="Type"/> of the contract</param>
        /// <param name="contractName">Name of the contract</param>
        /// <param name="implementationType">Implementation <see cref="Type"/></param>
        /// <param name="lifetime">Lifetime of the registration</param>
        /// <returns><see cref="RegistrationDescriptor"/></returns>
        public virtual RegistrationDescriptor Registration(string contractType, 
                                                           string contractName,
                                                           string implementationType,
                                                           RegistrationLifetime lifetime)
        {
            if (_assembly is null) _assembly = LoadAssembly();

            var type = _assembly.DefinedTypes.First(t => contractType.Equals(t.Name));
            var implementation = implementationType is null 
                               ? null 
                               : _assembly.DefinedTypes.First(t => implementationType.Equals(t.Name));

            return new RegistrationDescriptor(type)
            {
                Lifetime = lifetime,
                ImplementationType = implementation
            };
        }

        public AdapterBase GetAdapter() 
        {
            if (_type is null)
            {
                _type = (_assembly ??= LoadAssembly()).DefinedTypes
                                                      .FirstOrDefault(t => typeof(AdapterBase).IsAssignableFrom(t));
                if (_type is null) 
                    throw new InvalidOperationException($"Assembly \"{_assembly.Location}\" does not implement any types derived from \"{nameof(AdapterBase)}\"");
            }

            return (AdapterBase)Activator.CreateInstance(_type, this)!; 
        }

        #endregion


        #region Implementation

        private Assembly LoadAssembly()
        {
            var path = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location)!;
            var directory = new DirectoryInfo(path);
            var config = path.Contains(_release, StringComparison.OrdinalIgnoreCase)
                ? _release
                : _debug;
            do
            {
                if (Directory.GetDirectories(directory.FullName).Any(d => Path.GetFileName(d) == Name))
                    break;

                directory = directory.Parent;

            } while (directory is not null && directory != directory.Root);

            Debug.Assert(directory is not null && directory != directory.Root,
                        "Directory Adapters has invalid project");

            var assemblies = Directory.EnumerateFiles(Path.Combine(directory.FullName, Name),
                                                      $"{Name}.dll", SearchOption.AllDirectories)
                                      .ToArray();

            var file = 1 == assemblies.Length
                     ? assemblies[0]
                     : assemblies.First(a => a.Contains(config, StringComparison.OrdinalIgnoreCase));
            
            return Assembly.LoadFrom(file);
        }

        public override string ToString()
        {
            var package = !PackageId.Equals(_none)
                ? PackageId
                : PackageName.Equals(_none)
                    ? Name : PackageName;

            return Version.Equals(_none)
                ? $"{package}"
                : $"{package} {Version}";
        }

        #endregion
    }

}
