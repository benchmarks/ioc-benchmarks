using CommonServiceLocator;
using System.Composition.Hosting;

#nullable disable

namespace IoC.System.Composition
{
    /// <summary>
    /// An implementation of <see cref="IServiceLocator"/> that wraps the container.
    /// </summary>
    public sealed class ServiceLocator : IServiceLocator, IDisposable
    {
        private CompositionHost _container;
        
        public ServiceLocator(CompositionHost container)
        {
            _container = container;
        }


        public IEnumerable<object> GetAllInstances(Type serviceType)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<TService> GetAllInstances<TService>()
        {
            throw new NotImplementedException();
        }

        public object GetInstance(Type serviceType)
            => _container.GetExport(serviceType);

        public object GetInstance(Type serviceType, string key)
            => _container.GetExport(serviceType, key);

        public TService GetInstance<TService>()
            => _container.GetExport<TService>();

        public TService GetInstance<TService>(string key)
            => _container.GetExport<TService>(key)!;

        public object GetService(Type serviceType)
        {
            try
            {
                return _container.GetExport(serviceType);
            }
            catch
            {
                return null;
            }
        }

        public void Dispose() => _container.Dispose();
    }
}
