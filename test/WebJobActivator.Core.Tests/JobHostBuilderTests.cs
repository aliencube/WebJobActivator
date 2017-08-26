using System;
using System.Reflection;

using Aliencube.WebJobActivator.Core.Tests.Fixtures;

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
        /// <summary>
        /// Tests whether the constructor should throw an exception or not.
        /// </summary>
        [TestMethod]
        public void Given_Null_Constructor_ShouldThrow_Exception()
        {
            Action action = () => new FooJobHostBuilder(null);
            action.ShouldThrow<ArgumentNullException>();
        }

        /// <summary>
        /// Tests whether the method should return result or not.
        /// </summary>
        [TestMethod]
        public void Given_Config_BuildHost_ShouldReturn_Result()
        {
            var config = new JobHostConfiguration();
            var builder = new FooJobHostBuilder(config);

            builder.BuildHost();

            var result = typeof(JobHostBuilder).GetProperty("JobHost", BindingFlags.Instance | BindingFlags.NonPublic)
                                               .GetValue(builder);

            result.Should().NotBeNull();
            result.Should().BeOfType<JobHost>();
        }
    }
}
