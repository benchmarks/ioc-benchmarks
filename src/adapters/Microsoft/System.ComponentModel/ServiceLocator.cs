using CommonServiceLocator;
using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;

namespace IoC.System.ComponentModel
{
    /// <summary>
    /// An implementation of <see cref="IServiceLocator"/> that wraps the container.
    /// </summary>
    public sealed class ServiceLocator : IServiceLocator, IDisposable
    {
        private CompositionContainer _container;


        public ServiceLocator(TypeCatalog catalog)
        {
            _container = new CompositionContainer(catalog);
            _container.ComposeExportedValue<IServiceProvider>(this);
            _container.ComposeExportedValue<IServiceLocator>(this);
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
            => _container.GetExports(serviceType, null, null)
                         .First()
                         .Value;

        public object GetInstance(Type serviceType, string key)
            => _container.GetExports(serviceType, null, key)
                         .First()
                         .Value;

        public TService GetInstance<TService>()
            => _container.GetExportedValue<TService>( null)!;

        public TService GetInstance<TService>(string key)
            => _container.GetExportedValue<TService>(key)!;

        public object GetService(Type serviceType)
            => _container.GetExports(serviceType, null, null)
                         .FirstOrDefault()?
                         .Value!;

        public void Dispose() => _container.Dispose();
    }
}
