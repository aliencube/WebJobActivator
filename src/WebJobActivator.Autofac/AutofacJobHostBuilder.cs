using Aliencube.WebJobActivator.Core;

using Autofac;
using Autofac.Core;

using Microsoft.Azure.WebJobs;

namespace Aliencube.WebJobActivator.Autofac
{
    /// <summary>
    /// This represents the builder entity for <see cref="JobHost"/> with Autofac.
    /// </summary>
    public class AutofacJobHostBuilder : JobHostBuilder
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AutofacJobHostBuilder"/> class.
        /// </summary>
        /// <param name="module"><see cref="IModule"/> instance.</param>
        public AutofacJobHostBuilder(IModule module)
            : this(GetJobHostConfigurationBuilder(module))
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="AutofacJobHostBuilder"/> class.
        /// </summary>
        /// <param name="config"><see cref="JobHostConfigurationBuilder"/> instance.</param>
        public AutofacJobHostBuilder(JobHostConfigurationBuilder config)
            : base(config)
        {
        }

        private static JobHostConfigurationBuilder GetJobHostConfigurationBuilder(IModule module)
        {
            if (module == null)
            {
                return null;
            }

            var handler = new AutofacRegistrationHandler() { RegisterModule = p => p.RegisterModule(module) };
            var activator = new AutofacJobActivator().RegisterDependencies(handler);
            var builder = new JobHostConfigurationBuilder(activator);

            return builder;
        }
    }
}