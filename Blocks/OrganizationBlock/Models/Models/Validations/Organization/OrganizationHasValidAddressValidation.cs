using System.Linq;
using Dharma.Core;

namespace Dharma.OrganizationBlock.Models.Validations.Organization
{
    internal class OrganizationHasValidAddressValidation : BaseValidation<OrganizationModel>
    {
        public override void Validate(OrganizationModel model)
        {
            if (model.Address == null)
            {
                model.ValidationResult.Add("Address missing");
                return;
            }

            if (!model.Address.IsValid())
                model.Address.ValidationResult.ListAll().ToList().ForEach(t => model.ValidationResult.Add(t));

        }
    }
}