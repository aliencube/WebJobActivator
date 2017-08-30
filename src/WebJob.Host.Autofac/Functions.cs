using System.IO;

using Microsoft.Azure.WebJobs;

namespace WebJob.Host.Autofac
{
    /// <summary>
    /// This represents the function entity for Azure WebJob.
    /// </summary>
    public class Functions
    {
        /// <summary>
        /// Processes the incoming queue message.
        /// </summary>
        /// <param name="message">Queue message.</param>
        /// <param name="log">Log writer.</param>
        public static void ProcessQueueMessage([QueueTrigger("queue")] string message, TextWriter log)
        {
            log.WriteLine(message);
        }
    }
}
