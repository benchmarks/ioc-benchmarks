using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Order;

namespace IoC.Benchmarks
{
    /// <summary>
    /// This benchmarks measures speed of retrieving the Container/Service Provider 
    /// itself.
    /// </summary>
    [BenchmarkCategory("basic", "fail", "unregistered")]
    [Orderer(SummaryOrderPolicy.Method)]
    public class Benchmark_00_Unregistered : BenchmarksBase
    {

        /// <summary>
        /// Measure the time it takes to complete resolve of invalid/unresolvable type
        /// </summary>
        [Benchmark(Description = "Failed resolve")]
        public object GetUnresolvable()
        {
            return ServiceLocator.GetService(typeof(IUnresolvable));
        }


        /// <summary>
        /// Resolve an instance of unregistered object of typeof(object)
        /// </summary>
        /// <returns></returns>
        [Benchmark(Description = "Get unregistered typeof(object)")]
        public object GetUnregisteredObject()
        {
            return ServiceLocator.GetInstance(typeof(object));
        }


        #region Test Type

        private interface IUnresolvable { }

        #endregion
    }
}
