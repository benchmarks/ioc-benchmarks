using IoC.Adapter;
using IoC.Benchmarks;

namespace Benchmarks.Base.Tests
{
    public class BenchmarksBaseTests
    {
        [Fact]
        public void FieldsContent()
        {
            var instance = new TestBenchmarks();

            Assert.Null(instance.Adapter);
            Assert.Null(instance.Container);
            Assert.Null(instance.ServiceLocator);
            Assert.True(0 == instance.Registrations.Count());
        }

        [Theory]
        [MemberData(nameof(AdapterInfoSource))]
        public void IterationSetupTest(AdapterInfo info)
        {
            // Setup
            var instance = new TestBenchmarks
            {
                Container = info
            };

            // Act
            instance.IterationSetup();
            Assert.NotNull(instance.Adapter);
            Assert.NotNull(instance.ServiceLocator);
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

        class TestBenchmarks : BenchmarksBase
        { 
        }

        #endregion
    }
} 