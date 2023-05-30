using System.Diagnostics;
using System.Reflection;

namespace IoC.Adapter
{
    [DebuggerDisplay($"{{Name,nq}}")]
    public class AdapterInfo
    {
        #region Constants

        private const string _release = "Release";
        private const string _debug = "Debug";

        #endregion


        #region Fields

        private Assembly? _assembly;
        private Type? _adapter;

        #endregion


        #region Properties
        #pragma warning disable CS8618

        public string Name { get; init; }

        public string Version { get; init; }

        public string PackageName { get; init; }

        public string Url { get; init; }

        public string Description { get; init; }

        public string TargetFramework { get; init; }

        #pragma warning restore CS8618
        #endregion


        #region Adapter

        public ContainerAdapter GetAdapter() 
        {
            if (_adapter is null)
            {
                _adapter = (_assembly ??= LoadAssembly()).DefinedTypes
                                                         .FirstOrDefault(t => typeof(ContainerAdapter).IsAssignableFrom(t));
                if (_adapter is null) 
                    throw new InvalidOperationException($"Assembly \"{_assembly.Location}\" does not implement any types derived from \"{nameof(ContainerAdapter)}\"");
            }

            return (ContainerAdapter)Activator.CreateInstance(_adapter); 
        }

        #endregion


        #region Implementation

        private Assembly LoadAssembly()
        {
            var path = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
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

        #endregion
    }

}
