using BenchmarkDotNet.Attributes;
using CommonServiceLocator;
using IoC.Adapter;

#nullable disable

namespace IoC.Benchmarks
{
    [InvocationCount(1, 1)]
    public abstract class BenchmarksBase
    {
        #region Fields

        /// <summary>
        /// ServiceProvider exposed by built container
        /// </summary>
        public AdapterBase Adapter;


        /// <summary>
        /// Service locator interface
        /// </summary>
        public IServiceLocator ServiceLocator;



        /// <summary>
        /// Current adapter being benchmarked
        /// </summary>
        [ParamsSource(nameof(AdapterInfoSource))]
        public AdapterInfo Container;

        #endregion


        #region Setup

        [IterationSetup]
        public virtual void IterationSetup()
        {
            Adapter = (Container?.GetAdapter()) ?? throw new ArgumentNullException(nameof(Container));
            ServiceLocator = Adapter.GetServiceLocator();
        }

        #endregion


        #region Adapters Source

        public virtual IEnumerable<AdapterInfo> AdapterInfoSource() 
            => AdapterBase.GetAdapters();
        
        #endregion
    }
}
