using NUnit.Framework;
using TaxCalculator.Models;

namespace TaxCalculator.Tests
{
    public class Tests
    {
        private InformationParser informationParser;
        private IncomeTaxCalculator incomeTaxCalculator;
        private SocialTaxCalculator socialTaxCalculator;
        private HighIncomeTaxCalculator highIncomeTaxCalculator;
        private NetIncomeCalculator netIncomeCalculator;
        
        private int incomeTaxThreshold = 1000;
        private double incomeTaxPercent = 10.0 / 100.0;
        private int socialTaxThreshold = 3000;
        private double socialTaxPercent = 15.0 / 100.0;
        private int highIncomeTaxThreshold = 10000;
        private double highIncomeTaxPercent = 50.0 / 100.0;
        
        [SetUp]
        public void Setup()
        {
            this.informationParser = new InformationParser();
            this.incomeTaxCalculator = new IncomeTaxCalculator();
            this.socialTaxCalculator = new SocialTaxCalculator();
            this.highIncomeTaxCalculator = new HighIncomeTaxCalculator();
            this.netIncomeCalculator = new NetIncomeCalculator();
        }

        [Test]
        [TestCase("980", 0)]
        [TestCase("3400", 240)]
        [TestCase("5600", 460)]
        [TestCase("2400", 140)]
        public void CalculateCorrectIncomeTax(string baseSalaryString, int expectedIncomeTax)
        {
            // Arrange & Act
            int baseSalary = this.informationParser.ParseBaseSalaryAmount(baseSalaryString);
            int incomeTax = this.incomeTaxCalculator.Calculate(baseSalary, incomeTaxThreshold, incomeTaxPercent);
            
            // Assert
            Assert.AreEqual(expectedIncomeTax, incomeTax);
        }
        
        [Test]
        [TestCase("980", 0)]
        [TestCase("3400", 300)]
        [TestCase("5600", 300)]
        [TestCase("2400", 210)]
        public void CalculateCorrectSocialTax(string baseSalaryString, int expectedSocialTax)
        {
            // Arrange & Act
            int baseSalary = this.informationParser.ParseBaseSalaryAmount(baseSalaryString);
            int socialTax = this.socialTaxCalculator.Calculate(baseSalary, incomeTaxThreshold, socialTaxThreshold, socialTaxPercent);
            
            // Assert
            Assert.AreEqual(expectedSocialTax, socialTax);
        }
        
        [Test]
        [TestCase("12000", 1000)]
        [TestCase("10000", 0)]
        public void CalculateCorrectHighIncomeTax(string baseSalaryString, int expectedHighIncomeTax)
        {
            // Arrange & Act
            int baseSalary = this.informationParser.ParseBaseSalaryAmount(baseSalaryString);
            int highIncomeTax = this.highIncomeTaxCalculator.Calculate(baseSalary, highIncomeTaxThreshold, highIncomeTaxPercent);
            
            // Assert
            Assert.AreEqual(expectedHighIncomeTax, highIncomeTax);
        }

        [Test]
        [TestCase("980", 980)]
        [TestCase("3400", 2860)]
        [TestCase("5600", 4840)]
        [TestCase("12000", 9600)]
        [TestCase("2400", 2050)]
        public void CalculateCorrectNetIncome(string baseSalaryString, int expectedNetIncome)
        {
            // Arrange & Act
            int baseSalary = this.informationParser.ParseBaseSalaryAmount(baseSalaryString);
            int incomeTax = this.incomeTaxCalculator.Calculate(baseSalary, incomeTaxThreshold, incomeTaxPercent);
            int socialTax = this.socialTaxCalculator.Calculate(baseSalary, incomeTaxThreshold, socialTaxThreshold, socialTaxPercent);
            int highIncomeTax =
                this.highIncomeTaxCalculator.Calculate(baseSalary, highIncomeTaxThreshold, highIncomeTaxPercent);
            int netIncome = this.netIncomeCalculator.Calculate(baseSalary, incomeTax, socialTax, highIncomeTax);

            // Assert
            Assert.AreEqual(expectedNetIncome, netIncome);
        }
    }
}
