using TaxCalculator.Commands.Calculate;
using TaxCalculator.Commands.Contracts;

namespace TaxCalculator.Core.Factories
{
    public class CommandFactory : ICommandFactory
    {
        private static Dictionary<string, Type> commands = new Dictionary<string, Type>();
        private static ICommandFactory instanceHolder = new CommandFactory();

        public CommandFactory()
        {
            Register<CalculateNetIncomeCommand>();
        }

        public static ICommandFactory Instance
        {
            get
            {
                return instanceHolder;
            }
        }
        
        static void Register<T>() where T : ICommand
        {
            Type type = typeof(T);
            string commandName = type.Name.ToLower().Replace("command", "");
            if (!commands.ContainsKey(commandName))
            {
                commands.Add(commandName, type);
            }
        }

        public ICommand? CreateCommand(string commandName)
        {
            Type commandType = commands[commandName.ToLower()];
            return (ICommand?) Activator.CreateInstance(commandType, CalculatorFactory.Instance, Engine.Instance);
        }
    }
}