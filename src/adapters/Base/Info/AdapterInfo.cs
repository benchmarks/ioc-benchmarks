using System.Diagnostics;
using System.Reflection;

namespace IoC.Adapter
{
    [DebuggerDisplay($"{{Name,nq}}")]
    public class AdapterInfo
    {
        #region Fields

        Assembly? _assembly;
        Type? _adapter;
        
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
                var dir  = new DirectoryInfo(path);
                var condition = path.Contains("Release", StringComparison.OrdinalIgnoreCase)
                    ? "Release" 
                    : "Debug";
                do
                {
                    if (Directory.GetDirectories(dir.FullName).Any(d => Path.GetFileName(d) == Name))
                        break;

                    dir = dir.Parent;

                } while ( dir != dir.Root );

                Debug.Assert(dir != dir.Root);

                path = Path.Combine(dir.FullName, Name);

                var assemblies = Directory.EnumerateFiles(path, $"{Name}.dll", SearchOption.AllDirectories)
                                          .ToArray();
            
                var file = 1 == assemblies.Length
                         ? assemblies[0]
                         : assemblies.First(a => a.Contains(condition, StringComparison.OrdinalIgnoreCase));

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
