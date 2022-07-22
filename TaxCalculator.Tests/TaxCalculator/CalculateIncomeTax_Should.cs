using NUnit.Framework;

namespace TaxCalculator.Tests.TaxCalculator
{
    public class Tests
    {
        private Models.TaxCalculator taxCalculator;
        
        [SetUp]
        public void Setup()
        {
            int incomeTaxThreshold = 1000;
            double incomeTaxPercent = 10.0 / 100.0;
            int socialTaxThreshold = 3000;
            double socialTaxPercent = 15.0 / 100.0;

            this.taxCalculator = new Models.TaxCalculator(
                incomeTaxThreshold,
                incomeTaxPercent, 
                socialTaxThreshold, 
                socialTaxPercent);
        }

        [Test]
        [TestCase("980", 0)]
        [TestCase("3400", 240)]
        [TestCase("5600", 460)]
        [TestCase("2400", 140)]
        public void CalculateCorrectIncomeTax(string dollars, int expectedIncomeTax)
        {
            // Arrange & Act
            this.taxCalculator.CollectDollarsAmount(dollars);
            this.taxCalculator.CalculateIncomeTax();
            
            // Assert
            Assert.AreEqual(expectedIncomeTax, this.taxCalculator.IncomeTax);
        }
        
        [Test]
        [TestCase("980", 0)]
        [TestCase("3400", 300)]
        [TestCase("5600", 300)]
        [TestCase("2400", 210)]
        public void CalculateCorrectSocialTax(string dollars, int expectedSocialTax)
        {
            // Arrange & Act
            this.taxCalculator.CollectDollarsAmount(dollars);
            this.taxCalculator.CalculateSocialTax();
            
            // Assert
            Assert.AreEqual(expectedSocialTax, this.taxCalculator.SocialTax);
        }
        
        [Test]
        [TestCase("980", 980)]
        [TestCase("3400", 2860)]
        [TestCase("5600", 4840)]
        [TestCase("2400", 2050)]
        public void CalculateCorrectNetSalary(string dollars, int expectedNetAmount)
        {
            // Arrange & Act
            this.taxCalculator.CollectDollarsAmount(dollars);
            this.taxCalculator.CalculateIncomeTax();
            this.taxCalculator.CalculateSocialTax();
            this.taxCalculator.CalculateNetIncome();
            
            // Assert
            Assert.AreEqual(expectedNetAmount, this.taxCalculator.NetIncome);
        }
    }
}
