#region

using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

#endregion

namespace KKTServiceLib.Shared.Types.ValidationAttributes
{
    /// <summary>
    /// Атрибут валидации сложного объекта
    /// </summary>
    public class ComplexObjectValidationAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value == null)
            {
                return ValidationResult.Success;
            }

            var validationResults = new List<ValidationResult>();
            var objectValidationContext = new ValidationContext(value);
            Validator.TryValidateObject(value, objectValidationContext, validationResults, true);

            return validationResults.Any()
                ? new ValidationResult(string.Format(ErrorMessageString, validationContext.DisplayName) +
                                       validationResults.Aggregate(string.Empty,
                                           (current, c) => current + "\n\t" + c.ErrorMessage))
                : ValidationResult.Success;
        }
    }
}