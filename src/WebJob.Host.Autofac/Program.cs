using Aliencube.WebJobActivator.Autofac;
using Aliencube.WebJobActivator.Core;

namespace WebJob.Host.Autofac
{
    /// <summary>
    /// This represents the entry point of the Azure WebJobs instance.
    /// </summary>
    public static class Program
    {
        /// <summary>
        /// Gets or sets the <see cref="IJobHostBuilder"/> instance.
        /// </summary>
        public static IJobHostBuilder WebJobHost { get; set; } = new AutofacJobHostBuilder(new WebJobModule())
                                                                     .AddConfiguration(p => p.UseDevelopmentSettingsIfNecessary());

        /// <summary>
        /// Runs the Azure WebJob instance.
        /// </summary>
        public static void Main()
        {
            WebJobHost.BuildHost();
            WebJobHost.IsRunning = true;
            WebJobHost.RunAndBlock();
        }
    }
}
