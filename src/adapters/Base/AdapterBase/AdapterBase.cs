using CommonServiceLocator;
using IoC.Adapter.Registration;
using System;

namespace IoC.Adapter
{
    public abstract partial class AdapterBase
    {
        #region Types

        public virtual Type NativeInterfaceType => typeof(IServiceProvider);

        #endregion


        #region Services 

        public abstract IServiceProvider GetServiceProvider(IEnumerable<RegistrationDescriptor>? registrations = null);
        
        public abstract IServiceLocator GetServiceLocator(IEnumerable<RegistrationDescriptor>? registrations = null);

        #endregion


        #region Create adapter

        static public partial IEnumerable<AdapterInfo> GetAdapters();

        #endregion
    }
}
