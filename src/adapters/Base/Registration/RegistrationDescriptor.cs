using System;
using System.Collections.Generic;
using System.Text;


namespace IoC.Adapter.Registration
{
    public class RegistrationDescriptor
    {
        #region Constructors

        public RegistrationDescriptor(Type type)
        {
            ContractType = type;
        }

        #endregion


        #region Properties

        public Type ContractType { get; }

        public string? ContractName { get; init; }

        public Type? ImplementationType { get; init; }

        public object? Instance { get; init; }

        public RegistrationLifetime Lifetime { get; init; }

        #endregion
    }
}
