namespace TaxCalculator.Commands.Contracts
{
    public interface ICommand
    {
        string Execute(IList<string> parameters);
    }
}