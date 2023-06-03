using IoC.Adapter;
using CommonServiceLocator;
using System.Reflection;

namespace IoC.Unity
{
    public class ContainerAdapter : Adapter.AdapterBase
    {
        public ContainerAdapter(AdapterInfo info)
            : base(info)
        {
        }

        public override IServiceLocator GetServiceLocator(IEnumerable<RegistrationDescriptor> registrations)
        {
            var container = (IUnityContainer)new UnityContainer();

            foreach (var registration in registrations)
            {
                switch (registration.Lifetime)
                {
                    case RegistrationLifetime.Singleton:
                        container.RegisterType(registration.ImplementationType is null ? null : registration.ContractType, 
                                               registration.ImplementationType ?? registration.ContractType, 
                                               registration.ContractName, 
                                               new ContainerControlledLifetimeManager());
                        break;

                    case RegistrationLifetime.Scoped:
                        container.RegisterType(registration.ImplementationType is null ? null : registration.ContractType,
                                               registration.ImplementationType ?? registration.ContractType,
                                               registration.ContractName,
                                               new ContainerControlledLifetimeManager());
                        break;

                    default:
                        container.RegisterType(registration.ImplementationType is null ? null : registration.ContractType,
                                               registration.ImplementationType ?? registration.ContractType,
                                               registration.ContractName,
                                               new TransientLifetimeManager());
                        break;
                }
            }

            return new ServiceLocator(container);
        }
    }
}
