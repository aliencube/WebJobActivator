using Autofac;

using FluentAssertions;

using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Aliencube.WebJob.Host.Autofac.Tests
{
    /// <summary>
    /// This represents the test entity for <see cref="WebJobModule"/>.
    /// </summary>
    [TestClass]
    public class WebJobModuleTests
    {
        /// <summary>
        /// Tests whether the method should return result or not.
        /// </summary>
        [TestMethod]
        public void Given_Dependencies_Load_ShouldReturn_Result()
        {
            var builder = new ContainerBuilder();

            builder.RegisterModule<WebJobModule>();

            var container = builder.Build();

            var helper = container.Resolve<Helper>();
            var function = container.Resolve<Functions>();

            helper.Should().NotBeNull();
            function.Should().NotBeNull();
        }
    }
}