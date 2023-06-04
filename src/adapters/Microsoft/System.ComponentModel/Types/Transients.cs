using IoC.Adapter;
using System.ComponentModel.Composition;

namespace IoC.System.ComponentModel
{
    [Export, PartCreationPolicy(CreationPolicy.NonShared)]
    public class Transient0
    {
    }

    [Export, PartCreationPolicy(CreationPolicy.NonShared)]
    public class Transient1
    {
    }

    [Export, PartCreationPolicy(CreationPolicy.NonShared)]
    public class Transient2
    {
    }

    [Export, PartCreationPolicy(CreationPolicy.NonShared)]
    public class Transient3
    {
    }

    [Export, PartCreationPolicy(CreationPolicy.NonShared)]
    public class Transient4
    {
    }

    [Export(typeof(IService0)), PartCreationPolicy(CreationPolicy.NonShared)]
    public class TransientService0 : IService0
    {
    }
    [Export(typeof(IService1)), PartCreationPolicy(CreationPolicy.NonShared)]
    public class TransientService1 : IService1
    {
    }
    [Export(typeof(IService2)), PartCreationPolicy(CreationPolicy.NonShared)]
    public class TransientService2 : IService2
    {
    }
    [Export(typeof(IService3)), PartCreationPolicy(CreationPolicy.NonShared)]
    public class TransientService3 : IService3
    {
    }
    [Export(typeof(IService4)), PartCreationPolicy(CreationPolicy.NonShared)]
    public class TransientService4 : IService4
    {
    }

}
