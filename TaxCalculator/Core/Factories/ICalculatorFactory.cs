using TaxCalculator.Models;
using TaxCalculator.Models.Contracts;

namespace TaxCalculator.Core.Factories
{
    public interface ICalculatorFactory
    {
        ICalculator? Create(CalculatorType calculatorType);
    }    
}
