using System;

using Aliencube.WebJobActivator.Core;

using Autofac;

namespace Aliencube.WebJobActivator.Autofac
{
    /// <summary>
    /// This represents the handler entity for Autofac.
    /// </summary>
    public class AutofacRegistrationHandler : RegistrationHandler
    {
        /// <summary>
        /// Gets or sets the action to register module.
        /// </summary>
        public Action<ContainerBuilder> RegisterModule { get; set; }

        /// <summary>
        /// Gets or sets the action to register type.
        /// </summary>
        public Action<ContainerBuilder> RegisterType { get; set; }
    }
}