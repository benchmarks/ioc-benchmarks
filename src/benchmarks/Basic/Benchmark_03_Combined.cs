using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Order;
using IoC.Adapter;

namespace IoC.Benchmarks
{
    /// <summary>
    /// This benchmarks measures speed of retrieving the Container/Service Provider 
    /// itself.
    /// </summary>
    [BenchmarkCategory("basic", "transient")]
    [Orderer(SummaryOrderPolicy.Method)]
    public class Benchmark_03_Combined : BenchmarksBase
    {
        #region Fields

        readonly object[] _values = new object[5];

        #endregion


        #region Setup

        public override void IterationSetup()
        {
            Registrations = new[]
            {
                // Combined

                new RegistrationDescriptor(Container.GetType(nameof(Combined0)))
                {
                    Lifetime = RegistrationLifetime.Transient
                },
                new RegistrationDescriptor(Container.GetType(nameof(Combined1)))
                {
                    Lifetime = RegistrationLifetime.Transient
                },
                new RegistrationDescriptor(Container.GetType(nameof(Combined2)))
                {
                    Lifetime = RegistrationLifetime.Transient
                },
                new RegistrationDescriptor(Container.GetType(nameof(Combined3)))
                {
                    Lifetime = RegistrationLifetime.Transient
                },
                new RegistrationDescriptor(Container.GetType(nameof(Combined4)))
                {
                    Lifetime = RegistrationLifetime.Transient
                },

                // Singletons

                new RegistrationDescriptor(Container.GetType(nameof(Singleton0)))
                {
                    Lifetime = RegistrationLifetime.Singleton
                },
                new RegistrationDescriptor(Container.GetType(nameof(Singleton1)))
                {
                    Lifetime = RegistrationLifetime.Singleton
                },
                new RegistrationDescriptor(Container.GetType(nameof(Singleton2)))
                {
                    Lifetime = RegistrationLifetime.Singleton
                },
                new RegistrationDescriptor(Container.GetType(nameof(Singleton3)))
                {
                    Lifetime = RegistrationLifetime.Singleton
                },
                new RegistrationDescriptor(Container.GetType(nameof(Singleton4)))
                {
                    Lifetime = RegistrationLifetime.Singleton
                },

                // Transients

                new RegistrationDescriptor(Container.GetType(nameof(Transient0)))
                {
                    Lifetime = RegistrationLifetime.Transient
                },
                new RegistrationDescriptor(Container.GetType(nameof(Transient1)))
                {
                    Lifetime = RegistrationLifetime.Transient
                },
                new RegistrationDescriptor(Container.GetType(nameof(Transient2)))
                {
                    Lifetime = RegistrationLifetime.Transient
                },
                new RegistrationDescriptor(Container.GetType(nameof(Transient3)))
                {
                    Lifetime = RegistrationLifetime.Transient
                },
                new RegistrationDescriptor(Container.GetType(nameof(Transient4)))
                {
                    Lifetime = RegistrationLifetime.Transient
                },
            };

            base.IterationSetup();
        }


        #endregion


        #region Benchmarks


        /// <summary>
        /// Resolve Transient instance created by the container
        /// </summary>
        [Benchmark(Description = "Resolve<Combined>()", OperationsPerInvoke = 5)]
        public object[] TransientCombined()
        {
            _values[0] = ServiceLocator.GetInstance(Registrations[0].ContractType);
            _values[1] = ServiceLocator.GetInstance(Registrations[1].ContractType);
            _values[2] = ServiceLocator.GetInstance(Registrations[2].ContractType);
            _values[3] = ServiceLocator.GetInstance(Registrations[3].ContractType);
            _values[4] = ServiceLocator.GetInstance(Registrations[4].ContractType);

            return _values;
        }

        #endregion
    }
}
