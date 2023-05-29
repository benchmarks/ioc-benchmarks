using IoC.Adapter;
using IoC.Adapter.Tests.Base;

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

        [Fact]
        public void GetAdaptersSourceTest()
        {
            var source = new AdapterInfoSource();

            Assert.NotNull(source);
            Assert.IsAssignableFrom<IEnumerable<object[]>>(source);

            var list = source.ToArray();
            Assert.True(0 < list.Length);
        }

        [Theory]
        [ClassData(typeof(AdapterInfoSource))]
        public void InfoGetAdapterTest(AdapterInfo info) 
        {
            Assert.NotNull(info);

            var adapter = info.GetAdapter();
            Assert.NotNull(adapter);
        }
    }
} 