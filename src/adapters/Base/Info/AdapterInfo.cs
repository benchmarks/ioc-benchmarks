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


        #pragma warning disable CS8618

        public string Name { get; init; }

        public string Version { get; init; }

        public string PackageName { get; init; }

        public string Url { get; init; }

        public string Description { get; init; }

        public string TargetFramework { get; init; }

        #pragma warning restore CS8618

        public ContainerAdapter GetAdapter() 
        {
            if (_assembly is null)
            { 
                var path = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
                var directory  = new DirectoryInfo(path);
                var config = path.Contains(_release, StringComparison.OrdinalIgnoreCase)
                    ? _release 
                    : _debug;
                do
                {
                    if (Directory.GetDirectories(directory.FullName).Any(d => Path.GetFileName(d) == Name))
                        break;

                    directory = directory.Parent;

                } while ( directory != directory.Root );

                Debug.Assert(directory != directory.Root);

                var assemblies = Directory.EnumerateFiles(Path.Combine(directory.FullName, Name), 
                                                          $"{Name}.dll", SearchOption.AllDirectories)
                                          .ToArray();
            
                var file = 1 == assemblies.Length
                         ? assemblies[0]
                         : assemblies.First(a => a.Contains(config, StringComparison.OrdinalIgnoreCase));

                _assembly = Assembly.LoadFrom(file);
            }

            if (_adapter is null)
            {
                _adapter = _assembly.DefinedTypes
                                    .FirstOrDefault(t => typeof(ContainerAdapter).IsAssignableFrom(t));

                if (_adapter is null) 
                    throw new InvalidOperationException($"Assembly \"{_assembly.Location}\" does not implement any types derived from \"{nameof(ContainerAdapter)}\"");
            }

            return (ContainerAdapter)Activator.CreateInstance(_adapter); 
        }
    }

}
