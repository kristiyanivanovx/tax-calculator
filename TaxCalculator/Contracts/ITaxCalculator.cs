namespace TaxCalculator.Contracts
{
    public interface ITaxCalculator
    {
        string UseGreeting();

        string AskForInput();

        string GetNetIncomeMessage();

        void CollectDollarsAmount(string input);

        void CalculateIncomeTax();
    
        bool CheckDollarsBelowThreshold();

        void CalculateSocialTax();

        void CalculateNetIncome();
    }
}
