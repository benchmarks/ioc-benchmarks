using BenchmarkDotNet.Configs;
using BenchmarkDotNet.Jobs;
using BenchmarkDotNet.Running;

namespace ioc.Benchmarks
{
    class Program
    {
        static void Main(string[] args)
        {
            DefaultConfig.Instance
                .AddJob(Job.Default.AsDefault())
                .WithOptions(ConfigOptions.DisableOptimizationsValidator);

            BenchmarkSwitcher.FromAssemblies(new[] 
            {
                typeof(Program).Assembly,
            }).Run(args);
        }
    }
}
