using IoC.Adapter;

namespace IoC.Benchmarks.Tests
{
    public class Benchmark_02_Tests
    {
        [Fact]
        public void Baseline()
        { 
            var benchmark = new Benchmark_02_Transient();

            // Validate
            Assert.Null(benchmark.Adapter);
            Assert.Null(benchmark.Container);
            Assert.Null(benchmark.ServiceLocator);
            Assert.True(0 == benchmark.Registrations.Count());
        }

        [Theory]
        [MemberData(nameof(AdapterInfoSource))]
        public void ContainerCreatedTransient(AdapterInfo info)
        {
            // Setup
            var benchmark = new Benchmark_02_Transient
            {
                Container = info
            };
            benchmark.IterationSetup();

            // Act
            var result = benchmark.ContainerCreatedTransient();

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

            Assert.Equivalent(nameof(Transient0), result[0].GetType().Name);
            Assert.Equivalent(nameof(Transient1), result[1].GetType().Name);
            Assert.Equivalent(nameof(Transient2), result[2].GetType().Name);
            Assert.Equivalent(nameof(Transient3), result[3].GetType().Name);
            Assert.Equivalent(nameof(Transient4), result[4].GetType().Name);

            Assert.NotSame(result[0], benchmark.ServiceLocator.GetInstance(benchmark.Registrations[0].ContractType));
            Assert.NotSame(result[1], benchmark.ServiceLocator.GetInstance(benchmark.Registrations[1].ContractType));
            Assert.NotSame(result[2], benchmark.ServiceLocator.GetInstance(benchmark.Registrations[2].ContractType));
            Assert.NotSame(result[3], benchmark.ServiceLocator.GetInstance(benchmark.Registrations[3].ContractType));
            Assert.NotSame(result[4], benchmark.ServiceLocator.GetInstance(benchmark.Registrations[4].ContractType));
        }



        [Theory]
        [MemberData(nameof(AdapterInfoSource))]
        public void ContainerCreatedTransientService(AdapterInfo info)
        {
            // Setup
            var benchmark = new Benchmark_02_Transient
            {
                Container = info
            };
            benchmark.IterationSetup();

            // Act
            var result = benchmark.ContainerCreatedTransientService();

            // Validate
            Assert.NotNull(result[0]);
            Assert.NotNull(result[1]);
            Assert.NotNull(result[2]);
            Assert.NotNull(result[3]);
            Assert.NotNull(result[4]);

            Assert.IsType(info.GetType(nameof(TransientService0))!, result[0]);
            Assert.IsType(info.GetType(nameof(TransientService1))!, result[1]);
            Assert.IsType(info.GetType(nameof(TransientService2))!, result[2]);
            Assert.IsType(info.GetType(nameof(TransientService3))!, result[3]);
            Assert.IsType(info.GetType(nameof(TransientService4))!, result[4]);

            Assert.Equivalent(nameof(TransientService0), result[0].GetType().Name);
            Assert.Equivalent(nameof(TransientService1), result[1].GetType().Name);
            Assert.Equivalent(nameof(TransientService2), result[2].GetType().Name);
            Assert.Equivalent(nameof(TransientService3), result[3].GetType().Name);
            Assert.Equivalent(nameof(TransientService4), result[4].GetType().Name);

            Assert.NotSame(result[0], benchmark.ServiceLocator.GetInstance(benchmark.Registrations[5].ContractType));
            Assert.NotSame(result[1], benchmark.ServiceLocator.GetInstance(benchmark.Registrations[6].ContractType));
            Assert.NotSame(result[2], benchmark.ServiceLocator.GetInstance(benchmark.Registrations[7].ContractType));
            Assert.NotSame(result[3], benchmark.ServiceLocator.GetInstance(benchmark.Registrations[8].ContractType));
            Assert.NotSame(result[4], benchmark.ServiceLocator.GetInstance(benchmark.Registrations[9].ContractType));
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
