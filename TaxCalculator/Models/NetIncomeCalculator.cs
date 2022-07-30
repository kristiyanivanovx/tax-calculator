using TaxCalculator.Models.Contracts;

namespace TaxCalculator.Models
{
    public class NetIncomeCalculator : INetIncomeCalculator
    {
        // Tax the dollars above income tax threshold and below STT if total dollars are above the STT
        // else if total dollars are below the STT, only tax the dollars above the income tax threshold 
        // Net income is calculated by substituting the taxes from the initial amount
        public int Calculate(int baseSalary, int incomeTax, int socialTax, int highIncomeTax)
            => baseSalary - (incomeTax + socialTax + highIncomeTax);
    }    
}
