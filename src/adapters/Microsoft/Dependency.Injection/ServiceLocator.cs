using CommonServiceLocator;
using Microsoft.Extensions.DependencyInjection;


namespace IoC.DependencyInjection
{
    /// <summary>
    /// An implementation of <see cref="IServiceLocator"/> that wraps the container.
    /// </summary>
    public sealed class ServiceLocator : IServiceLocator, IDisposable
    {
        private ServiceProvider _container;


        public ServiceLocator(IServiceCollection services)
        {
            services.AddSingleton<IServiceLocator>(this);

            _container = services.BuildServiceProvider(validateScopes: true);
        }


        public IEnumerable<object> GetAllInstances(Type serviceType)
            => _container.GetServices(serviceType)!;

        public IEnumerable<TService> GetAllInstances<TService>()
            => _container.GetServices<TService>();

        public object GetInstance(Type serviceType) 
            => _container.GetRequiredService(serviceType);

        public object GetInstance(Type serviceType, string key)
            => _container.GetRequiredService(serviceType);

        // The type cannot be used as type parameter in the generic type or method. Nullability of type argument doesn't match 'notnull' constraint.
        #pragma warning disable CS8714 
 
        public TService GetInstance<TService>()
            => _container.GetRequiredService<TService>();

        #pragma warning restore CS8714 

        public TService GetInstance<TService>(string key)
            => throw new NotImplementedException();

        public object GetService(Type serviceType)
            => _container.GetService(serviceType)!;

        public void Dispose() => _container.Dispose();
    }
}
