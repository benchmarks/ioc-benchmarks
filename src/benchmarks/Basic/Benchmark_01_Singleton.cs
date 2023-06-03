using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Order;
using CommonServiceLocator;

namespace IoC.Benchmarks
{
    /// <summary>
    /// This benchmarks measures speed of retrieving the Container/Service Provider 
    /// itself.
    /// </summary>
    [BenchmarkCategory("basic", "singleton")]
    [Orderer(SummaryOrderPolicy.Method)]
    public class Benchmark_01_Singleton : BenchmarksBase
    {
        #region Fields

        readonly object[] _values = new object[2];

        #endregion


        #region Setup

        [GlobalSetup]
        public void Setup()
        { 
        }

        #endregion


        #region Benchmarks


        /// <summary>
        /// Resolve registered with container singleton instance
        /// </summary>
        [Benchmark(Description = "Singleton registered with container", OperationsPerInvoke = 2)]
        public object ExternallyCreatedSingleton()
        {
            _values[0] = ServiceLocator.GetInstance(typeof(IServiceProvider));
            _values[0] = ServiceLocator.GetInstance(typeof(IServiceLocator));

            return _values;
        }


        /// <summary>
        /// Resolve singleton instance created by the container
        /// </summary>
        [Benchmark(Description = "singleton created by the container", OperationsPerInvoke = 2)]
        public object ContainerCreatedSingleton()
        {
            _values[0] = ServiceLocator.GetInstance(typeof(IServiceLocator));
            _values[0] = ServiceLocator.GetInstance(typeof(IServiceLocator));

            return _values;
        }


        #endregion
    }
}
