﻿using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Order;
using CommonServiceLocator;
using IoC.Adapter;
using System;

namespace IoC.Benchmarks
{
    /// <summary>
    /// This benchmarks measures speed of retrieving the Container/Service Provider 
    /// itself.
    /// </summary>
    [InvocationCount(1, 1)]
    [BenchmarkCategory("basic", "singleton")]
    [Orderer(SummaryOrderPolicy.Method)]
    public class Benchmark_01_Singleton : BenchmarksBase
    {
        #region Fields

        readonly object[] _values = new object[5];

        #endregion


        #region Setup

        public override void IterationSetup()
        {
            Registrations = new[]
            {
                // Singletons, types exported directly

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

                // Singleton servicess, types exported by interface

                new RegistrationDescriptor(Container.GetType(nameof(IService0)))
                {
                    ImplementationType = Container.GetType(nameof(SingletonService0)),
                    Lifetime = RegistrationLifetime.Singleton
                },
                new RegistrationDescriptor(Container.GetType(nameof(IService1)))
                {
                    ImplementationType = Container.GetType(nameof(SingletonService1)),
                    Lifetime = RegistrationLifetime.Singleton
                },
                new RegistrationDescriptor(Container.GetType(nameof(IService2)))
                {
                    ImplementationType = Container.GetType(nameof(SingletonService2)),
                    Lifetime = RegistrationLifetime.Singleton
                },
                new RegistrationDescriptor(Container.GetType(nameof(IService3)))
                {
                    ImplementationType = Container.GetType(nameof(SingletonService3)),
                    Lifetime = RegistrationLifetime.Singleton
                },
                new RegistrationDescriptor(Container.GetType(nameof(IService4)))
                {
                    ImplementationType = Container.GetType(nameof(SingletonService4)),
                    Lifetime = RegistrationLifetime.Singleton
                },
            };

            base.IterationSetup();
        }


        #endregion


        #region Benchmarks


        /// <summary>
        /// Resolve singleton instance created by the container
        /// </summary>
        [Benchmark(Description = "Singleton created by the Container", OperationsPerInvoke = 5)]
        public object[] ContainerCreatedSingleton()
        {
            _values[0] = ServiceLocator.GetInstance(Registrations[0].ContractType);
            _values[1] = ServiceLocator.GetInstance(Registrations[1].ContractType);
            _values[2] = ServiceLocator.GetInstance(Registrations[2].ContractType);
            _values[3] = ServiceLocator.GetInstance(Registrations[3].ContractType);
            _values[4] = ServiceLocator.GetInstance(Registrations[4].ContractType);

            return _values;
        }



        /// <summary>
        /// Resolve singleton instance created by the container
        /// </summary>
        [Benchmark(Description = "Singleton  exoprted  by  interface", OperationsPerInvoke = 5)]
        public object[] ContainerCreatedSingletonService()
        {
            _values[0] = ServiceLocator.GetInstance(Registrations[5].ContractType);
            _values[1] = ServiceLocator.GetInstance(Registrations[6].ContractType);
            _values[2] = ServiceLocator.GetInstance(Registrations[7].ContractType);
            _values[3] = ServiceLocator.GetInstance(Registrations[8].ContractType);
            _values[4] = ServiceLocator.GetInstance(Registrations[9].ContractType);

            return _values;
        }

        /// <summary>
        /// Resolve registered with container singleton instance
        /// </summary>
        [Benchmark(Description = "External registered with Container", OperationsPerInvoke = 2)]
        public object[] ExternallyCreatedSingleton()
        {
            _values[0] = ServiceLocator.GetInstance(typeof(IServiceLocator));
            _values[1] = ServiceLocator.GetInstance(typeof(IServiceProvider));

            return _values;
        }


        #endregion
    }
}
