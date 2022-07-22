using TaxCalculator.Models.Contracts;

namespace TaxCalculator.Core.Factories
{
    public interface ITaxCalculatorFactory
    {
        ITaxCalculator Create(int incomeTaxThreshold, double incomeTaxPercent, int socialTaxThreshold, double socialTaxPercent);
    }    
}
