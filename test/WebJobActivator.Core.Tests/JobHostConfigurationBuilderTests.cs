using System;
using System.Diagnostics;

using Aliencube.WebJobActivator.Core.Tests.Fixtures;

using FluentAssertions;

using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Aliencube.WebJobActivator.Core.Tests
{
    /// <summary>
    /// This represents the test entity for <see cref="JobHostConfigurationBuilder"/>.
    /// </summary>
    [TestClass]
    public class JobHostConfigurationBuilderTests
    {
        private JobHostConfigurationFixture _fixture;

        /// <summary>
        /// Initializes the test instance.
        /// </summary>
        [TestInitialize]
        public void Init()
        {
            this._fixture = new JobHostConfigurationFixture();
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
            Action action = () => new JobHostConfigurationBuilder(null);
            action.ShouldThrow<ArgumentNullException>();
        }

        /// <summary>
        /// Tests whether the method should throw an exception or not.
        /// </summary>
        [TestMethod]
        public void Given_NullParameter_AddConfiguration_ShouldThrow_Exception()
        {
            var builder = this._fixture.ArrangeJobHostConfigurationBuilder();

            Action action = () => builder.AddConfiguration(null);
            action.ShouldThrow<ArgumentNullException>();
        }

        /// <summary>
        /// Tests whether the method should return result.
        /// </summary>
        [TestMethod]
        public void Given_Configuration_AddConfiguration_ShouldReturn_Result()
        {
            var builder = this._fixture.ArrangeJobHostConfigurationBuilder();

            builder.AddConfiguration(p => p.UseDevelopmentSettings());

            var config = builder.Build();

            config.Tracing.ConsoleLevel.Should().Be(TraceLevel.Verbose);
        }
    }
}
