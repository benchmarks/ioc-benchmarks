using CommonServiceLocator;
using IoC.Adapter;

namespace IoC.Benchmarks.Tests
{
    public class Benchmark_01_Tests
    {
        [Fact]
        public void Baseline()
        { 
            var benchmark = new Benchmark_01_Singleton();

            // Validate
            Assert.Null(benchmark.Adapter);
            Assert.Null(benchmark.Container);
            Assert.Null(benchmark.ServiceLocator);
            Assert.True(0 == benchmark.Registrations.Count());
        }

        [Theory]
        [MemberData(nameof(AdapterInfoSource))]
        public void ContainerCreatedSingleton(AdapterInfo info)
        {
            // Setup
            var benchmark = new Benchmark_01_Singleton
            {
                Container = info
            };
            benchmark.IterationSetup();

            // Act
            var result = benchmark.ContainerCreatedSingleton();

            // Validate
            Assert.NotNull(result[0]);
            Assert.NotNull(result[1]);
            Assert.NotNull(result[2]);
            Assert.NotNull(result[3]);
            Assert.NotNull(result[4]);

            Assert.IsType(benchmark.Registrations[0].ContractType, result[0]);
            Assert.IsType(benchmark.Registrations[1].ContractType, result[1]);
            Assert.IsType(benchmark.Registrations[2].ContractType, result[2]);
            Assert.IsType(benchmark.Registrations[3].ContractType, result[3]);
            Assert.IsType(benchmark.Registrations[4].ContractType, result[4]);

            Assert.Equivalent(nameof(Singleton0), result[0].GetType().Name);
            Assert.Equivalent(nameof(Singleton1), result[1].GetType().Name);
            Assert.Equivalent(nameof(Singleton2), result[2].GetType().Name);
            Assert.Equivalent(nameof(Singleton3), result[3].GetType().Name);
            Assert.Equivalent(nameof(Singleton4), result[4].GetType().Name);

            Assert.Same(result[0], benchmark.ServiceLocator.GetInstance(benchmark.Registrations[0].ContractType));
            Assert.Same(result[1], benchmark.ServiceLocator.GetInstance(benchmark.Registrations[1].ContractType));
            Assert.Same(result[2], benchmark.ServiceLocator.GetInstance(benchmark.Registrations[2].ContractType));
            Assert.Same(result[3], benchmark.ServiceLocator.GetInstance(benchmark.Registrations[3].ContractType));
            Assert.Same(result[4], benchmark.ServiceLocator.GetInstance(benchmark.Registrations[4].ContractType));
        }



        [Theory]
        [MemberData(nameof(AdapterInfoSource))]
        public void ContainerCreatedSingletonService(AdapterInfo info)
        {
            // Setup
            var benchmark = new Benchmark_01_Singleton
            {
                Container = info
            };
            benchmark.IterationSetup();

            // Act
            var result = benchmark.ContainerCreatedSingletonService();

            // Validate
            Assert.NotNull(result[0]);
            Assert.NotNull(result[1]);
            Assert.NotNull(result[2]);
            Assert.NotNull(result[3]);
            Assert.NotNull(result[4]);

            Assert.IsType(info.GetType(nameof(SingletonService0))!, result[0]);
            Assert.IsType(info.GetType(nameof(SingletonService1))!, result[1]);
            Assert.IsType(info.GetType(nameof(SingletonService2))!, result[2]);
            Assert.IsType(info.GetType(nameof(SingletonService3))!, result[3]);
            Assert.IsType(info.GetType(nameof(SingletonService4))!, result[4]);

            Assert.Equivalent(nameof(SingletonService0), result[0].GetType().Name);
            Assert.Equivalent(nameof(SingletonService1), result[1].GetType().Name);
            Assert.Equivalent(nameof(SingletonService2), result[2].GetType().Name);
            Assert.Equivalent(nameof(SingletonService3), result[3].GetType().Name);
            Assert.Equivalent(nameof(SingletonService4), result[4].GetType().Name);

            Assert.Same(result[0], benchmark.ServiceLocator.GetInstance(benchmark.Registrations[5].ContractType));
            Assert.Same(result[1], benchmark.ServiceLocator.GetInstance(benchmark.Registrations[6].ContractType));
            Assert.Same(result[2], benchmark.ServiceLocator.GetInstance(benchmark.Registrations[7].ContractType));
            Assert.Same(result[3], benchmark.ServiceLocator.GetInstance(benchmark.Registrations[8].ContractType));
            Assert.Same(result[4], benchmark.ServiceLocator.GetInstance(benchmark.Registrations[9].ContractType));
        }

        [Theory]
        [MemberData(nameof(ExternalSingletonSource))]
        public void ExternallyCreatedSingleton(AdapterInfo info, AdapterBase adapter)
        {
            // Setup
            var benchmark = new Benchmark_01_Singleton
            {
                Container = info,
                Adapter = adapter
            };

            benchmark.IterationSetup();

            // Act
            var result = benchmark.ExternallyCreatedSingleton();

            // Validate
            Assert.NotNull(result[0]);
            Assert.NotNull(result[1]);

            Assert.IsAssignableFrom<IServiceLocator>(result[0]);
            Assert.IsAssignableFrom<IServiceProvider>(result[1]);
        }

        #region Test Data

        public static IEnumerable<object[]> AdapterInfoSource
        {
            get
            {
                foreach (var adapter in AdapterBase.GetAdapters())
                {
                    yield return new object[] { adapter };
                }
            }
        }


        public static IEnumerable<object[]> ExternalSingletonSource
        {
            get
            {
                foreach (var info in AdapterBase.GetAdapters())
                {
                    var adapter = info.GetAdapter();
                    if (!adapter.SupportsExternal) continue;

                    yield return new object[] { info, adapter };
                }
            }
        }

        #endregion
    }
}
