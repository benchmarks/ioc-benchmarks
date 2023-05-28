using System;

namespace IoC.Adapter
{
    public abstract partial class ContainerAdapter
    {
        static public partial IEnumerable<AdapterInfo> GetAdapters();
    }
}
