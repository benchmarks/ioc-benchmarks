using IoC.Adapter;
using System.Composition;

namespace IoC.System.Composition
{
    [Export, Shared]
    public class Singleton0
    {
    }

    [Export, Shared]
    public class Singleton1
    {
    }

    [Export, Shared]
    public class Singleton2
    {
    }

    [Export, Shared]
    public class Singleton3
    {
    }

    [Export, Shared]
    public class Singleton4
    {
    }


    [Export(typeof(IService0)), Shared]
    public class SingletonService0 : IService0
    {
    }


    [Export(typeof(IService1)), Shared]
    public class SingletonService1 : IService1
    {
    }


    [Export(typeof(IService2)), Shared]
    public class SingletonService2 : IService2
    {
    }


    [Export(typeof(IService3)), Shared]
    public class SingletonService3 : IService3
    {
    }


    [Export(typeof(IService4)), Shared]
    public class SingletonService4 : IService4
    {
    }
}
