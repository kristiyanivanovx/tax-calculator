using TaxCalculator.Models.Contracts;

namespace TaxCalculator.Core.Contracts
{
    public interface IEngine
    {
        void Start();

        IReader Reader { get; set; }

        IWriter Writer { get; set; }

        IParser Parser { get; set; }
        
        IInformationParser InformationParser { get; set; }
        
        IIncomeTaxCalculator IncomeTaxCalculator { get; set; }
        
        ISocialTaxCalculator SocialTaxCalculator { get; set; }

        IHighIncomeTaxCalculator HighIncomeTaxCalculator { get; set; }
        
        INetIncomeCalculator NetIncomeCalculator { get; set; }
    }
}