namespace TaxCalculator.Models.Contracts
{
    public interface IInformationParser
    {
        string GetNetIncomeMessage(int netIncome);
    
        int ParseBaseSalaryAmount(string? input);
    }
}

