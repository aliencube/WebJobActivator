using System;
using System.IO;

using Microsoft.Azure.WebJobs;

namespace Aliencube.WebJob.Host.Autofac
{
    /// <summary>
    /// This represents the function entity for Azure WebJob.
    /// </summary>
    public class Functions
    {
        private readonly Helper _helper;

        /// <summary>
        /// Initializes a new instance of the <see cref="Functions"/> class.
        /// </summary>
        /// <param name="helper"><see cref="Helper"/> instance.</param>
        public Functions(Helper helper)
        {
            if (helper == null)
            {
                throw new ArgumentNullException(nameof(helper));
            }

            this._helper = helper;
        }

        /// <summary>
        /// Processes the incoming queue message.
        /// </summary>
        /// <param name="message">Queue message.</param>
        /// <param name="log">Log writer.</param>
        public void ProcessQueueMessage([QueueTrigger("queue")] string message, TextWriter log)
        {
            var output = this._helper.GetValue(message);

            log.WriteLine(output);
        }
    }
}
