using CommonServiceLocator;
using IoC.Adapter.Registration;
using System.Composition.Hosting;

namespace IoC.System.Composition
{
    public class ContainerAdapter : Adapter.AdapterBase
    {
        public override IServiceLocator GetServiceLocator(IEnumerable<RegistrationDescriptor>? registrations = null)
        {
            var configuration = new ContainerConfiguration();
            

            return new ServiceLocator(configuration);
        }

        public override IServiceProvider GetServiceProvider(IEnumerable<RegistrationDescriptor>? registrations = null)
            => GetServiceLocator(registrations);
    }
}
