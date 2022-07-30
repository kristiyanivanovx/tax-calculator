using TaxCalculator.Models.Contracts;

namespace TaxCalculator.Models
{
    public class SocialTaxCalculator : ISocialTaxCalculator
    {
        public int Calculate(int baseSalary, int incomeTaxThreshold, int socialTaxThreshold, double socialTaxPercent)
        {
            if (baseSalary <= incomeTaxThreshold)
            {
                return 0;
            }
            
            int excessAmount = baseSalary > socialTaxThreshold ? baseSalary - socialTaxThreshold : 0;
            int sociallyTaxableAmount = baseSalary - excessAmount - incomeTaxThreshold;
            
            return (int) (sociallyTaxableAmount * socialTaxPercent);
        }
    }
}