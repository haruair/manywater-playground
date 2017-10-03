using System;
using ManyWater.Cli.Attributes;
namespace ManyWater.Cli.Commands
{
    [Command("")]
    public class HomeCommand : IConsoleCommand
    {
        public void Handle()
        {
            Console.WriteLine("Welcome to ManyWater");
        }
    }
}
