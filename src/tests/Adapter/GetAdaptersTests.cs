using IoC.Adapter;

namespace Container.Adapter.Tests
{
    public class GetAdaptersTests 
    {
        [Fact]
        public void GetAdaptersTest()
        {
            var list = ContainerAdapter.GetAdapters();

            Assert.NotNull(list);
            Assert.IsAssignableFrom<IEnumerable<AdapterInfo>>(list);
        }

        [Theory]
        [MemberData(nameof(AdapterInfoSource))]
        public void InfoGetAdapterTest(AdapterInfo info) 
        {
            Assert.NotNull(info);

            var adapter = info.GetAdapter();
            Assert.NotNull(adapter);
        }


        #region Test Data

        public static IEnumerable<object[]> AdapterInfoSource 
        { 
            get
            {             
                foreach (var adapter in ContainerAdapter.GetAdapters())
                {
                    yield return new object[] { adapter };
                }
            }
        }

        #endregion
    }
} 