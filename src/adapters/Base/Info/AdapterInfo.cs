using System.Diagnostics;

namespace IoC.Adapter
{
    [DebuggerDisplay($"{{Name,nq}}")]
    public class AdapterInfo
    {
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
            throw new NotImplementedException(); 
        }
    }

}
