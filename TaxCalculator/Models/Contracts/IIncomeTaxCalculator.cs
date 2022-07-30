namespace TaxCalculator.Models.Contracts
{
    public interface IIncomeTaxCalculator : ICalculator
    {
        int Calculate(int baseSalary, int incomeTaxThreshold, double incomeTaxPercent);
    }
}