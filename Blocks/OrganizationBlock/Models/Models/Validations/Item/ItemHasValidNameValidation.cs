using Dharma.Core;

namespace Dharma.OrganizationBlock.Models.Validations.Item
{
    internal class ItemHasValidNameValidation : BaseValidation<ItemModel>
    {
        public override void Validate(ItemModel model)
        {
            if (string.IsNullOrEmpty(model.Name?.Trim()))
                model.ValidationResult.Add("Invalid Name");
        }
    }
}