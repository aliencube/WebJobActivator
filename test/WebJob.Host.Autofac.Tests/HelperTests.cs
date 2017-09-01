using FluentAssertions;

using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace WebJob.Host.Autofac.Tests
{
    /// <summary>
    /// This represents the test entity for <see cref="Helper"/>.
    /// </summary>
    [TestClass]
    public class HelperTests
    {
        /// <summary>
        /// Tests whether the method should return result or not.
        /// </summary>
        [TestMethod]
        public void Given_Input_ProcessQueueMessage_ShouldReturn_Result()
        {
            var helper = new Helper();
            var message = "hello world";

            var result = helper.GetValue(message);

            result.Should().BeEquivalentTo($"The input value was: \"{message}\".");
        }
    }
}