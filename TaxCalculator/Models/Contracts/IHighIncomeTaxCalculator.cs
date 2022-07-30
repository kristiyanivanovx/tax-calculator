namespace TaxCalculator.Models.Contracts
{
    public interface IHighIncomeTaxCalculator
    {
        int Calculate(int baseSalary, int highIncomeTaxThreshold, double highIncomeTaxPercent);
    }
}
