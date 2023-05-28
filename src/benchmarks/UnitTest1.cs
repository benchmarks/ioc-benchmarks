using BenchmarkDotNet.Attributes;
using IoC.Benchmarks;

namespace Adapter.Tests
{
    public class UnitTest1 : BenchmarksBase
    {
        [Benchmark]
        public void Test1()
        {
            for(int i = 0; i < 10; i++) { }
        }
    }
}