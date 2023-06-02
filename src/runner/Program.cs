using BenchmarkDotNet.Configs;
using BenchmarkDotNet.Running;
using IoC.Benchmarks;

namespace ioc.Benchmarks
{
    class Program
    {
        static void Main(string[] args)
        {
            BenchmarkSwitcher.FromAssemblies(new[] 
            {
                typeof(BenchmarksBase).Assembly,
#if DEBUG
            }).Run(args, new DebugInProcessConfig());
#else
            }).Run(args);
#endif
        }
    }
}
