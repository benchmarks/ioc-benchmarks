using CommonServiceLocator;
using Microsoft.VisualStudio.Composition;
using System.Composition;

namespace IoC.VisualStudio.Composition
{
    /// <summary>
    /// An implementation of <see cref="IServiceLocator"/> that wraps the container.
    /// </summary>
    [Export]
    [Export(typeof(IServiceLocator))]
    public sealed class ServiceLocator : IServiceLocator, IDisposable
    {
        private ExportProvider _container;

        [ImportingConstructor]
        public ServiceLocator(ExportProvider provider)
        {
            _container = provider;
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
            => _container.GetExportedValues(serviceType, null).First()!;

        public object GetInstance(Type serviceType, string key)
            => _container.GetExportedValues(serviceType, key).First()!;

        public TService GetInstance<TService>()
            => _container.GetExport<TService>(null).Value;

        public TService GetInstance<TService>(string key)
            => _container.GetExport<TService>(key).Value;

        public object GetService(Type serviceType)
            => _container.GetExportedValues(serviceType, null).FirstOrDefault()!;

        public void Dispose() => _container.Dispose();
    }
}
