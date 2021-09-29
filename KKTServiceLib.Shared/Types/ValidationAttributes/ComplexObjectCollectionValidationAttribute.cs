#region

using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using KKTServiceLib.Shared.Resources;

#endregion

namespace KKTServiceLib.Shared.Types.ValidationAttributes
{
    /// <summary>
    /// Атрибут валидации коллекции сложных объектов
    /// </summary>
    public class ComplexObjectCollectionValidationAttribute : ValidationAttribute
    {
        /// <summary>
        /// Разрешить объекты, равные null
        /// </summary>
        /// <remarks>
        /// Значение по умолчанию: true
        /// </remarks>
        public bool AllowNullItems { get; set; } = true;

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (!(value is IEnumerable collectionToCheck))
            {
                return ValidationResult.Success;
            }

            var index = 0;
            var validationResults = new List<ValidationResult>();

            foreach (var item in collectionToCheck)
            {
                if (item == null && !AllowNullItems)
                {
                    validationResults.Add(new ValidationResult(string.Format(
                        ErrorStrings.ResourceManager.GetString(
                            "ComplexObjectCollectionValidationError_Index"),
                        index) + ErrorStrings.ResourceManager.GetString(
                        "ComplexObjectCollectionValidationError_ContainsNull")));
                }
                else
                {
                    var itemValidationResults = new List<ValidationResult>();
                    var itemValidationContext = new ValidationContext(item);
                    Validator.TryValidateObject(item, itemValidationContext, itemValidationResults, true);

                    foreach (var vr in itemValidationResults)
                    {
                        vr.ErrorMessage =
                            string.Format(
                                ErrorStrings.ResourceManager.GetString("ComplexObjectCollectionValidationError_Index"),
                                index) + vr.ErrorMessage;
                    }

                    validationResults.AddRange(itemValidationResults);
                }

                index++;
            }

            return validationResults.Any()
                ? new ValidationResult(string.Format(ErrorMessageString, validationContext.DisplayName) +
                                       validationResults.Aggregate(string.Empty,
                                           (current, c) => current + "\n\t" + c.ErrorMessage.Replace("\n\t", "\n\t\t")))
                : ValidationResult.Success;
        }
    }
}