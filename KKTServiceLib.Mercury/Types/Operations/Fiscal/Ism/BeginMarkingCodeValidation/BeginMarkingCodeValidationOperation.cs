#region

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using System.Text.RegularExpressions;
using CoreLib.CORE.Helpers.EnumHelpers;
using CoreLib.CORE.Helpers.ObjectHelpers;
using CoreLib.CORE.Helpers.StringHelpers;
using CoreLib.CORE.Helpers.ValidationHelpers.Attributes;
using CoreLib.CORE.Resources;
using KKTServiceLib.Mercury.Types.Common.MarkingCodes;
using KKTServiceLib.Mercury.Types.Converters;
using KKTServiceLib.Mercury.Types.Enums;
using KKTServiceLib.Shared.Resources;

#endregion

namespace KKTServiceLib.Mercury.Types.Operations.Fiscal.Ism.BeginMarkingCodeValidation
{
    [Description("Проверка кода маркировки")]
    public class BeginMarkingCodeValidationOperation: Operation<BeginMarkingCodeValidationResult>
    {
        /// <summary>
        /// Проверка кода маркировки
        /// </summary>
        /// <param name="imc">Base64-представление значения кода маркировки</param>
        /// <param name="itemEstimatedStatus">Режим обработки кода товара</param>
        /// <param name="itemUnits">Мера количества товара</param>
        /// <param name="quantity">Количество товара</param>
        public BeginMarkingCodeValidationOperation(string imc, ItemEstimatedStatus itemEstimatedStatus,
            ItemUnitType itemUnits,
            int quantity): base("CheckMarkingCode")
        {
            if (imc.IsNullOrEmptyOrWhiteSpace() || !Regex.IsMatch(imc, RegexExtensions.Base64Pattern))
            {
                throw new ArgumentException(
                    string.Format(ValidationStrings.ResourceManager.GetString("StringFormatError"),
                        GetType().GetProperty(nameof(Mc)).GetPropertyDisplayName()),
                    nameof(imc));
            }

            if (quantity < 0.001 || quantity > 214748)
            {
                throw new ArgumentException(
                    string.Format(ValidationStrings.ResourceManager.GetString("DigitRangeValuesError"),
                        GetType().GetProperty(nameof(Qty)).GetPropertyDisplayName(), 0.001, 214748),
                    nameof(quantity));
            }

            Mc = imc;
            PlannedStatus = itemEstimatedStatus;
            MeasureUnit = itemUnits;
            Qty = quantity;
        }

        /// <summary>
        /// Проверка кода маркировки
        /// </summary>
        /// <param name="imc">Base64-представление значения кода маркировки</param>
        /// <param name="itemEstimatedStatus">Режим обработки кода товара. Допустимые значения: <see cref="ItemEstimatedStatus.ItemDryForSale"/>, <see cref="ItemEstimatedStatus.ItemDryReturn"/></param>
        /// <param name="itemFractionalAmount">Дробное количество маркированного товара</param>
        public BeginMarkingCodeValidationOperation(string imc, ItemEstimatedStatus itemEstimatedStatus,
            FractionalNumber itemFractionalAmount): base("CheckMarkingCode")
        {
            if (imc.IsNullOrEmptyOrWhiteSpace() || !Regex.IsMatch(imc, RegexExtensions.Base64Pattern))
            {
                throw new ArgumentException(
                    string.Format(ValidationStrings.ResourceManager.GetString("StringFormatError"),
                        GetType().GetProperty(nameof(Mc)).GetPropertyDisplayName()),
                    nameof(imc));
            }

            if (!(itemEstimatedStatus == ItemEstimatedStatus.ItemDryForSale ||
                  itemEstimatedStatus == ItemEstimatedStatus.ItemDryReturn))
            {
                throw new ArgumentOutOfRangeException(nameof(itemEstimatedStatus), string.Format(
                    ErrorStrings.ResourceManager.GetString("MustBeEqualError"),
                    GetType().GetProperty(nameof(PlannedStatus)).GetPropertyDisplayName(),
                    $"{ItemEstimatedStatus.ItemDryForSale.GetDisplayName()}, {ItemEstimatedStatus.ItemDryReturn.GetDisplayName()}"));
            }

            Mc = imc;
            PlannedStatus = itemEstimatedStatus;
            MeasureUnit = ItemUnitType.Piece;
            Qty = 1;
            Part = itemFractionalAmount ?? throw new ArgumentNullException(nameof(itemFractionalAmount));
        }

        /// <summary>
        /// Base64-представление значения кода маркировки
        /// </summary>
        /// <list type="bullet">
        /// <item>Обязательное поле</item>
        /// <item>Должно соответствовать регулярному выражению <see cref="RegexExtensions.Base64Pattern"/></item>
        /// </list>
        [Display(Name = "base64-представление значения кода маркировки")]
        [Required(ErrorMessageResourceType = typeof(ValidationStrings), ErrorMessageResourceName = "RequiredError")]
        [RegularExpression(RegexExtensions.Base64Pattern, ErrorMessageResourceType = typeof(ValidationStrings),
            ErrorMessageResourceName = "StringFormatError")]
        public string Mc { get; }

        /// <summary>
        /// Планируемый статус КМ
        /// </summary>
        /// <list type="bullet">
        /// <item>Обязательное поле</item>
        /// </list>
        [Display(Name = "Планируемый статус КМ")]
        [Required(ErrorMessageResourceType = typeof(ValidationStrings), ErrorMessageResourceName = "RequiredError")]
        public ItemEstimatedStatus PlannedStatus { get; }

        /// <summary>
        /// Количество товара
        /// </summary>
        /// <list type="bullet">
        /// <item>Обязательное поле</item>
        /// <item>Должно лежать в диапазоне: 0.001-214748</item>
        /// </list>
        [Required(ErrorMessageResourceType = typeof(ValidationStrings), ErrorMessageResourceName = "RequiredError")]
        [Range(0.001, 214748, ErrorMessageResourceType = typeof(ValidationStrings),
            ErrorMessageResourceName = "DigitRangeValuesError")]
        [Display(Name = "Количество товара")]
        [JsonConverter(typeof(QuantityConverter))]
        public double Qty { get; }

        /// <summary>
        /// Мера количества товара
        /// </summary>
        /// <list type="bullet">
        /// <item>Обязательное поле</item>
        /// </list>
        [Display(Name = "Мера количества товара")]
        public ItemUnitType MeasureUnit { get; }

        /// <summary>
        /// Режим обработки кода товара (в ФФД 1.2 допустима передача только значения 0)
        /// </summary>
        /// <remarks>
        /// Значение по умолчанию: 0
        /// </remarks>
        [Display(Name = "Режим обработки кода товара")]
        public int? ProcessingMode { get; set; } = 0;

        /// <summary>
        /// Максимальное время ожидания проверки кода маркировки ОИСМ в секундах
        /// </summary>
        /// <remarks>
        /// Значение по умолчанию: 30
        /// </remarks>
        [Display(Name = "Максимальное время ожидания проверки кода маркировки ОИСМ в секундах")]
        public byte? Timeout { get; set; } = 30;

        /// <summary>
        /// Дробное количество маркированного товара, выраженное в виде правильной дроби
        /// </summary>
        [Display(Name = "Дробное количество маркированного товара, выраженное в виде правильной дроби")]
        [ComplexObjectValidation(ErrorMessageResourceType = typeof(ValidationStrings),
            ErrorMessageResourceName = "ComplexObjectValidationError")]
        public FractionalNumber Part { get; }

        public override IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (Part != null)
            {
                if (Qty != 1)
                {
                    yield return new ValidationResult(string.Format(
                        ErrorStrings.ResourceManager.GetString("MustBeEqualError"),
                        GetType().GetProperty(nameof(Qty)).GetPropertyDisplayName(), 1), new[] { nameof(Qty) });
                }

                if (MeasureUnit != ItemUnitType.Piece)
                {
                    yield return new ValidationResult(string.Format(
                            ErrorStrings.ResourceManager.GetString("MustBeEqualError"),
                            GetType().GetProperty(nameof(Qty)).GetPropertyDisplayName(),
                            ItemUnitType.Piece.GetDisplayName()),
                        new[] { nameof(Qty) });
                }

                if (!(PlannedStatus == ItemEstimatedStatus.ItemDryForSale ||
                      PlannedStatus == ItemEstimatedStatus.ItemDryReturn))
                {
                    yield return new ValidationResult(string.Format(
                            ErrorStrings.ResourceManager.GetString("MustBeEqualError"),
                            GetType().GetProperty(nameof(PlannedStatus)).GetPropertyDisplayName(),
                            $"{ItemEstimatedStatus.ItemDryForSale.GetDisplayName()}, {ItemEstimatedStatus.ItemDryReturn.GetDisplayName()}"),
                        new[] { nameof(PlannedStatus) });
                }

                foreach (var vr in Part.Validate(validationContext))
                {
                    yield return vr;
                }
            }
        }
    }
}