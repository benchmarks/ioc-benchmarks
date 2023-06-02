using System;
using System.Collections.Generic;
using System.Text;

namespace IoC.Adapter.Registration
{
    /// <summary>
    /// Specifies the lifetime of a service in an Microsoft.Extensions.DependencyInjection.IServiceCollection.
    /// </summary>
    public enum RegistrationLifetime : int
    {
        /// <summary>
        /// Specifies that a new instance of the service will be created every time it is requested.
        /// </summary>
        Transient = 0,

        /// <summary>
        /// Specifies that a single instance of the service will be created.
        /// </summary>
        Singleton,

        /// <summary>
        /// Specifies that a new instance of the service will be created for each scope.
        /// </summary>
        Scoped
    }
}
