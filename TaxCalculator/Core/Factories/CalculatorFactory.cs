using TaxCalculator.Models;
using TaxCalculator.Models.Contracts;

namespace TaxCalculator.Core.Factories
{
    public class CalculatorFactory : ICalculatorFactory
    {
        private static ICalculatorFactory instanceHolder = new CalculatorFactory();
        
        public static ICalculatorFactory Instance
        {
            get
            {
                return instanceHolder;
            }
        }

        public ICalculator? Create(CalculatorType calculatorType)
        {
            return calculatorType switch
            {
                CalculatorType.IncomeTax => new IncomeTaxCalculator(),
                CalculatorType.SocialTax => new SocialTaxCalculator(),
                CalculatorType.NetIncome => new NetIncomeCalculator(),
                _ => null
            };
        }
    }
}