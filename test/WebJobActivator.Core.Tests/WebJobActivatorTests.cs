using Aliencube.WebJobActivator.Core.Tests.Fixtures;

using FluentAssertions;

using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Aliencube.WebJobActivator.Core.Tests
{
    /// <summary>
    /// This represents the test entity for <see cref="WebJobActivator"/> class.
    /// </summary>
    [TestClass]
    public class WebJobActivatorTests
    {
        /// <summary>
        /// Tests whether the method should return result or not.
        /// </summary>
        [TestMethod]
        public void Given_WithoutHandler_RegisterDependencies_ShouldReturn_Result()
        {
            var activator = new FooWebJobActivator();

            var result = activator.RegisterDependencies((RegistrationHandler)null);

            result.Should().BeOfType<FooWebJobActivator>();
            result.Should().BeAssignableTo<IWebJobActivator>();
        }

        /// <summary>
        /// Tests whether the method should return result or not.
        /// </summary>
        [TestMethod]
        public void Given_Handler_RegisterDependencies_ShouldReturn_Result()
        {
            var activator = new FooWebJobActivator();
            var handler = new FooRegistrationHandler();

            var result = activator.RegisterDependencies(handler);

            result.Should().BeOfType<FooWebJobActivator>();
            result.Should().BeAssignableTo<IWebJobActivator>();
            handler.IsRegistered.Should().BeTrue();
        }
    }
}
