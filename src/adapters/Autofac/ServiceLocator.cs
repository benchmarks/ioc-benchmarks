using CommonServiceLocator;
using Autofac;

#nullable disable

namespace IoC.Autofac
{
    /// <summary>
    /// An implementation of <see cref="IServiceLocator"/> that wraps the container.
    /// </summary>
    public sealed class ServiceLocator : IServiceLocator, IDisposable
    {
        private IContainer _container;


        public ServiceLocator(ContainerBuilder builder)
        {
            builder.RegisterInstance(this)
                   .As<IServiceProvider>();
            builder.RegisterInstance(this)
                   .As<IServiceLocator>();

            _container = builder.Build();
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
            => _container.Resolve(serviceType);

        public object GetInstance(Type serviceType, string key) 
            => throw new NotImplementedException();

        public TService GetInstance<TService>()
            => throw new NotImplementedException();

        public TService GetInstance<TService>(string key)
            => throw new NotImplementedException();

        public object GetService(Type serviceType)
            => _container.ResolveOptional(serviceType);


        public void Dispose() => _container.Dispose();
    }
}
