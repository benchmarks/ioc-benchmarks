using CommonServiceLocator;
using IoC.Adapter;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace IoC.DependencyInjection
{
    public class ContainerAdapter : Adapter.AdapterBase
    {
        public ContainerAdapter(AdapterInfo info)
            : base(info)
        {
        }


        public override IServiceLocator GetServiceLocator(IEnumerable<RegistrationDescriptor> registrations)
        {
            var services = new ServiceCollection();

            foreach (var registration in registrations)
            {
                switch (registration.Lifetime)
                {
                    case RegistrationLifetime.Singleton:
                        if (registration.ImplementationType is null)
                            services.AddSingleton(registration.ContractType);
                        else
                            services.AddSingleton(registration.ContractType, registration.ImplementationType);
                        break;

                    case RegistrationLifetime.Scoped:
                        if (registration.ImplementationType is null)
                            services.AddScoped(registration.ContractType);
                        else
                            services.AddScoped(registration.ContractType, registration.ImplementationType);
                        break;

                    default:
                        if (registration.ImplementationType is null)
                            services.AddTransient(registration.ContractType);
                        else
                            services.AddTransient(registration.ContractType, registration.ImplementationType);
                        break;
                }
            }

            return new ServiceLocator(services);

        }
    }
}
