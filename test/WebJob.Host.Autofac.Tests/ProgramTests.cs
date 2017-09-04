using Aliencube.WebJobActivator.Core;

using FluentAssertions;

using Microsoft.VisualStudio.TestTools.UnitTesting;

using Moq;

using WebJob.Host.Autofac;

namespace Aliencube.WebJob.Host.Autofac.Tests
{
    /// <summary>
    /// This represents the test entity for WebJob's program.
    /// </summary>
    [TestClass]
    public class ProgramTests
    {
        /// <summary>
        /// Tests whether the method should return result or not.
        /// </summary>
        [TestMethod]
        public void Given_JobHostBuilder_Main_ShouldReturn_Result()
        {
            var builder = new Mock<IJobHostBuilder>();
            builder.SetupProperty(p => p.IsRunning);

            Program.WebJobHost = builder.Object;
            Program.Main();

            builder.Object.IsRunning.Should().BeTrue();
        }
    }
}
