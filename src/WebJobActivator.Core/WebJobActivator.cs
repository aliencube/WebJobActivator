using System;

namespace Aliencube.WebJobActivator.Core
{
    /// <summary>
    /// This represents the activator entity for Azure WebJob instance.
    /// </summary>
    public abstract class WebJobActivator : IWebJobActivator
    {
        /// <inheritdoc />
        public virtual IWebJobActivator RegisterDependencies<THandler>(THandler handler = default(THandler)) where THandler : RegistrationHandler
        {
            if (handler == null)
            {
                return this;
            }

            handler.IsRegistered = true;

            return this;
        }

        /// <inheritdoc />
        public virtual T CreateInstance<T>()
        {
            return Activator.CreateInstance<T>();
        }
    }
}
