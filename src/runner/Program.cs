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
            }).Run(args);
        }
    }
}
