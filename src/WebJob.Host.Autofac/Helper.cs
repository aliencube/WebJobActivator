namespace Aliencube.WebJob.Host.Autofac
{
    /// <summary>
    /// This represents the helper entity.
    /// </summary>
    public class Helper
    {
        /// <summary>
        /// Gets the input value.
        /// </summary>
        /// <param name="input">Input value.</param>
        /// <returns>Return the input value as an output.</returns>
        public string GetValue(string input)
        {
            return $"The input value was: \"{input}\".";
        }
    }
}
