using System.Composition;

namespace IoC.System.Composition
{
    [Export]
    public class Combined0
    {
        [ImportingConstructor]
        public Combined0(Singleton0 first, Transient0 second)
        {
            Singleton = first ?? throw new ArgumentNullException(nameof(first));
            Transient = second ?? throw new ArgumentNullException(nameof(second));
        }

        public Singleton0 Singleton { get; }

        public Transient0 Transient { get; }
    }


    [Export]
    public class Combined1
    {
        [ImportingConstructor]
        public Combined1(Singleton1 first, Transient1 second)
        {
            Singleton = first ?? throw new ArgumentNullException(nameof(first));
            Transient = second ?? throw new ArgumentNullException(nameof(second));
        }

        public Singleton1 Singleton { get; }

        public Transient1 Transient { get; }
    }


    [Export]
    public class Combined2
    {
        [ImportingConstructor]
        public Combined2(Singleton2 first, Transient2 second)
        {
            Singleton = first ?? throw new ArgumentNullException(nameof(first));
            Transient = second ?? throw new ArgumentNullException(nameof(second));
        }

        public Singleton2 Singleton { get; }

        public Transient2 Transient { get; }
    }


    [Export]
    public class Combined3
    {
        [ImportingConstructor]
        public Combined3(Singleton3 first, Transient3 second)
        {
            Singleton = first ?? throw new ArgumentNullException(nameof(first));
            Transient = second ?? throw new ArgumentNullException(nameof(second));
        }

        public Singleton3 Singleton { get; }

        public Transient3 Transient { get; }
    }


    [Export]
    public class Combined4
    {
        [ImportingConstructor]
        public Combined4(Singleton4 first, Transient4 second)
        {
            Singleton = first ?? throw new ArgumentNullException(nameof(first));
            Transient = second ?? throw new ArgumentNullException(nameof(second));
        }

        public Singleton4 Singleton { get; }

        public Transient4 Transient { get; }
    }
}
