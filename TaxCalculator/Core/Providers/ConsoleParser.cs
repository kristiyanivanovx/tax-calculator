using TaxCalculator.Commands.Contracts;
using TaxCalculator.Core.Contracts;
using TaxCalculator.Core.Factories;

namespace TaxCalculator.Core.Providers
{
    public class CommandParser : IParser
    {
        private CommandFactory commandFactory = new CommandFactory();    
    
        public ICommand ParseCommand(string fullCommand)
        {
            string commandName = fullCommand.Split(' ')[0];
            ICommand command = this.commandFactory.CreateCommand(commandName);

            return command;
        }

        public IList<string> ParseParameters(string fullCommand)
        {
            List<string> commandParts = fullCommand.Split(' ').ToList();
            commandParts.RemoveAt(0);

            if (commandParts.Count() == 0)
            {
                return new List<string>();
            }

            return commandParts;
        }
    }
}
