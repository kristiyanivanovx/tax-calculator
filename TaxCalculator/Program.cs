namespace TaxCalculator
{
    class Program
    {
        public static void Main(string [] args)
        {
            TaxCalculator taxCalculator = new TaxCalculator(1000, 10 / 100);
            
            // Print information / give instructions to the user
            Console.WriteLine(taxCalculator.UseGreeting());
            Console.WriteLine(taxCalculator.AskForInput());

            taxCalculator.CollectDollarsAmount(Console.ReadLine());

            bool areDollarsBelowThreshold = taxCalculator.CheckDollarsBelowThreshold();
            if (areDollarsBelowThreshold)
            {
                Console.WriteLine(taxCalculator.GetNetIncomeMessage());
                return;
            }
            
            taxCalculator.CalculateIncomeTax();
            
            taxCalculator.CalculateSocialTax();

            taxCalculator.CalculateNetIncome();

            Console.WriteLine(taxCalculator.GetNetIncomeMessage());
        }
    }
}