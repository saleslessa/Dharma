using Dharma.Core;

namespace Dharma.OrganizationBlock.Models.Validations.Address
{
    internal class AddressHasValidCountryValidation : BaseValidation<AddressModel>
    {
        public override void Validate(AddressModel model)
        {
            if (string.IsNullOrEmpty(model.Country?.Trim()))
                model.ValidationResult.Add("Invalid State/Province");
        }
    }
}