using System;

using Microsoft.Azure.WebJobs;

namespace Aliencube.WebJobActivator.Core
{
    /// <summary>
    /// This provides interfaces to the <see cref="JobHostBuilder"/> class.
    /// </summary>
    public interface IJobHostBuilder
    {
        /// <summary>
        /// Gets or sets a value indicating whether the WebJob host is up and running.
        /// </summary>
        bool IsRunning { get; set; }

        /// <summary>
        /// Adds job host configuration.
        /// </summary>
        /// <param name="action"><see cref="Action{JobHostConfiguration}"/> object.</param>
        /// <returns>Returns the <see cref="IJobHostBuilder"/> instance.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="action"/> is <see langword="null"/>.</exception>
        IJobHostBuilder AddConfiguration(Action<JobHostConfiguration> action);

        /// <summary>
        /// Builds a new WebJob host instance.
        /// </summary>
        void BuildHost();

        /// <summary>
        /// Runs the WebJob host instance and blocks the thread.
        /// </summary>
        void RunAndBlock();
    }
}