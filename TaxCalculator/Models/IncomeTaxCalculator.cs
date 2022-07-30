using TaxCalculator.Models.Contracts;

namespace TaxCalculator.Models
{
    public class IncomeTaxCalculator : IIncomeTaxCalculator
    {
        // Income tax is calculated by taking a percent of the amount above threshold dollars.
        public int Calculate(int baseSalary, int incomeTaxThreshold, double incomeTaxPercent)
            => baseSalary <= incomeTaxThreshold
                ? 0
                : (int)((baseSalary - incomeTaxThreshold) * incomeTaxPercent);
    }
}

