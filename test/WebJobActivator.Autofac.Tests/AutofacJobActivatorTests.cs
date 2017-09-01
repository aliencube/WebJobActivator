using System.Collections.Generic;
using System.Linq;
using System.Reflection;

using Aliencube.WebJobActivator.Autofac.Tests.Fixtures;
using Aliencube.WebJobActivator.Core;
using Aliencube.WebJobActivator.Tests.Common;

using Autofac;
using Autofac.Core;
using Autofac.Core.Lifetime;

using FluentAssertions;

using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Aliencube.WebJobActivator.Autofac.Tests
{
    /// <summary>
    /// This represents the test entity for <see cref="AutofacJobActivator"/>.
    /// </summary>
    [TestClass]
    public class AutofacJobActivatorTests
    {
        private WebJobFixture _fixture;

        /// <summary>
        /// Initializes the test instance.
        /// </summary>
        [TestInitialize]
        public void Init()
        {
            this._fixture = new WebJobFixture();
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
            var activator = this._fixture.ArrangeAutofacWebJobActivator(out RegistrationHandler handler);

            activator.RegisterDependencies((RegistrationHandler)null);

            var dependencies = GetRegisteredDependencies(activator);

            dependencies.Should().HaveCount(0);
        }

        /// <summary>
        /// Tests whether the method should return result or not.
        /// </summary>
        [TestMethod]
        public void Given_InvalidHandler_RegisterDependencies_ShouldReturn_Result()
        {
            var activator = this._fixture.ArrangeAutofacWebJobActivator(out RegistrationHandler handler);

            handler = new FooRegistrationHandler();

            activator.RegisterDependencies(handler);

            var dependencies = GetRegisteredDependencies(activator);

            dependencies.Should().HaveCount(0);
        }

        /// <summary>
        /// Tests whether the method should return result or not.
        /// </summary>
        [TestMethod]
        public void Given_HandlerWithModule_RegisterDependencies_ShouldReturn_Result()
        {
            var activator = this._fixture.ArrangeAutofacWebJobActivator(out RegistrationHandler handler);

            var autofac = handler as AutofacRegistrationHandler;
            autofac.RegisterModule = p => p.RegisterModule<FooModule>();

            activator.RegisterDependencies(handler);

            var dependencies = GetRegisteredDependencies(activator);

            dependencies.Should().HaveCount(1);
            dependencies.Single().Activator.LimitType.Name.Should().BeEquivalentTo("FooFunction");
        }

        /// <summary>
        /// Tests whether the method should return result or not.
        /// </summary>
        [TestMethod]
        public void Given_HandlerWithDependency_RegisterDependencies_ShouldReturn_Result()
        {
            var activator = this._fixture.ArrangeAutofacWebJobActivator(out RegistrationHandler handler);

            var autofac = handler as AutofacRegistrationHandler;
            autofac.RegisterType = p => p.RegisterType<FooFunction>().AsSelf();

            activator.RegisterDependencies(handler);

            var dependencies = GetRegisteredDependencies(activator);

            dependencies.Should().HaveCount(1);
            dependencies.Single().Activator.LimitType.Name.Should().BeEquivalentTo("FooFunction");
        }

        /// <summary>
        /// Tests whether the method should return result or not.
        /// </summary>
        [TestMethod]
        public void Given_HandlerWithDependency_CreateInstance_ShouldReturn_Result()
        {
            var activator = this._fixture.ArrangeAutofacWebJobActivator(out RegistrationHandler handler);

            var autofac = handler as AutofacRegistrationHandler;
            autofac.RegisterType = p => p.RegisterType<FooFunction>().AsSelf();

            activator.RegisterDependencies(handler);

            var instance = activator.CreateInstance<FooFunction>();

            instance.Should().NotBeNull();
            instance.Should().BeOfType<FooFunction>();
        }

        private static IEnumerable<IComponentRegistration> GetRegisteredDependencies(IWebJobActivator activator)
        {
            var container = typeof(AutofacJobActivator).GetField("_container", BindingFlags.Instance | BindingFlags.NonPublic)
                                                       .GetValue(activator) as IContainer;

            var dependencies = container.ComponentRegistry
                                        .Registrations
                                        .Where(p => p.Activator.LimitType.Name != typeof(LifetimeScope).Name);

            return dependencies;
        }
    }
}
