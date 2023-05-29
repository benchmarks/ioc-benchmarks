using System.Collections;

namespace IoC.Adapter.Tests.Base
{
    public class AdapterInfoSource : IEnumerable<object[]>
    {
        public IEnumerator<object[]> GetEnumerator()
        {
            foreach (var adapter in ContainerAdapter.GetAdapters())
            {
                yield return new object[] { adapter };
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        => GetEnumerator();
    }
}
