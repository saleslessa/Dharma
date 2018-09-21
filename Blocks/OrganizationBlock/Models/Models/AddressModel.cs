using System;
using Dharma.Core;
using Dharma.OrganizationBlock.Models.Validations.Address;

namespace Dharma.OrganizationBlock.Models
{
    internal class AddressModel : BaseModel
    {
        public string Street { get; set; }
        
        public uint StreetNumber { get; set; }
        
        public string AdditionalInfo { get; set; } 
        
        public string StateProvince { get; set; }
        
        public string Country { get; set; }

        protected override void Validate()
        {
            new AddressHasValidStateProvinceValidation().Validate(this);
            new AddressHasValidCountryValidation().Validate(this);
        }
    }
}