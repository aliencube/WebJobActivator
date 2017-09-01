using System;

using Aliencube.WebJobActivator.Tests.Common;

namespace Aliencube.WebJobActivator.Core.Tests.Fixtures
{
    /// <summary>
    /// This represents the fixture entity for <see cref="JobHostConfigurationBuilderTests"/>.
    /// </summary>
    public class JobHostConfigurationFixture : IDisposable
    {
        private bool _disposed;

        /// <summary>
        /// Arranges the <see cref="IJobHostConfigurationBuilder"/> instance.
        /// </summary>
        /// <returns>Returns the <see cref="IJobHostConfigurationBuilder"/> instance.</returns>
        public IJobHostConfigurationBuilder ArrangeJobHostConfigurationBuilder()
        {
            var activator = new FooWebJobActivator();
            var builder = new JobHostConfigurationBuilder(activator);

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
