namespace Aliencube.WebJobActivator.Core
{
    /// <summary>
    /// This represents the handler entity for dependency registration.
    /// </summary>
    public abstract class RegistrationHandler
    {
        /// <summary>
        /// Gets or sets a value indicating whether the dependencies have been registered or not.
        /// </summary>
        public virtual bool IsRegistered { get; set; }
    }
}