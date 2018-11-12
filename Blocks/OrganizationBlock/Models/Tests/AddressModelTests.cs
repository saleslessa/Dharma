using System;
using NUnit.Framework;

namespace Dharma.OrganizationBlock.Models.Tests
{
    [TestFixture]
    public class AddressModelTests
    {
        [Test]
        public void ValidateAddress_Should_NotReturnErrors()
        {
            // Arrange
            var model = new AddressModel()
            {
                Street = "Test one",
                StreetNumber = 123
            };

            // Act
            var result = model.IsValid();

            // Assert
            Assert.True(result);
        }

        [TestCase("", "")]
        [TestCase("a", "")]
        [TestCase("", "a")]
        [TestCase(" ", "a")]
        [TestCase("a", " ")]
        [TestCase(" ", " ")]
        public void ValidateAddress_Should_ValidateIfThereIsCountryOrStateFilled(string country, string state)
        {
            // Arrange
            var model = new AddressModel()
            {
                Street = "some street",
                StreetNumber = 123
            };
            
            // Act
            var result = model.IsValid();

            // Assert
            Assert.False(result);
        }
    }
}