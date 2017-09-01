using System;

using Aliencube.WebJobActivator.Core;

using Autofac.Core;

using Microsoft.Azure.WebJobs;

using Moq;

namespace Aliencube.WebJobActivator.Autofac.Tests.Fixtures
{
    /// <summary>
    /// This represents the fixture entity for tests.
    /// </summary>
    public class WebJobFixture : IDisposable
    {
        private bool _disposed;

        /// <summary>
        /// Arranges the <see cref="IWebJobActivator"/> instance for <see cref="AutofacJobActivator"/>.
        /// </summary>
        /// <param name="handler"><see cref="RegistrationHandler"/> instance.</param>
        /// <returns>Returns the <see cref="IWebJobActivator"/> instance.</returns>
        public IWebJobActivator ArrangeAutofacWebJobActivator(out RegistrationHandler handler)
        {
            handler = new AutofacRegistrationHandler();

            var activator = new AutofacJobActivator();

            return activator;
        }

        /// <summary>
        /// Arranges the <see cref="IJobHostBuilder"/> instance for <see cref="AutofacJobHostBuilder"/>.
        /// </summary>
        /// <returns>Returns the <see cref="IJobHostBuilder"/> instance.</returns>
        public IJobHostBuilder ArrangeAutofacJobHostBuilder()
        {
            var activator = new Mock<IWebJobActivator>();
            var config = new JobHostConfigurationBuilder(activator.Object);

            var builder = new AutofacJobHostBuilder(config);

            return builder;
        }

        /// <summary>
        /// Arranges the <see cref="IJobHostBuilder"/> instance for <see cref="AutofacJobHostBuilder"/>.
        /// </summary>
        /// <param name="module"><see cref="IModule"/> instance.</param>
        /// <returns>Returns the <see cref="IJobHostBuilder"/> instance.</returns>
        public IJobHostBuilder ArrangeAutofacJobHostBuilder(IModule module)
        {
            var builder = new AutofacJobHostBuilder(module);

            return builder;
        }

        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
        /// </summary>
        public void Dispose()
        {
            if (this._disposed)
            {
                return;
            }

            this._disposed = true;
        }
    }
}
