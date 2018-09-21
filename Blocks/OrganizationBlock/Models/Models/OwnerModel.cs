using System.ComponentModel.DataAnnotations;
using Dharma.Core;
using Dharma.OrganizationBlock.Models.Validations.Owner;

namespace Dharma.OrganizationBlock.Models
{
    internal class OwnerModel : BaseModel
    {
        [Required]
        public string Name { get; set; }
        
        [Required]
        public string Phone { get; set; }
        
        public string DocumentIdentification { get; set; }
        
        protected override void Validate()
        {
            new OwnerHasValidNameValidation().Validate(this);
            new OwnerHasValidPhoneValidation().Validate(this);
            new OwnerHasValidDocumentIdentificationValidation().Validate(this);
        }
    }
}