using Dharma.Core;

namespace Dharma.OrganizationBlock.Models.Validations.Address
{
    internal class AddressHasValidStateProvinceValidation : BaseValidation<AddressModel>
    {
        public override void Validate(AddressModel model)
        {
            if (string.IsNullOrEmpty(model.StateProvince?.Trim()))
                model.ValidationResult.Add("Invalid Country");
        }
    }
}