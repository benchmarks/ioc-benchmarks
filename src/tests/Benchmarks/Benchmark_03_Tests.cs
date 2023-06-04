using IoC.Adapter;

namespace IoC.Benchmarks.Tests
{
    public class Benchmark_03_Tests
    {
        [Fact]
        public void Baseline()
        { 
            var benchmark = new Benchmark_03_Combined();

            // Validate
            Assert.Null(benchmark.Adapter);
            Assert.Null(benchmark.Container);
            Assert.Null(benchmark.ServiceLocator);
            Assert.True(0 == benchmark.Registrations.Count());
        }

        [Theory]
        [MemberData(nameof(AdapterInfoSource))]
        public void TransientCombinedt(AdapterInfo info)
        {
            // Setup
            var benchmark = new Benchmark_03_Combined
            {
                Container = info
            };
            benchmark.IterationSetup();

            // Act
            var result = benchmark.TransientCombined();

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

            Assert.Equivalent(nameof(Combined0), result[0].GetType().Name);
            Assert.Equivalent(nameof(Combined1), result[1].GetType().Name);
            Assert.Equivalent(nameof(Combined2), result[2].GetType().Name);
            Assert.Equivalent(nameof(Combined3), result[3].GetType().Name);
            Assert.Equivalent(nameof(Combined4), result[4].GetType().Name);

            Assert.NotSame(result[0], benchmark.ServiceLocator.GetInstance(benchmark.Registrations[0].ContractType));
            Assert.NotSame(result[1], benchmark.ServiceLocator.GetInstance(benchmark.Registrations[1].ContractType));
            Assert.NotSame(result[2], benchmark.ServiceLocator.GetInstance(benchmark.Registrations[2].ContractType));
            Assert.NotSame(result[3], benchmark.ServiceLocator.GetInstance(benchmark.Registrations[3].ContractType));
            Assert.NotSame(result[4], benchmark.ServiceLocator.GetInstance(benchmark.Registrations[4].ContractType));
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
