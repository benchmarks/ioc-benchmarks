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
    public class Benchmark_02_Transient : BenchmarksBase
    {
        #region Fields

        readonly object[] _values = new object[5];

        #endregion


        #region Setup

        public override void IterationSetup()
        {
            Registrations = new[]
            {
                // Transients, types exported directly

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

                // Transient servicess, types exported by interface

                new RegistrationDescriptor(Container.GetType(nameof(IService0)))
                {
                    ImplementationType = Container.GetType(nameof(TransientService0)),
                    Lifetime = RegistrationLifetime.Transient
                },
                new RegistrationDescriptor(Container.GetType(nameof(IService1)))
                {
                    ImplementationType = Container.GetType(nameof(TransientService1)),
                    Lifetime = RegistrationLifetime.Transient
                },
                new RegistrationDescriptor(Container.GetType(nameof(IService2)))
                {
                    ImplementationType = Container.GetType(nameof(TransientService2)),
                    Lifetime = RegistrationLifetime.Transient
                },
                new RegistrationDescriptor(Container.GetType(nameof(IService3)))
                {
                    ImplementationType = Container.GetType(nameof(TransientService3)),
                    Lifetime = RegistrationLifetime.Transient
                },
                new RegistrationDescriptor(Container.GetType(nameof(IService4)))
                {
                    ImplementationType = Container.GetType(nameof(TransientService4)),
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
        [Benchmark(Description = "Transient created by the Container", OperationsPerInvoke = 5)]
        public object[] ContainerCreatedTransient()
        {
            _values[0] = ServiceLocator.GetInstance(Registrations[0].ContractType);
            _values[1] = ServiceLocator.GetInstance(Registrations[1].ContractType);
            _values[2] = ServiceLocator.GetInstance(Registrations[2].ContractType);
            _values[3] = ServiceLocator.GetInstance(Registrations[3].ContractType);
            _values[4] = ServiceLocator.GetInstance(Registrations[4].ContractType);

            return _values;
        }



        /// <summary>
        /// Resolve Transient instance created by the container
        /// </summary>
        [Benchmark(Description = "Transient  exoprted  by  interface", OperationsPerInvoke = 5)]
        public object[] ContainerCreatedTransientService()
        {
            _values[0] = ServiceLocator.GetInstance(Registrations[5].ContractType);
            _values[1] = ServiceLocator.GetInstance(Registrations[6].ContractType);
            _values[2] = ServiceLocator.GetInstance(Registrations[7].ContractType);
            _values[3] = ServiceLocator.GetInstance(Registrations[8].ContractType);
            _values[4] = ServiceLocator.GetInstance(Registrations[9].ContractType);

            return _values;
        }

        #endregion
    }
}
