using System;

using Microsoft.Azure.WebJobs;

namespace Aliencube.WebJobActivator.Core
{
    /// <summary>
    /// This represents the builder entity for <see cref="JobHost"/>.
    /// </summary>
    public abstract class JobHostBuilder : IJobHostBuilder
    {
        private readonly JobHostConfiguration _config;

        /// <summary>
        /// Initializes a new instance of the <see cref="JobHostBuilder"/> class.
        /// </summary>
        /// <param name="config"><see cref="JobHostConfiguration"/> instance.</param>
        /// <exception cref="ArgumentNullException"><paramref name="config"/> is <see langword="null"/></exception>
        protected JobHostBuilder(JobHostConfiguration config)
        {
            if (config == null)
            {
                throw new ArgumentNullException(nameof(config));
            }

            this._config = config;
        }

        /// <inheritdoc />
        public bool IsRunning { get; set; }

        /// <summary>
        /// Gets the <see cref="Microsoft.Azure.WebJobs.JobHost"/> instance.
        /// </summary>
        protected JobHost JobHost { get; private set; }

        /// <inheritdoc />
        public void BuildHost()
        {
            this.JobHost = new JobHost(this._config);
        }

        /// <inheritdoc />
        public void RunAndBlock()
        {
            this.JobHost.RunAndBlock();
        }
    }
}
