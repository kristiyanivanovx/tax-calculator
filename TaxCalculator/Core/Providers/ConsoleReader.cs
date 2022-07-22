using System;
using TaxCalculator.Core.Contracts;

namespace TaxCalculator.Core.Providers
{
    public class ConsoleReader : IReader
    {
        public string ReadLine()
        {
            return Console.ReadLine();
        }
    }
}