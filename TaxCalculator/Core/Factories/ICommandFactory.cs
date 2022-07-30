using TaxCalculator.Commands.Contracts;

namespace TaxCalculator.Core.Factories
{
    public interface ICommandFactory
    {
        private static Dictionary<string, Type> commands = new Dictionary<string, Type>();

        static void Register<T>() where T : ICommand
        {

        }
        
        ICommand? CreateCommand(string commandName);
    }
}