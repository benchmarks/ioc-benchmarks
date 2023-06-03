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

            Assert.Same(result[0], benchmark.ServiceLocator.GetInstance(benchmark.Registrations[0].ContractType));
            Assert.Same(result[1], benchmark.ServiceLocator.GetInstance(benchmark.Registrations[1].ContractType));
            Assert.Same(result[2], benchmark.ServiceLocator.GetInstance(benchmark.Registrations[2].ContractType));
            Assert.Same(result[3], benchmark.ServiceLocator.GetInstance(benchmark.Registrations[3].ContractType));
            Assert.Same(result[4], benchmark.ServiceLocator.GetInstance(benchmark.Registrations[4].ContractType));
        }

        [Theory]
        [MemberData(nameof(AdapterInfoSource))]
        public void ExternallyCreatedSingleton(AdapterInfo info)
        {
            // Setup
            var benchmark = new Benchmark_01_Singleton
            {
                Container = info
            };
            benchmark.IterationSetup();

            // Act
            var result = benchmark.ExternallyCreatedSingleton();

            // Validate
            Assert.NotNull(result[0]);
            Assert.NotNull(result[1]);

            Assert.IsAssignableFrom<IServiceLocator>(result[0]);
            Assert.IsAssignableFrom<IServiceLocator>(result[1]);

            Assert.Same(result[0], result[1]);
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

        #endregion
    }
}
