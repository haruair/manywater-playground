using System;
using System.Linq;
using System.Reflection;

namespace ManyWater.Cli
{
	/// <summary>
	/// Console application.
	/// </summary>
	public class ConsoleApplication
	{
        /// <summary>
        /// Gets or sets the arguments.
        /// </summary>
        /// <value>The arguments.</value>
        public string[] Args
        {
            get;
            set;
        }

		/// <summary>
		/// Make this instance.
		/// </summary>
		/// <returns>The console application as a fluent.</returns>
		public static ConsoleApplication Make()
		{
			return new ConsoleApplication();
		}

		/// <summary>
		/// Bind string arguments into console applcation.
		/// </summary>
		/// <returns>The console application as a fluent.</returns>
		/// <param name="args">Arguments.</param>
		public ConsoleApplication WithArguments(string[] args)
		{
            Args = args;
			return this;
		}

		/// <summary>
		/// Run this instance.
		/// </summary>
		public void Run()
		{
            IConsoleCommand command;

            try
            {
				var commandType = GetCommandTypeByArguments();

				// need to be replaced by IoC Container
				command = Activator.CreateInstance(commandType) as IConsoleCommand;
            }
            catch
            {
                command = new Commands.HomeCommand();
            }

            command.Handle();
		}

        /// <summary>
        /// Gets the command by arguments.
        /// </summary>
        /// <returns>The command by arguments.</returns>
        Type GetCommandTypeByArguments()
		{
			foreach (var assembly in AppDomain.CurrentDomain.GetAssemblies())
			{
				var types = from type in assembly.GetTypes()
							where typeof(IConsoleCommand).IsAssignableFrom(type)
							select type;

                foreach (Type type in types)
				{
					var attribs = type.GetCustomAttributes(typeof(Attributes.Command), false);
					if (attribs != null && attribs.Length > 0)
					{
						foreach (Attributes.Command item in attribs)
						{
                            if (item.Method == Args[0])
                            {
                                return type;
                            }
						}
					}
				}
			}
            throw new Exception();
        }
	}
}
