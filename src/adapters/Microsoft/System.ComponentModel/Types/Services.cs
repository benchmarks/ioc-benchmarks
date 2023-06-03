using System.ComponentModel.Composition;

namespace IoC.System.ComponentModel
{
    public interface IService { }

    [Export(typeof(IService))]
    public class Service : IService
    {
    }

    public interface IService0 { }

    [Export(typeof(IService0))]
    public class Service0 : IService0
    {
    }
    public interface IService1 { }

    [Export(typeof(IService1))]
    public class Service1 : IService1
    {
    }
    public interface IService2 { }

    [Export(typeof(IService2))]
    public class Service2 : IService2
    {
    }
    public interface IService3 { }

    [Export(typeof(IService3))]
    public class Service3 : IService3
    {
    }
    public interface IService4 { }

    [Export(typeof(IService4))]
    public class Service4 : IService4
    {
    }
}
