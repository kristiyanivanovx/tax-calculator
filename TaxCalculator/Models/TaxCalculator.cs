using TaxCalculator.Models.Contracts;

namespace TaxCalculator.Models
{
    public class TaxCalculator : ITaxCalculator
    {
        private const string GreetingMessage = "Welcome to Tax Calculator!";
        private const string InvalidFormatMessage = "Invalid dollars format. Use whole numbers (i.e. 3000) instead.";
        private const string ExpectInputMessage = "Please, input gross value: ";
        private const string NetIncomeMessage = "Your net income is: {0}";

        public TaxCalculator(
            int incomeTaxThreshold, 
            double incomeTaxPercent,
            int socialTaxThreshold,
            double socialTaxPercent)
        {
            this.IncomeTaxThreshold = incomeTaxThreshold;
            this.IncomeTaxPercent = incomeTaxPercent;
            this.SocialTaxThreshold = socialTaxThreshold;
            this.SocialTaxPercent = socialTaxPercent;
        }

        public int BaseSalary { get; set; }
        
        public int IncomeTax { get; set; }

        public int SocialTax { get; set; }

        public int NetIncome { get; set; }

        private int IncomeTaxThreshold { get; set; }

        private double IncomeTaxPercent { get; set; }

        private int SocialTaxThreshold { get; set; }

        private double SocialTaxPercent { get; set; }

        public string UseGreetingMessage() 
            => GreetingMessage;
        
        public string UseAskForInputMessage()
            => ExpectInputMessage;
        
        public string GetNetIncomeMessage() 
            => string.Format(NetIncomeMessage, this.NetIncome.ToString());
        
        public void CollectDollarsAmount(string input)
        {
            // Check whether dollars are being passed in correct format
            bool areDollarsInValidFormat = int.TryParse(input, out int dollarsParsed);
            if (areDollarsInValidFormat)
            {
                this.BaseSalary = dollarsParsed;
                return;
            }

            // Query the user for input until he provides the information in correct format
            while (!areDollarsInValidFormat)
            {
                Console.WriteLine(InvalidFormatMessage);
                Console.WriteLine(ExpectInputMessage);
                
                input = Console.ReadLine();
                
                areDollarsInValidFormat = int.TryParse(input, out int dollarsParsedInLoop);
                if (areDollarsInValidFormat)
                {
                    this.BaseSalary = dollarsParsedInLoop;
                    break;
                }
            }
        }

        // Income tax is calculated by taking a percent of the amount above threshold dollars.
        public void CalculateIncomeTax()
        {
            if (IsBaseSalaryBelowThreshold())
            {
                return;
            }

            this.IncomeTax = (int)((this.BaseSalary - this.IncomeTaxThreshold) * this.IncomeTaxPercent);
        }
        
        public bool IsBaseSalaryBelowThreshold()
        {
            // No taxing for any amount lower or equal to the income tax threshold dollars
            if (this.BaseSalary <= this.IncomeTaxThreshold)
            {
                this.NetIncome = this.BaseSalary;
            }

            return this.BaseSalary <= this.IncomeTaxThreshold;
        }
        
        // Note: Social Tax Threshold - STT for short
        // Tax the dollars above income tax threshold and below STT if total dollars are above the STT
        // else if total dollars are below the STT, only tax the dollars above the income tax threshold 
        public void CalculateSocialTax()
        {
            if (IsBaseSalaryBelowThreshold())
            {
                return;
            }
            
            var excessAmount = this.BaseSalary > this.SocialTaxThreshold ? this.BaseSalary - this.SocialTaxThreshold : 0;
            var sociallyTaxableAmount = this.BaseSalary - excessAmount - this.IncomeTaxThreshold;
            this.SocialTax = (int) (sociallyTaxableAmount * this.SocialTaxPercent);
        }

        // Net income is calculated by substituting the taxes from the initial amount
        public void CalculateNetIncome()
            => this.NetIncome = this.BaseSalary - (this.IncomeTax + this.SocialTax);
    }
}

