using CommonServiceLocator;

#nullable disable

namespace IoC.Unity
{
    /// <summary>
    /// An implementation of <see cref="IServiceLocator"/> that wraps a Unity container.
    /// </summary>
    public sealed class ServiceLocator : IServiceLocator, IDisposable
    {
        private IUnityContainer _container;


        public ServiceLocator(IUnityContainer container)
        {
            _container = container;

            container.RegisterInstance(typeof(IServiceProvider), this, new ExternallyControlledLifetimeManager());
            container.RegisterInstance(typeof(IServiceLocator),  this, new ExternallyControlledLifetimeManager());
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
            => _container.Resolve(serviceType, null);

        public object GetInstance(Type serviceType, string key) 
            => _container.Resolve(serviceType, key);

        public TService GetInstance<TService>()
            => (TService)_container.Resolve(typeof(TService), null);

        public TService GetInstance<TService>(string key)
            => (TService)_container.Resolve(typeof(TService), key);

        public object GetService(Type serviceType)
        {
            try
            {
                return _container.Resolve(serviceType, null);
            }
            catch 
            {
                return null;
            }
        }

        public void Dispose() => _container.Dispose();
    }
}
