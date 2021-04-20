#region

using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.RegularExpressions;
using KKTServiceLib.Shared.Helpers;
using KKTServiceLib.Shared.Resources;

#endregion

namespace KKTServiceLib.Shared.Types.ValidationAttributes
{
    /// <summary>
    /// Атрибут валидации коллекции строк по регулярному выражению
    /// </summary>
    public class RegularExpressionCollectionValidationAttribute : ValidationAttribute
    {
        /// <summary>
        /// Атрибут валидации коллекции строк по регулярному выражению
        /// </summary>
        /// <param name="pattern">Регулярное выражение</param>
        public RegularExpressionCollectionValidationAttribute(string pattern)
        {
            Pattern = pattern;
        }

        /// <summary>
        /// Регулярное выражение
        /// </summary>
        public string Pattern { get; }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (!(value is IEnumerable<string> collectionToCheck))
                return ValidationResult.Success;

            var index = 0;

            var invalidIndexes = new List<int>(collectionToCheck.Count());

            foreach (var str in collectionToCheck)
            {
                if (!Regex.IsMatch(str, Pattern))
                {
                    invalidIndexes.Add(index);
                }

                index++;
            }

            return invalidIndexes.Any()
                ? new ValidationResult(string.Format(
                    ErrorStrings.ResourceManager.GetString("RegularExpressionCollectionValidationError"),
                    validationContext.DisplayName, string.Join(", ", invalidIndexes)))
                : ValidationResult.Success;
        }
    }
}