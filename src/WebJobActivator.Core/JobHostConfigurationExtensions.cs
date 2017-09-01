using Microsoft.Azure.WebJobs;

namespace Aliencube.WebJobActivator.Core
{
    /// <summary>
    /// This represents the extension class for the <see cref="JobHostConfiguration"/> class.
    /// </summary>
    public static class JobHostConfigurationExtensions
    {
        /// <summary>
        /// Uses the development settings if the WebJob is in "development" mode.
        /// </summary>
        /// <param name="config"><see cref="JobHostConfiguration"/> instance.</param>
        /// <returns>Returns the <see cref="JobHostConfiguration"/> instance.</returns>
        public static JobHostConfiguration UseDevelopmentSettingsIfNecessary(this JobHostConfiguration config)
        {
            if (config == null)
            {
                return null;
            }

            if (config.IsDevelopment)
            {
                config.UseDevelopmentSettings();
            }

            return config;
        }
    }
}