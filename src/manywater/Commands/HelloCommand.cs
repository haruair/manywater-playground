using System;
using ManyWater.Cli.Attributes;

namespace ManyWater.Cli.Commands
{
    [Command("hello")]
    public class HelloCommand : IConsoleCommand
    {
        public void Handle()
        {
            Console.WriteLine("Hello");
        }
    }
}
