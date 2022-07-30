using TaxCalculator.Models.Contracts;

namespace TaxCalculator.Models
{
    public class InformationParser : IInformationParser
    {
        private const string InvalidFormatMessage = "Invalid dollars format. Use whole numbers (i.e. 3000) instead.";
        private const string ExpectInputMessage = "Please, input gross value: ";
        private const string NetIncomeMessage = "Your net income is: {0}";
        private const string InputCouldNotBeParsed = "Invalid input! Base salary could not be parsed";

        public string GetNetIncomeMessage(int netIncome) 
            => string.Format(NetIncomeMessage, netIncome.ToString());
        
        public int ParseBaseSalaryAmount(string? input)
        {
            // Check whether dollars are being passed in correct format
            // If so, return early
            bool areDollarsInValidFormat = int.TryParse(input, out int baseSalary);
            if (areDollarsInValidFormat)
            {
                return baseSalary;
            }

            // If the data given isn't valid, query the user for input until he gives the information in correct format
            while (!areDollarsInValidFormat)
            {
                Console.WriteLine(InvalidFormatMessage);
                Console.WriteLine(ExpectInputMessage);
                
                input = Console.ReadLine();
                
                areDollarsInValidFormat = int.TryParse(input, out baseSalary);
                if (areDollarsInValidFormat)
                {
                    return baseSalary;
                }
            }

            throw new ArgumentException(InputCouldNotBeParsed);
        }
    }
}

