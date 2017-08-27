using Aliencube.WebJobActivator.Core.Tests.Fixtures;
using Aliencube.WebJobActivator.Tests.Common;

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
        private WebJobActivatorFixture _fixture;

        /// <summary>
        /// Initializes the test instance.
        /// </summary>
        [TestInitialize]
        public void Init()
        {
            this._fixture = new WebJobActivatorFixture();
        }

        /// <summary>
        /// Cleans up all resources.
        /// </summary>
        [TestCleanup]
        public void Cleanup()
        {
            this._fixture.Dispose();
        }

        /// <summary>
        /// Tests whether the method should return result or not.
        /// </summary>
        [TestMethod]
        public void Given_NullHandler_RegisterDependencies_ShouldReturn_Result()
        {
            var activator = this._fixture.ArrangeWebJobActivator(out RegistrationHandler handler);

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
            var activator = this._fixture.ArrangeWebJobActivator(out RegistrationHandler handler);

            var result = activator.RegisterDependencies(handler);

            result.Should().BeOfType<FooWebJobActivator>();
            result.Should().BeAssignableTo<IWebJobActivator>();
            handler.IsRegistered.Should().BeTrue();
        }
    }
}
