using System;

using Aliencube.WebJobActivator.Tests.Common;

namespace Aliencube.WebJobActivator.Core.Tests.Fixtures
{
    /// <summary>
    /// This represents the fixture entity for <see cref="WebJobActivatorTests"/>.
    /// </summary>
    public class WebJobActivatorFixture : IDisposable
    {
        private bool _disposed;

        /// <summary>
        /// Arranges the <see cref="IWebJobActivator"/> instance.
        /// </summary>
        /// <param name="handler"><see cref="RegistrationHandler"/> instance.</param>
        /// <returns>Returns the <see cref="IWebJobActivator"/> instance.</returns>
        public IWebJobActivator ArrangeWebJobActivator(out RegistrationHandler handler)
        {
            handler = new FooRegistrationHandler();

            var activator = new FooWebJobActivator();

            return activator;
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
