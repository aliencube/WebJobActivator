using System;
using System.Diagnostics;
using System.Reflection;

using Aliencube.WebJobActivator.Autofac.Tests.Fixtures;
using Aliencube.WebJobActivator.Core;

using Autofac.Core;

using FluentAssertions;

using Microsoft.Azure.WebJobs;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Aliencube.WebJobActivator.Autofac.Tests
{
    /// <summary>
    /// This represents the test entity for <see cref="AutofacJobHostBuilder"/>.
    /// </summary>
    [TestClass]
    public class AutofacJobHostBuilderTests
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
        /// Tests whether the constructor should throw an exception or not.
        /// </summary>
        [TestMethod]
        public void Given_NullParameter_Constructor_ShouldThrow_Exception()
        {
            Action action = () => new AutofacJobHostBuilder((JobHostConfiguration)null);
            action.ShouldThrow<ArgumentNullException>();

            action = () => new AutofacJobHostBuilder((IModule)null);
            action.ShouldThrow<ArgumentNullException>();
        }

        /// <summary>
        /// Tests whether the method should return result or not.
        /// </summary>
        [TestMethod]
        public void Given_Config_AddConfiguration_ShouldReturn_Result()
        {
            var builder = this._fixture.ArrangeAutofacJobHostBuilder();

            builder.AddConfiguration(p => p.UseDevelopmentSettings());

            var result = typeof(JobHostBuilder).GetField("_config", BindingFlags.Instance | BindingFlags.NonPublic)
                                               .GetValue(builder) as JobHostConfiguration;

            result.Tracing.ConsoleLevel.Should().Be(TraceLevel.Verbose);
        }

        /// <summary>
        /// Tests whether the method should return result or not.
        /// </summary>
        [TestMethod]
        public void Given_Config_BuildHost_ShouldReturn_Result()
        {
            var builder = this._fixture.ArrangeAutofacJobHostBuilder();

            builder.BuildHost();

            var result = typeof(JobHostBuilder).GetField("_host", BindingFlags.Instance | BindingFlags.NonPublic)
                                               .GetValue(builder);

            result.Should().NotBeNull();
            result.Should().BeOfType<JobHost>();
        }

        /// <summary>
        /// Tests whether the method should return result or not.
        /// </summary>
        [TestMethod]
        public void Given_Module_AddConfiguration_ShouldReturn_Result()
        {
            var module = new FooModule();

            var builder = this._fixture.ArrangeAutofacJobHostBuilder(module);

            builder.AddConfiguration(p => p.UseDevelopmentSettings());

            var result = typeof(JobHostBuilder).GetField("_config", BindingFlags.Instance | BindingFlags.NonPublic)
                                               .GetValue(builder) as JobHostConfiguration;

            result.Tracing.ConsoleLevel.Should().Be(TraceLevel.Verbose);
        }

        /// <summary>
        /// Tests whether the method should return result or not.
        /// </summary>
        [TestMethod]
        public void Given_Module_BuildHost_ShouldReturn_Result()
        {
            var module = new FooModule();

            var builder = this._fixture.ArrangeAutofacJobHostBuilder(module);

            builder.BuildHost();

            var result = typeof(JobHostBuilder).GetField("_host", BindingFlags.Instance | BindingFlags.NonPublic)
                                               .GetValue(builder);

            result.Should().NotBeNull();
            result.Should().BeOfType<JobHost>();
        }
    }
}
