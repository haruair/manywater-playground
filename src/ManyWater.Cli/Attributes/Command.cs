using System;
namespace ManyWater.Cli.Attributes
{
    /// <summary>
    /// Command.
    /// </summary>
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
    public class Command : Attribute
    {
        public string Method
        {
            get;
            private set;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="T:ManyWater.Cli.Attributes.Command"/> class.
        /// </summary>
        /// <param name="method">Method.</param>
        public Command(string method)
        {
            Method = method;
        }
    }
}
