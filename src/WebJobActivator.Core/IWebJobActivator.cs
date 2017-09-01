using Microsoft.Azure.WebJobs.Host;

namespace Aliencube.WebJobActivator.Core
{
    /// <summary>
    /// This provides interfaces to the <see cref="WebJobActivator"/> class.
    /// </summary>
    public interface IWebJobActivator : IJobActivator
    {
        /// <summary>
        /// Registers dependencies.
        /// </summary>
        /// <typeparam name="THandler">Type of <see cref="RegistrationHandler"/>.</typeparam>
        /// <param name="handler"><see cref="THandler"/> instance.</param>
        /// <returns>Returns the <see cref="IWebJobActivator"/> instance.</returns>
        IWebJobActivator RegisterDependencies<THandler>(THandler handler = default(THandler)) where THandler : RegistrationHandler;
    }
}