using System.Linq;
using Dharma.Core;

namespace Dharma.OrganizationBlock.Models.Validations.Organization
{
    internal class OrganizationHasValidAddressValidation : BaseValidation<OrganizationModel>
    {
        public override void Validate(OrganizationModel model)
        {
            if (model.AddressModel == null)
            {
                model.ValidationResult.Add("Address missing");
                return;
            }

            if (!model.AddressModel.IsValid())
                model.AddressModel.ValidationResult.ListAll().ToList().ForEach(t => model.ValidationResult.Add(t));

        }
    }
}