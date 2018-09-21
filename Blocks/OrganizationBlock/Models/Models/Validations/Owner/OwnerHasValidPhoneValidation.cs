using Dharma.Core;

namespace Dharma.OrganizationBlock.Models.Validations.Owner
{
    internal class OwnerHasValidPhoneValidation : BaseValidation<OwnerModel>
    {
        public override void Validate(OwnerModel model)
        {
            if (string.IsNullOrEmpty(model.Phone?.Trim()))
                model.ValidationResult.Add("Invalid Phone");
        }
    }
}