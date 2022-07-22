using TaxCalculator.Commands.Contracts;

namespace TaxCalculator.Core.Contracts
{
    public interface IParser
    {
        ICommand ParseCommand(string command);

        IList<string> ParseParameters(string command);
    }
}