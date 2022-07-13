using TaxCalculator.Contracts;

namespace TaxCalculator
{
    public class TaxCalculator : ITaxCalculator
    {
        private const string Greeting = "Welcome to Tax Calculator!";
        private const string InvalidFormat = "Invalid dollars format. Use whole numbers (i.e. 3000) instead.";
        private const string ExpectInput = "Please, input gross value: ";
        private const string NetIncomeMessage = "Your net income is: {0}";
        private const int DefaultIncomeTaxThreshold = 1000;
        private const double DefaultIncomeTaxPercent = 10.0 / 100.0;
        private const int DefaultSocialTaxThreshold = 3000;
        private const double DefaultSocialTaxPercent = 15.0 / 100.0;

        public TaxCalculator(
            int incomeTaxThreshold = DefaultIncomeTaxThreshold, 
            double incomeTaxPercent = DefaultIncomeTaxPercent,
            int socialTaxThreshold = DefaultSocialTaxThreshold,
            double socialTaxPercent = DefaultSocialTaxPercent)
        {
            this.IncomeTaxThreshold = incomeTaxThreshold;
            this.IncomeTaxPercent = incomeTaxPercent;
            this.SocialTaxThreshold = socialTaxThreshold;
            this.SocialTaxPercent = socialTaxPercent;
        }

        public int Dollars { get; set; }
        
        public int IncomeTax { get; set; }

        public int SocialTax { get; set; }

        public int NetIncome { get; set; }

        private int IncomeTaxThreshold { get; set; }

        private double IncomeTaxPercent { get; set; }

        private int SocialTaxThreshold { get; set; }

        private double SocialTaxPercent { get; set; }

        public virtual string UseGreeting()
        {
            return Greeting;
        }
        
        public virtual string AskForInput()
        {
            return ExpectInput;
        }
        
        public virtual string GetNetIncomeMessage()
        {
            return string.Format(NetIncomeMessage, this.NetIncome.ToString());
        }
        
        public virtual void CollectDollarsAmount(string input)
        {
            // Query the user for input until he provides the information in correct format
            while (true)
            {
                var areDollarsInValidFormat = int.TryParse(input, out int dollarsParsed);
                if (areDollarsInValidFormat)
                {
                    this.Dollars = dollarsParsed;
                    break;
                }

                Console.WriteLine(InvalidFormat);
                Console.WriteLine(this.AskForInput());
                
                input = Console.ReadLine();
            }
        }

        // Income tax is calculated by taking a percent of the amount above threshold dollars.
        public virtual void CalculateIncomeTax()
        {
            this.IncomeTax = (int) ((this.Dollars - this.IncomeTaxThreshold) * this.IncomeTaxPercent);
        }
        
        public virtual bool CheckDollarsBelowThreshold()
        {
            // No taxing for any amount lower or equal to the income tax threshold dollars
            if (this.Dollars <= this.IncomeTaxThreshold)
            {
                this.NetIncome = this.Dollars;
                return true;
            }

            return false;
        }
        
        // Note: Social Tax Threshold - STT for short
        // Tax the dollars above income tax threshold and below STT if total dollars are above the STT
        // else if total dollars are below the STT, only tax the dollars above the income tax threshold 
        public virtual void CalculateSocialTax()
        {
            var excessAmount = this.Dollars > this.SocialTaxThreshold ? this.Dollars - this.SocialTaxThreshold : 0;
            var sociallyTaxableAmount = this.Dollars - excessAmount - this.IncomeTaxThreshold;

            this.SocialTax = (int) (sociallyTaxableAmount * this.SocialTaxPercent);
        }

        // Net income is calculated by substituting the taxes from the initial amount
        public virtual void CalculateNetIncome()
        {
            this.NetIncome = this.Dollars - (this.IncomeTax + this.SocialTax);
        }
    }
}

