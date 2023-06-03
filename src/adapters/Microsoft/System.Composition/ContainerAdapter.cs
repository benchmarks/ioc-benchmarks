using CommonServiceLocator;
using IoC.Adapter;
using System.Composition.Hosting;
using System.Diagnostics;

namespace IoC.System.Composition
{
    public class ContainerAdapter : Adapter.AdapterBase
    {
        public ContainerAdapter(AdapterInfo info)
            : base(info)
        {
        }

        public override IServiceLocator GetServiceLocator(IEnumerable<RegistrationDescriptor> registrations)
        {
            var configuration = new ContainerConfiguration();

            foreach (var registration in registrations)
            {
                configuration = configuration.WithPart(registration.ImplementationType ?? registration.ContractType);
            }

            return new ServiceLocator(configuration);
        }
    }
}
