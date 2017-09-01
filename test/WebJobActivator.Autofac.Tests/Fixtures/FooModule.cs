using Aliencube.WebJobActivator.Tests.Common;

using Autofac;

namespace Aliencube.WebJobActivator.Autofac.Tests.Fixtures
{
    /// <summary>
    /// This represents the Autofac module entity.
    /// </summary>
    public class FooModule : Module
    {
        /// <inheritdoc />
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<FooFunction>().AsSelf();
        }
    }
}
