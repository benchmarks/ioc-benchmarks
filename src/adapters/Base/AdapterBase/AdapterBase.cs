using CommonServiceLocator;

namespace IoC.Adapter
{
    public abstract partial class AdapterBase
    {
        #region Fields

        AdapterInfo _info;

        #endregion


        #region Constructors

        public AdapterBase(AdapterInfo info)
        {
            _info = info;
        }

        #endregion


        #region Services 

        public abstract IServiceLocator GetServiceLocator(IEnumerable<RegistrationDescriptor> registrations);

        #endregion


        #region Adapter info list

        static public partial IEnumerable<AdapterInfo> GetAdapters();

        #endregion


        #region Implementation

        public override string ToString() => _info.ToString();

        #endregion
    }
}
