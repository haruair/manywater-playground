using System;

namespace ManyWater.Cli
{
    /// <summary>
    /// Commandline tool entry point
    /// </summary>
    class Program
    {
        /// <summary>
        /// The entry point of the program, where the program control starts and ends.
        /// </summary>
        /// <param name="args">The command-line arguments.</param>
        static void Main(string[] args)
        {
            // Initialise Console application with given arguments from console.
            ConsoleApplication
                .Make()
                .WithArguments(args)
                .Run();
        }
    }
}
