using IoC.Adapter;
using System.Composition;

namespace IoC.VisualStudio.Composition
{
    [Export]
    public class Transient0
    {
    }

    [Export]
    public class Transient1
    {
    }

    [Export]
    public class Transient2
    {
    }

    [Export]
    public class Transient3
    {
    }

    [Export]
    public class Transient4
    {
    }


    [Export(typeof(IService0))]
    public class TransientService0 : IService0
    {
    }


    [Export(typeof(IService1))]
    public class TransientService1 : IService1
    {
    }


    [Export(typeof(IService2))]
    public class TransientService2 : IService2
    {
    }


    [Export(typeof(IService3))]
    public class TransientService3 : IService3
    {
    }


    [Export(typeof(IService4))]
    public class TransientService4 : IService4
    {
    }
}
