using Dharma.Core;

namespace Dharma.OrganizationBlock.Models.Validations.Owner
{
    internal class OwnerHasValidNameValidation : BaseValidation<OwnerModel>
    {
        public override void Validate(OwnerModel model)
        {
            if (string.IsNullOrEmpty(model.Name?.Trim()))
                model.ValidationResult.Add("Invalid Name");
        }
    }
}