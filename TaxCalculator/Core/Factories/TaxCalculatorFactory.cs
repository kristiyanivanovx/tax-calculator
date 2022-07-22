using TaxCalculator.Models.Contracts;

namespace TaxCalculator.Core.Factories
{
    public class TaxCalculatorFactory : ITaxCalculatorFactory
    {
        private static ITaxCalculatorFactory instanceHolder = new TaxCalculatorFactory();

        private TaxCalculatorFactory()
        {
        }

        public static ITaxCalculatorFactory Instance
        {
            get
            {
                return instanceHolder;
            }
        }

        public ITaxCalculator Create(int incomeTaxThreshold, double incomeTaxPercent, int socialTaxThreshold, double socialTaxPercent)
        {
            Models.TaxCalculator taxCalculator = new Models.TaxCalculator(incomeTaxThreshold, incomeTaxPercent, socialTaxThreshold, socialTaxPercent);
            return taxCalculator;
        }
    }
}