using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

namespace Dharma.OrganizationBlock.Models.Tests
{
    [TestFixture]
    public class OrganizationModelTests
    {
        [Test]
        public void OrganizationWithInvalidAddress_Should_HaveAllAddressValidationErrors()
        {
            // Arrange
            var model = new OrganizationModel()
            {
                Address = new AddressModel()
            };
            
            // Act
            var result = model.IsValid();

            // Assert
            Assert.False(result);

            foreach (var error in model.Address.ValidationResult.Errors)
            {
                Assert.AreNotEqual(model.ValidationResult.FindByKey(error.Key), null);
            }
        }

        [Test]
        public void OrganizationWithNullAddress_Should_NotThrowErrorWhenValidate()
        {
            // Arrange
            var model = new OrganizationModel()
            {
                Address = null
            };
            
            // Act
            var result = model.IsValid();

            // Assert
            Assert.False(result);
            Assert.AreNotEqual(model.ValidationResult.FindByMessage("Address missing"), null);
        }

        [Test]
        public void OrganizationWithNullOwner_Should_NotThrowErrorWhenValidate()
        {
            // Arrange
            var model = new OrganizationModel()
            {
                Owners = null
            };
            
            // Act
            var result = model.IsValid();

            // Assert
            Assert.False(result);
            Assert.AreNotEqual(model.ValidationResult.FindByMessage("Owner missing"), null);
        }

        [Test]
        public void OrganizationWithNoOwner_Should_ValidateAsInvalid()
        {
            // Arrange
            var model = new OrganizationModel()
            {
                Owners = new List<OwnerModel>()
            };
            
            // Act
            var result = model.IsValid();

            // Assert
            Assert.False(result);
            Assert.AreNotEqual(model.ValidationResult.FindByMessage("Owner missing"), null);
        }

        [Test]
        public void OrganizationWithNoItem_Should_ValidateAsValid()
        {
            // Arrange
            var modelWithNoItem = new OrganizationModel()
            {
                ItemsNeeded = new List<ItemModel>(),
                Owners = new List<OwnerModel>(){ new OwnerModel() { Name = "a", Phone = "b", DocumentIdentification = "c"}},
                Address = new AddressModel(){Country = "a", Street = "b", AdditionalInfo = "v", StateProvince = "c", StreetNumber = 2},
                Name = "q", PhoneNumber = "123"
            };
            var modelWithNullItem = new OrganizationModel()
            {
                ItemsNeeded = null,
                Owners = new List<OwnerModel>(){ new OwnerModel() { Name = "a", Phone = "b", DocumentIdentification = "c"}},
                Address = new AddressModel(){Country = "a", Street = "b", AdditionalInfo = "v", StateProvince = "c", StreetNumber = 2},
                Name = "q", PhoneNumber = "123"
            };
            
            // Act
            var resultNoItem = modelWithNoItem.IsValid();
            var resultNullItem = modelWithNullItem.IsValid();

            // Assert
            Assert.True(resultNoItem);
            Assert.True(resultNullItem);
        }

        [TestCase("")]
        [TestCase(" ")]
        public void OrganizationWithValidName_Should_Validate(string param)
        {
            // Arrange
            var model = new OrganizationModel()
            {
                Name = param
            };
            
            // Act
            var result = model.IsValid();

            // Assert
            Assert.False(result);
            Assert.AreNotEqual(model.ValidationResult.Errors.SingleOrDefault(t => t.Value == "Invalid Name"), null);
        }
    }
}