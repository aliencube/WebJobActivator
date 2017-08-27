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

        private JobHost _host;

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

        /// <inheritdoc />
        public IJobHostBuilder AddConfiguration(Action<JobHostConfiguration> action)
        {
            if (action == null)
            {
                throw new ArgumentNullException(nameof(action));
            }

            action.Invoke(this._config);

            return this;
        }

        /// <inheritdoc />
        public void BuildHost()
        {
            this._host = new JobHost(this._config);
        }

        /// <inheritdoc />
        public void RunAndBlock()
        {
            this._host.RunAndBlock();
        }
    }
}
