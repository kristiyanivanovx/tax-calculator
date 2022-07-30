namespace TaxCalculator.Models.Contracts
{
    public interface ISocialTaxCalculator : ICalculator
    {
        int Calculate(int baseSalary, int incomeTaxThreshold, int socialTaxThreshold, double socialTaxPercent);
    }
}