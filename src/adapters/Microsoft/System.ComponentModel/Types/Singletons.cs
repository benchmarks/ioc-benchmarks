using IoC.Adapter;
using System.ComponentModel.Composition;

namespace IoC.System.ComponentModel
{
    [Export, PartCreationPolicy(CreationPolicy.Shared)]
    public class Singleton0
    {
    }

    [Export, PartCreationPolicy(CreationPolicy.Shared)]
    public class Singleton1
    {
    }

    [Export, PartCreationPolicy(CreationPolicy.Shared)]
    public class Singleton2
    {
    }

    [Export, PartCreationPolicy(CreationPolicy.Shared)]
    public class Singleton3
    {
    }

    [Export, PartCreationPolicy(CreationPolicy.Shared)]
    public class Singleton4
    {
    }

    [Export(typeof(IService0)), PartCreationPolicy(CreationPolicy.Shared)]
    public class SingletonService0 : IService0
    {
    }
    [Export(typeof(IService1)), PartCreationPolicy(CreationPolicy.Shared)]
    public class SingletonService1 : IService1
    {
    }
    [Export(typeof(IService2)), PartCreationPolicy(CreationPolicy.Shared)]
    public class SingletonService2 : IService2
    {
    }
    [Export(typeof(IService3)), PartCreationPolicy(CreationPolicy.Shared)]
    public class SingletonService3 : IService3
    {
    }
    [Export(typeof(IService4)), PartCreationPolicy(CreationPolicy.Shared)]
    public class SingletonService4 : IService4
    {
    }

}
