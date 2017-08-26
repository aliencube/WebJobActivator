using System;

using Microsoft.Azure.WebJobs;

namespace Aliencube.WebJobActivator.Core
{
    /// <summary>
    /// This provides interfaces to the <see cref="JobHostConfigurationBuilder"/> class.
    /// </summary>
    public interface IJobHostConfigurationBuilder
    {
        /// <summary>
        /// Adds configuration.
        /// </summary>
        /// <param name="action"><see cref="Action{JobHostConfiguration}"/> instance.</param>
        /// <exception cref="ArgumentNullException"><paramref name="action"/> is <see langword="null"/>.</exception>
        void AddConfiguration(Action<JobHostConfiguration> action);

        /// <summary>
        /// Builds configuration.
        /// </summary>
        /// <returns>Returns the <see cref="JobHostConfiguration"/> instance.</returns>
        JobHostConfiguration Build();
    }
}