using Autofac;
using CommonServiceLocator;
using IoC.Adapter;

namespace IoC.Autofac
{
    public class ContainerAdapter : Adapter.AdapterBase
    {
        public ContainerAdapter(AdapterInfo info)
            : base(info)
        {
        }

        public override IServiceLocator GetServiceLocator(IEnumerable<RegistrationDescriptor> registrations)
        {
            var builder = new ContainerBuilder();

            foreach (var current in registrations)
            {                    
                var registration = current.ImplementationType is null
                    ? builder.RegisterType(current.ContractType)
                    : builder.RegisterType(current.ImplementationType).As(current.ContractType);

                if (current.ContractName is not null) 
                    registration.Named(current.ContractName, current.ContractType);

                switch (current.Lifetime)
                {
                    case RegistrationLifetime.Singleton:
                        registration.InstancePerLifetimeScope();
                        break;

                    case RegistrationLifetime.Scoped:
                        registration.InstancePerLifetimeScope();
                        break;

                    default:
                        registration.InstancePerDependency();
                        break;
                }
            }

            //// Register individual components
            //builder.RegisterInstance(new TaskRepository())
            //       .As<ITaskRepository>();

            return new ServiceLocator(builder);
        }
    }
}
