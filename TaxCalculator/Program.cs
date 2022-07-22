using TaxCalculator.Core;

namespace TaxCalculator
{
    public class Program
    {
        public static void Main(string [] args)
        {
            var engine = Engine.Instance;
            engine.Start();
        }
    }
}