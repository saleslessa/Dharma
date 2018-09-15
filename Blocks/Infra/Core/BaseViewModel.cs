using System.Collections.Generic;

namespace Dharma.Core
{
    public abstract class BaseViewModel
    {
        protected abstract ValidationResult ValidationResult { get; set; }

        public bool IsValid()
        {
            return ValidationResult.IsValid();
        }

        public IEnumerable<string> ListAllErrors()
        {
            return ValidationResult.ListAll();
        }
        
        public void SetValidationResult(ValidationResult validationResult)
        {
            ValidationResult = validationResult;
        }
    }
}