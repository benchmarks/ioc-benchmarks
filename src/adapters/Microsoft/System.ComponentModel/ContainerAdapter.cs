using CommonServiceLocator;
using IoC.Adapter;
using System.ComponentModel.Composition.Hosting;

namespace IoC.System.ComponentModel
{
    public class ContainerAdapter : Adapter.AdapterBase
    {
        public ContainerAdapter(AdapterInfo info)
            : base(info)
        {
        }

        public override IServiceLocator GetServiceLocator(IEnumerable<RegistrationDescriptor> registrations)
        {
            var array = registrations.Select(registration => registration.ImplementationType ?? registration.ContractType)
                                     .ToArray();

            var catalog = new TypeCatalog(array);

            return new ServiceLocator(catalog);
        }
    }
}
