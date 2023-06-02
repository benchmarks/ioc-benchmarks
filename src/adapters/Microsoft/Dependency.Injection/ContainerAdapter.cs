using CommonServiceLocator;
using IoC.Adapter.Registration;
using Microsoft.Extensions.DependencyInjection;

namespace IoC.DependencyInjection
{
    public class ContainerAdapter : Adapter.AdapterBase
    {
        public override IServiceLocator GetServiceLocator(IEnumerable<RegistrationDescriptor>? registrations = null) 
            => new ServiceLocator((ServiceProvider)GetServiceProvider(registrations));

        public override IServiceProvider GetServiceProvider(IEnumerable<RegistrationDescriptor>? registrations = null)
        {
            var services = new ServiceCollection();

            if (registrations is not null)
            {
            }

            return services.BuildServiceProvider(validateScopes: true);
        }
    }
}
