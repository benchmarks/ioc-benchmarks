using CommonServiceLocator;
using IoC.Adapter.Registration;
using System.ComponentModel.Composition.Hosting;

namespace IoC.System.ComponentModel
{
    public class ContainerAdapter : Adapter.AdapterBase
    {
        public override IServiceLocator GetServiceLocator(IEnumerable<RegistrationDescriptor>? registrations = null)
        {
            var catalog = new TypeCatalog();

            return new ServiceLocator(catalog);
        }

        public override IServiceProvider GetServiceProvider(IEnumerable<RegistrationDescriptor>? registrations = null)
            => GetServiceLocator(registrations);
    }
}
