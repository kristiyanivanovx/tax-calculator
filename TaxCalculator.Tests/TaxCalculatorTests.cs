using NUnit.Framework;

namespace TaxCalculator.Tests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        [TestCase(3400, 240)]
        [TestCase(5600, 460)]
        [TestCase(2400, 140)]
        public void AssertValidIncomeTaxAmountIsCalculated(int dollars, int expectedIncomeTax)
        {
            // Arrange
            var taxCalculator = new TaxCalculator();
            taxCalculator.Dollars = dollars;
            
            // Act
            taxCalculator.CalculateIncomeTax();
            
            // Assert
            Assert.AreEqual(expectedIncomeTax, taxCalculator.IncomeTax);
        }
        
        [Test]
        [TestCase(3400, 300)]
        [TestCase(5600, 300)]
        [TestCase(2400, 210)]
        public void AssertValidSocialTaxAmountIsCalculated(int dollars, int expectedSocialTax)
        {
            // Arrange
            var taxCalculator = new TaxCalculator();
            taxCalculator.Dollars = dollars;
            
            // Act
            taxCalculator.CalculateSocialTax();
            
            // Assert
            Assert.AreEqual(expectedSocialTax, taxCalculator.SocialTax);
        }
        
        [Test]
        [TestCase(3400, 2860)]
        [TestCase(5600, 4840)]
        [TestCase(2400, 2050)]
        public void AssertValidNetAmountIsCalculated(int dollars, int expectedNetAmount)
        {
            // Arrange
            var taxCalculator = new TaxCalculator();
            taxCalculator.Dollars = dollars;
            
            // Act
            taxCalculator.CalculateIncomeTax();
            taxCalculator.CalculateSocialTax();
            taxCalculator.CalculateNetIncome();
            
            // Assert
            Assert.AreEqual(expectedNetAmount, taxCalculator.NetIncome);
        }
    }
}
