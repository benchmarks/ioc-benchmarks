using Autofac;
using CommonServiceLocator;
using IoC.Adapter.Registration;

namespace IoC.Autofac
{
    public class ContainerAdapter : Adapter.AdapterBase
    {

        public override IServiceLocator GetServiceLocator(IEnumerable<RegistrationDescriptor>? registrations = null)
        {
            var builder = new ContainerBuilder();

            //// Register individual components
            //builder.RegisterInstance(new TaskRepository())
            //       .As<ITaskRepository>();
            //builder.RegisterType<TaskController>();
            //builder.Register(c => new LogManager(DateTime.Now))
            //       .As<ILogger>();

            //// Scan an assembly for components
            //builder.RegisterAssemblyTypes(myAssembly)
            //       .Where(t => t.Name.EndsWith("Repository"))
            //       .AsImplementedInterfaces();

            return new ServiceLocator(builder);
        }

        public override IServiceProvider GetServiceProvider(IEnumerable<RegistrationDescriptor>? registrations = null)
            => GetServiceLocator(registrations);
    }
}
