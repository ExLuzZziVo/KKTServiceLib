#region

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using CoreLib.CORE.Helpers.ObjectHelpers;
using CoreLib.CORE.Resources;

#endregion

namespace KKTServiceLib.Mercury.Types.Common.MarkingCodes
{
    [Description("Дробное число")]
    public class FractionalNumber : IValidatableObject
    {
        /// <summary>
        /// Дробное число
        /// </summary>
        /// <param name="numerator">Числитель дроби</param>
        /// <param name="denominator">Знаменатель дроби</param>
        public FractionalNumber(int numerator, int denominator)
        {
            if (denominator < 2)
            {
                throw new ArgumentException(
                    string.Format(ValidationStrings.ResourceManager.GetString("DigitRangeValuesError"),
                        GetType().GetProperty(nameof(Denominator)).GetPropertyDisplayName(), 2, int.MaxValue),
                    nameof(denominator));
            }

            if (numerator < 1 || numerator >= denominator)
            {
                throw new ArgumentException(
                    string.Format(ValidationStrings.ResourceManager.GetString("DigitRangeValuesError"),
                        GetType().GetProperty(nameof(Numerator)).GetPropertyDisplayName(), 1,
                        numerator == denominator ? denominator - 1 : denominator - 2),
                    nameof(numerator));
            }

            Numerator = numerator;
            Denominator = denominator;
        }

        /// <summary>
        /// Числитель дроби
        /// </summary>
        /// <list type="bullet">
        /// <item>Обязательное поле</item>
        /// <item>Должно лежать в диапазоне: 1-(<see cref="int.MaxValue"/> - 1)</item>
        /// </list>
        [Required(ErrorMessageResourceType = typeof(ValidationStrings), ErrorMessageResourceName = "RequiredError")]
        [Range(1, int.MaxValue - 1, ErrorMessageResourceType = typeof(ValidationStrings),
            ErrorMessageResourceName = "DigitRangeValuesError")]
        [Display(Name = "Числитель дроби")]
        public int Numerator { get; }

        /// <summary>
        /// Знаменатель дроби
        /// </summary>
        /// <list type="bullet">
        /// <item>Обязательное поле</item>
        /// <item>Должно лежать в диапазоне: 2-<see cref="int.MaxValue"/></item>
        /// </list>
        [Required(ErrorMessageResourceType = typeof(ValidationStrings), ErrorMessageResourceName = "RequiredError")]
        [Range(2, int.MaxValue, ErrorMessageResourceType = typeof(ValidationStrings),
            ErrorMessageResourceName = "DigitRangeValuesError")]
        [Display(Name = "Знаменатель дроби")]
        public int Denominator { get; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (Numerator >= Denominator)
            {
                yield return new ValidationResult(
                    string.Format(ValidationStrings.ResourceManager.GetString("DigitRangeValuesError"),
                        GetType().GetProperty(nameof(Numerator)).GetPropertyDisplayName(), 1,
                        Numerator == Denominator ? Denominator - 1 : Denominator - 2), new[] { nameof(Numerator) });
            }
        }
    }
}