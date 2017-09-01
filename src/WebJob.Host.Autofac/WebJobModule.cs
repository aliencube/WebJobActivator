using Autofac;

namespace WebJob.Host.Autofac
{
    /// <summary>
    /// This represents the Autofac module entity.
    /// </summary>
    public class WebJobModule : Module
    {
        /// <inheritdoc />
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<Helper>().AsSelf().InstancePerDependency();
            builder.RegisterType<Functions>().AsSelf().InstancePerDependency();
        }
    }
}
