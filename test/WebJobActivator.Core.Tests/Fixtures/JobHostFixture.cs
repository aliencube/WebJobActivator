using System;

using Aliencube.WebJobActivator.Tests.Common;

using Moq;

namespace Aliencube.WebJobActivator.Core.Tests.Fixtures
{
    /// <summary>
    /// This represents the fixture entity for <see cref="JobHostBuilderTests"/>.
    /// </summary>
    public class JobHostFixture : IDisposable
    {
        private bool _disposed;

        /// <summary>
        /// Arranges the <see cref="IJobHostBuilder"/> instance.
        /// </summary>
        /// <returns>Returns the <see cref="IJobHostBuilder"/> instance.</returns>
        public IJobHostBuilder ArrangeJobHostBuilder()
        {
            var activator = new Mock<IWebJobActivator>();
            var config = new JobHostConfigurationBuilder(activator.Object);
            var builder = new FooJobHostBuilder(config);

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