using System;
using ManyWater.Cli;
using ManyWater.Cli.Attributes;

namespace ManyWater.Cli.Commands
{
    [Command("bye")]
    public class ByeCommand : IConsoleCommand
    {
        public void Handle()
        {
            Console.WriteLine("Bye");
        }
    }
}
