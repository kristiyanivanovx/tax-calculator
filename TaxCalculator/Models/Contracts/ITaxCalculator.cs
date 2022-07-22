namespace TaxCalculator.Models.Contracts
{
    public interface ITaxCalculator
    {
        string GetNetIncomeMessage();

        void CollectDollarsAmount(string input);

        void CalculateIncomeTax();
    
        bool IsBaseSalaryBelowThreshold();

        void CalculateSocialTax();

        void CalculateNetIncome();
    }
}