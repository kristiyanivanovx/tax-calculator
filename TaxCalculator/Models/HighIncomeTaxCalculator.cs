using TaxCalculator.Models.Contracts;

namespace TaxCalculator.Models
{
    public class HighIncomeTaxCalculator : IHighIncomeTaxCalculator
    {
        public int Calculate(int baseSalary, int highIncomeTaxThreshold, double highIncomeTaxPercent)
            => baseSalary <= highIncomeTaxThreshold
                ? 0
                : (int)((baseSalary - highIncomeTaxThreshold) * highIncomeTaxPercent);
    }
}
