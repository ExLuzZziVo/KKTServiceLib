using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using KKTServiceLib.Shared.Helpers;
using KKTServiceLib.Shared.Resources;

namespace KKTServiceLib.Mercury.Types.Common.MarkingCodes
{
    [Description("Дробное число")]
    public class FractionalNumber
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
                    string.Format(ErrorStrings.ResourceManager.GetString("DigitRangeValuesError"),
                        GetType().GetProperty(nameof(Denominator)).GetDisplayName(), 2, int.MaxValue),
                    nameof(denominator));
            }

            if (numerator < 1 || numerator >= denominator)
            {
                throw new ArgumentException(
                    string.Format(ErrorStrings.ResourceManager.GetString("DigitRangeValuesError"),
                        GetType().GetProperty(nameof(Numerator)).GetDisplayName(), 1,
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
        [Required(ErrorMessageResourceType = typeof(ErrorStrings), ErrorMessageResourceName = "RequiredError")]
        [Range(1, int.MaxValue - 1, ErrorMessageResourceType = typeof(ErrorStrings),
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
        [Required(ErrorMessageResourceType = typeof(ErrorStrings), ErrorMessageResourceName = "RequiredError")]
        [Range(2, int.MaxValue, ErrorMessageResourceType = typeof(ErrorStrings),
            ErrorMessageResourceName = "DigitRangeValuesError")]
        [Display(Name = "Знаменатель дроби")]
        public int Denominator { get; }

        internal IEnumerable<ValidationResult> Validate()
        {
            var validationResults = new List<ValidationResult>(1);

            if (Numerator >= Denominator)
            {
                validationResults.Add(new ValidationResult(
                    string.Format(ErrorStrings.ResourceManager.GetString("DigitRangeValuesError"),
                        GetType().GetProperty(nameof(Numerator)).GetDisplayName(), 1,
                        Numerator == Denominator ? Denominator - 1 : Denominator - 2)));
            }

            return validationResults;
        }
    }
}