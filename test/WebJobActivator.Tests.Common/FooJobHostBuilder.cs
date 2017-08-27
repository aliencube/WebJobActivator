using Aliencube.WebJobActivator.Core;

using Microsoft.Azure.WebJobs;

namespace Aliencube.WebJobActivator.Tests.Common
{
    /// <summary>
    /// This represents the builder entity for <see cref="JobHost"/>
    /// </summary>
    public class FooJobHostBuilder : JobHostBuilder
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="FooJobHostBuilder"/> class.
        /// </summary>
        /// <param name="config"><see cref="JobHostConfiguration"/> instance.</param>
        public FooJobHostBuilder(JobHostConfiguration config)
            : base(config)
        {
        }
    }
}
