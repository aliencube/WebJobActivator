using System;

using Microsoft.Azure.WebJobs;

namespace Aliencube.WebJobActivator.Core
{
    /// <summary>
    /// This represents the builder entity for <see cref="JobHostConfiguration"/>.
    /// </summary>
    public class JobHostConfigurationBuilder : IJobHostConfigurationBuilder
    {
        private JobHostConfiguration _config;

        /// <summary>
        /// Initializes a new instance of the <see cref="JobHostConfigurationBuilder"/> class.
        /// </summary>
        /// <param name="activator"><see cref="IWebJobActivator"/> instance.</param>
        /// <exception cref="ArgumentNullException"><paramref name="activator"/> is <see langword="null"/>.</exception>
        public JobHostConfigurationBuilder(IWebJobActivator activator)
        {
            if (activator == null)
            {
                throw new ArgumentNullException(nameof(activator));
            }

            this._config = new JobHostConfiguration() { JobActivator = activator }
                               .UseDevelopmentSettingsIfNecessary();
        }

        /// <inheritdoc />
        public void AddConfiguration(Action<JobHostConfiguration> action)
        {
            if (action == null)
            {
                throw new ArgumentNullException(nameof(action));
            }

            action.Invoke(this._config);
        }

        /// <inheritdoc />
        public JobHostConfiguration Build()
        {
            return this._config;
        }
    }
}
