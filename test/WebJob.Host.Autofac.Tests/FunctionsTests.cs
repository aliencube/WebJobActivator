using System;
using System.IO;

using FluentAssertions;

using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace WebJob.Host.Autofac.Tests
{
    /// <summary>
    /// This represents the test entity for <see cref="Functions"/>.
    /// </summary>
    [TestClass]
    public class FunctionsTests
    {
        /// <summary>
        /// Tests whether the constructor should throw an exception or not.
        /// </summary>
        [TestMethod]
        public void Given_NullParameter_Constructor_ShouldThrow_Exception()
        {
            Action action = () => new Functions(null);
            action.ShouldThrow<ArgumentNullException>();
        }

        /// <summary>
        /// Tests whether the method should return result or not.
        /// </summary>
        [TestMethod]
        public void Given_Input_ProcessQueueMessage_ShouldReturn_Result()
        {
            var helper = new Helper();
            var function = new Functions(helper);
            var message = "hello world";
            var log = new StringWriter();

            function.ProcessQueueMessage(message, log);

            log.ToString().Should().BeEquivalentTo($"The input value was: \"{message}\".\r\n");

            log.Dispose();
        }
    }
}