using System;
using System.Diagnostics;
using System.Reflection;

using Aliencube.WebJobActivator.Core.Tests.Fixtures;
using Aliencube.WebJobActivator.Tests.Common;

using FluentAssertions;

using Microsoft.Azure.WebJobs;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Aliencube.WebJobActivator.Core.Tests
{
    /// <summary>
    /// This represents the test entity for <see cref="JobHostBuilder"/>.
    /// </summary>
    [TestClass]
    public class JobHostBuilderTests
    {
        private JobHostFixture _fixture;

        /// <summary>
        /// Initializes the test instance.
        /// </summary>
        [TestInitialize]
        public void Init()
        {
            this._fixture = new JobHostFixture();
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
            Action action = () => new FooJobHostBuilder(null);
            action.ShouldThrow<ArgumentNullException>();
        }

        /// <summary>
        /// Tests whether the method should return result or not.
        /// </summary>
        [TestMethod]
        public void Given_Config_AddConfiguration_ShouldReturn_Result()
        {
            var builder = this._fixture.ArrangeJobHostBuilder();

            builder.AddConfiguration(p => p.UseDevelopmentSettings());

            var result = typeof(JobHostBuilder).GetField("_config", BindingFlags.Instance | BindingFlags.NonPublic)
                                               .GetValue(builder) as IJobHostConfigurationBuilder;

            result.Build().Tracing.ConsoleLevel.Should().Be(TraceLevel.Verbose);
        }

        /// <summary>
        /// Tests whether the method should return result or not.
        /// </summary>
        [TestMethod]
        public void Given_Config_BuildHost_ShouldReturn_Result()
        {
            var builder = this._fixture.ArrangeJobHostBuilder();

            builder.BuildHost();

            var result = typeof(JobHostBuilder).GetField("_host", BindingFlags.Instance | BindingFlags.NonPublic)
                                               .GetValue(builder);

            result.Should().NotBeNull();
            result.Should().BeOfType<JobHost>();
        }
    }
}
