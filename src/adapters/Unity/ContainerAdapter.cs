using CommonServiceLocator;
using IoC.Adapter.Registration;

namespace IoC.Unity
{
    public class ContainerAdapter : Adapter.AdapterBase
    {
        #region Types

        public override Type NativeInterfaceType => typeof(IUnityContainer);

        #endregion


        public override IServiceLocator GetServiceLocator(IEnumerable<RegistrationDescriptor>? registrations = null)
        {
            var container = new UnityContainer();

            if (registrations is not null) 
            { 
            
            }

            return new ServiceLocator(container);
        }

        public override IServiceProvider GetServiceProvider(IEnumerable<RegistrationDescriptor>? registrations = null)
            => GetServiceLocator(registrations);
    }
}
