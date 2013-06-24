/*
 * 1. (25%) Refactor the code to improve its quality
 * 2. (10%) Debug and find the bug that causes the exception
 * 3. (45%) Unit test the public methods from the ICatalog interface (code coverage at least 80%)
 * 4. (10%) Document all public methods (defined in the interfaces)
 * 5. (10%) Find the performance bottleneck and fix it
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CatalogOfFreeContent
{
    public class CatalogOfFreeContent
    {
        public static void Main()
        {
            StringBuilder output = new StringBuilder(); 
            Catalog catalog = new Catalog();
            ICommandExecutor commandExecutor = new CommandExecutor();

            var commands = ReadInputCommands();
            foreach (ICommand command in commands)
            {
                commandExecutor.ExecuteCommand(catalog, command, output);
            }

            Console.Write(output);
        }

        private static List<ICommand> ReadInputCommands()
        {
            List<ICommand> commands = new List<ICommand>();
            bool endCommandFound = false;

            while (true)
            {
                string line = Console.ReadLine();
                endCommandFound = (line.Trim() == "End");
                if (endCommandFound)
                {
                    break;
                }
                commands.Add(new Command(line));

            }           

            return commands;
        }
    }
}
