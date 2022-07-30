namespace TaxCalculator.Models.Contracts
{
    public interface INetIncomeCalculator : ICalculator
    {
        int Calculate(int baseSalary, int incomeTax, int socialTax, int highIncomeTax);
    }
}
