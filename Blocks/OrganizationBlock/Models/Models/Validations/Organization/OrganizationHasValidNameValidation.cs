using Dharma.Core;

namespace Dharma.OrganizationBlock.Models.Validations.Organization
{
    internal class OrganizationHasValidNameValidation : BaseValidation<OrganizationModel>
    {
        public override void Validate(OrganizationModel model)
        {
            if (string.IsNullOrEmpty(model.Name?.Trim()))
                model.ValidationResult.Add("Invalid Name");
        }
    }
}