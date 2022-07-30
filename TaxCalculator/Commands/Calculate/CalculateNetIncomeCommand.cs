using TaxCalculator.Commands.Contracts;
using TaxCalculator.Core.Contracts;
using TaxCalculator.Core.Factories;

namespace TaxCalculator.Commands.Calculate
{
    public class CalculateNetIncomeCommand : ICommand
    {
        private readonly ICalculatorFactory factory;
        private readonly IEngine engine;

        public CalculateNetIncomeCommand(ICalculatorFactory factory, IEngine engine)
        {
            this.factory = factory;
            this.engine = engine;
        }

        public string Execute(IList<string> parameters)
        {
            int netIncome;
            int baseSalary = this.engine.InformationParser.ParseBaseSalaryAmount(parameters[0]);

            int incomeTaxThreshold = 1000;
            double incomeTaxPercent = 10.0 / 100.0;
            int socialTaxThreshold = 3000;
            double socialTaxPercent = 15.0 / 100.0;
            int highIncomeTaxThreshold = 10000;
            double highIncomeTaxPercent = 50.0 / 100.0;
            
            try
            {
                int incomeTax = this.engine.IncomeTaxCalculator.Calculate(
                    baseSalary,
                    incomeTaxThreshold,
                    incomeTaxPercent);

                int socialTax = this.engine.SocialTaxCalculator.Calculate(
                    baseSalary,
                    incomeTaxThreshold,
                    socialTaxThreshold,
                    socialTaxPercent);

                int highIncomeTax = this.engine.HighIncomeTaxCalculator.Calculate(
                    baseSalary,
                    highIncomeTaxThreshold,
                    highIncomeTaxPercent);
                    
                netIncome = this.engine.NetIncomeCalculator.Calculate(
                    baseSalary,
                    incomeTax,
                    socialTax, 
                    highIncomeTax);
            }
            catch
            {
                throw new ArgumentException("Failed to parse CalculateNetIncome command parameters.");
            }
                
            return this.engine.InformationParser.GetNetIncomeMessage(netIncome);
        }
    }
}