using IoC.Adapter;

namespace Container.Adapter.Tests
{
    public class GetAdapterTests 
    {
        [Fact]
        public void GetAdaptersTest()
        {
            var list = AdapterBase.GetAdapters();

            Assert.NotNull(list);
            Assert.IsAssignableFrom<IEnumerable<AdapterInfo>>(list);
        }

        [Theory]
        [MemberData(nameof(AdapterInfoSource))]
        public void GetAdapterInfoTest(AdapterInfo info) 
        {
            Assert.NotNull(info);

            var adapter = info.GetAdapter();
            Assert.NotNull(adapter);
        }

        [Theory]
        [MemberData(nameof(AdapterInfoSource))]
        public void GetServiceLocatorTest(AdapterInfo info)
        {
            Assert.NotNull(info);

            var adapter = info.GetAdapter();
            Assert.NotNull(adapter);

            var locator = adapter.GetServiceLocator(Enumerable.Empty<RegistrationDescriptor>());
            Assert.NotNull(locator);
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