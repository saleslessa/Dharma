using System;
using Dharma.Core;
using Dharma.OrganizationBlock.Models.Validations.Item;

namespace Dharma.OrganizationBlock.Models
{
    internal class ItemModel : BaseModel
    {
		
        public string Name { get; set; }
        
        public uint Amount { get; set; }
		
        protected override void Validate()
        {
            new ItemHasValidNameValidation().Validate(this);
        }
    }
}