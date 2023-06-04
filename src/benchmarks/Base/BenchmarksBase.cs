using BenchmarkDotNet.Attributes;
using CommonServiceLocator;
using IoC.Adapter;

namespace IoC.Benchmarks
{
    public abstract class BenchmarksBase
    {
        #region Fields

        /// <summary>
        /// Current container adapter 
        /// </summary>
        public AdapterBase Adapter;


        /// <summary>
        /// Service locator exposed by the built container
        /// </summary>
        public IServiceLocator ServiceLocator;


        /// <summary>
        /// List of registrations required for current benchmark
        /// </summary>
        public RegistrationDescriptor[] Registrations = Array.Empty<RegistrationDescriptor>();


        /// <summary>
        /// Current adapter info being benchmarked
        /// </summary>
        [ParamsSource(nameof(AdapterInfoSource))]
        public AdapterInfo Container;

        #endregion


        #region Setup

        [IterationSetup]
        public virtual void IterationSetup()
        {
            Adapter ??= (Container?.GetAdapter()) ?? throw new ArgumentNullException(nameof(Container));            
            ServiceLocator ??= Adapter.GetServiceLocator(Registrations);
        }

        [IterationCleanup]
        public virtual void IterationCleanup()
        {
            // Each iteration requires a new adapter and service locator
            Adapter = null;
            ServiceLocator = null;
        }

        #endregion


        #region Adapters Source

        public virtual IEnumerable<AdapterInfo> AdapterInfoSource() 
            => AdapterBase.GetAdapters();
        
        #endregion
    }
}
