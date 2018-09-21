using Dharma.Core;

namespace Dharma.OrganizationBlock.Models.Validations.Owner
{
    internal class OwnerHasValidDocumentIdentificationValidation : BaseValidation<OwnerModel>
    {
        public override void Validate(OwnerModel model)
        {
            if (string.IsNullOrEmpty(model.DocumentIdentification?.Trim()))
                model.ValidationResult.Add("Invalid Document Identification");
        }
    }
}