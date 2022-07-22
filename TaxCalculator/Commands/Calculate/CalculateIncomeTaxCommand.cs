using TaxCalculator.Commands.Contracts;
using TaxCalculator.Core.Contracts;
using TaxCalculator.Core.Factories;

namespace TaxCalculator.Commands.Calculate
{
    public class CalculateIncomeTaxCommand : ICommand
    {
        private readonly ITaxCalculatorFactory factory;
        private readonly IEngine engine;

        public CalculateIncomeTaxCommand(ITaxCalculatorFactory factory, IEngine engine)
        {
            this.factory = factory;
            this.engine = engine;
        }

        public string Execute(IList<string> parameters)
        {
            try
            {
                int incomeTaxThreshold = 1000;
                double incomeTaxPercent = 10.0 / 100.0;
                int socialTaxThreshold = 3000;
                double socialTaxPercent = 15.0 / 100.0;
                
                this.engine.TaxCalculator = this.factory.Create(
                    incomeTaxThreshold,
                    incomeTaxPercent, 
                    socialTaxThreshold, 
                    socialTaxPercent);

                string baseSalary = parameters[0];
                this.engine.TaxCalculator.CollectDollarsAmount(baseSalary);
            }
            catch
            {
                throw new ArgumentException("Failed to parse CalculateIncomeTax command parameters.");
            }
            
            this.engine.TaxCalculator.CalculateIncomeTax();
            
            this.engine.TaxCalculator.CalculateSocialTax();
            
            this.engine.TaxCalculator.CalculateNetIncome();
                
            return this.engine.TaxCalculator.GetNetIncomeMessage();
        }
    }
}