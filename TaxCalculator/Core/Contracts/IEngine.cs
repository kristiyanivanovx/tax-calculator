using TaxCalculator.Models.Contracts;

namespace TaxCalculator.Core.Contracts
{
    public interface IEngine
    {
        void Start();

        IReader Reader { get; set; }

        IWriter Writer { get; set; }

        IParser Parser { get; set; }
        
        ITaxCalculator TaxCalculator { get; set; }
    }
}