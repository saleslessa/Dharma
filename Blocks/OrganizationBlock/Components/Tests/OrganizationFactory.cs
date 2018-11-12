using System.Collections.Generic;
using Dharma.OrganizationBlock.Models;

namespace Dharma.OrganizationBlock.Components.Tests
{
    internal static class OrganizationFactory
    {
        public static IEnumerable<OrganizationModel> GetListOfValidOrganizations(uint amount)
        {
            var result = new List<OrganizationModel>();

            for (uint i = 0; i < amount; i++)
            {
                result.Add(new OrganizationModel()
                {
                    Name = $"Something {i}",
                    Active = true,
                    Address = new AddressModel()
                    {
                        Street = $"Some street {i}",
                        AdditionalInfo = $"Some additional info {i}",
                        StreetNumber = i
                    },
                    Owners = new List<OwnerModel>()
                    {
                        new OwnerModel()
                        {
                            Name = $"Owner {i}",
                            Phone = $"Some phone {i}",
                            DocumentIdentification = $"Some document {i}"
                        }
                    },
                    PhoneNumber = $"Phone number {i}",
                    ItemsNeeded = new List<ItemModel>()
                    {
                        new ItemModel()
                        {
                            Amount = 2,
                            Name = $"Some item needed {i}"
                        }
                    }
                });
            }

            return result;
        }
    }
}