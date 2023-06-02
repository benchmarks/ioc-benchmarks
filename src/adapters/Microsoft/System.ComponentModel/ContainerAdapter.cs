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
            var container = new CompositionContainer(catalog);

            return new ServiceLocator(container);
        }

        public override IServiceProvider GetServiceProvider(IEnumerable<RegistrationDescriptor>? registrations = null)
            => GetServiceLocator(registrations);
    }
}
