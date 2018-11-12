using Dharma.Core;

namespace Dharma.OrganizationBlock.Models
{
    internal class AddressModel : BaseModel
    {
        public string Street { get; set; }
        
        public uint StreetNumber { get; set; }
        
        public string AdditionalInfo { get; set; } 
        
        public double Latitude { get; set; }
        
        public double Longitude { get; set; }

        protected override void Validate()
        {
        }
    }
}