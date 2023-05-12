using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;
using KKTServiceLib.Atol.Types.Enums;
using KKTServiceLib.Shared.Helpers;
using KKTServiceLib.Shared.Resources;
using KKTServiceLib.Shared.Types.ValidationAttributes;

namespace KKTServiceLib.Atol.Types.Common.MarkingCodes
{
    [Description("Код маркировки (ФФД ≥ 1.2)")]
    public class MarkingCodeParams_12
    {
        /// <summary>
        /// Регулярное выражение для дробного числа
        /// </summary>
        private const string ItemFractionalAmountPattern = @"^[1-9][0-9]*/[1-9][0-9]*$";

        /// <summary>
        /// Код маркировки используется для позиции
        /// </summary>
        public bool IsPositionMarkingCodeParams { get; }

        /// <summary>
        /// Код маркировки (ФФД ≥ 1.2) для позиции
        /// </summary>
        /// <param name="imc">Base64-представление значения кода маркировки</param>
        /// <param name="imcModeProcessing">Режим обработки кода товара</param>
        /// <param name="imcType">Тип кода маркировки</param>
        /// <param name="itemEstimatedStatus">Планируемый статус КМ</param>
        /// <param name="itemInfoCheckResult">Результат проверки сведений о товаре</param>
        public MarkingCodeParams_12(string imc, int imcModeProcessing, ImcType imcType,
            ItemEstimatedStatus itemEstimatedStatus,
            ItemInfoCheckResult itemInfoCheckResult = null)
        {
            if (imc.IsNullOrEmptyOrWhiteSpace() || !Regex.IsMatch(imc, RegexHelper.Base64Pattern))
            {
                throw new ArgumentException(
                    string.Format(ErrorStrings.ResourceManager.GetString("StringFormatError"),
                        GetType().GetProperty(nameof(Imc)).GetDisplayName()),
                    nameof(imc));
            }

            Imc = imc;
            ImcModeProcessing = imcModeProcessing;
            ImcType = imcType;
            ItemEstimatedStatus = itemEstimatedStatus;
            ItemInfoCheckResult = itemInfoCheckResult;

            IsPositionMarkingCodeParams = true;
        }

        /// <summary>
        /// Код маркировки (ФФД ≥ 1.2) для проверки
        /// </summary>
        /// <param name="imc">Base64-представление значения кода маркировки</param>
        /// <param name="imcModeProcessing">Режим обработки кода товара</param>
        /// <param name="imcType">Тип кода маркировки</param>
        /// <param name="itemUnits">Мера количества товара</param>
        /// <param name="itemQuantity">Количество товара</param>
        /// <param name="itemFractionalAmount">Дробное количество маркированного товара</param>
        public MarkingCodeParams_12(string imc, int imcModeProcessing, ImcType imcType,
            ItemEstimatedStatus? itemEstimatedStatus = null, ItemUnitType? itemUnits = null,
            int? itemQuantity = null, string itemFractionalAmount = null)
        {
            if (imc.IsNullOrEmptyOrWhiteSpace() || !Regex.IsMatch(imc, RegexHelper.Base64Pattern))
            {
                throw new ArgumentException(
                    string.Format(ErrorStrings.ResourceManager.GetString("StringFormatError"),
                        GetType().GetProperty(nameof(Imc)).GetDisplayName()),
                    nameof(imc));
            }

            if (itemQuantity != null && itemUnits != null &&
                !(itemEstimatedStatus == Enums.ItemEstimatedStatus.ItemDryForSale ||
                  itemEstimatedStatus == Enums.ItemEstimatedStatus.ItemDryReturn))
            {
                throw new ArgumentOutOfRangeException(nameof(itemEstimatedStatus), string.Format(
                    ErrorStrings.ResourceManager.GetString("MustBeEqualError"),
                    GetType().GetProperty(nameof(ItemEstimatedStatus)).GetDisplayName(),
                    $"{Enums.ItemEstimatedStatus.ItemDryForSale.GetDisplayName()}, {Enums.ItemEstimatedStatus.ItemDryReturn.GetDisplayName()}"));
            }

            if (itemQuantity < 0)
            {
                throw new ArgumentException(
                    string.Format(ErrorStrings.ResourceManager.GetString("DigitRangeValuesError"),
                        GetType().GetProperty(nameof(ItemQuantity)).GetDisplayName(), 0, int.MaxValue),
                    nameof(itemQuantity));
            }

            if (!itemFractionalAmount.IsNullOrEmptyOrWhiteSpace())
            {
                var isItemFractionalAmountValid = true;

                if (!Regex.IsMatch(itemFractionalAmount, ItemFractionalAmountPattern))
                {
                    isItemFractionalAmountValid = false;
                }
                else
                {
                    var itemFractionalAmountValues = itemFractionalAmount.Split('/');

                    if (int.Parse(itemFractionalAmountValues[0]) >= int.Parse(itemFractionalAmountValues[1]))
                    {
                        isItemFractionalAmountValid = false;
                    }
                }

                if (!isItemFractionalAmountValid)
                {
                    throw new ArgumentException(
                        string.Format(
                            ErrorStrings.ResourceManager.GetString("StringFormatError"),
                            GetType().GetProperty(nameof(ItemFractionalAmount)).GetDisplayName()),
                        nameof(itemFractionalAmount));
                }
            }

            Imc = imc;
            ImcModeProcessing = imcModeProcessing;
            ImcType = imcType;
            ItemEstimatedStatus = itemEstimatedStatus;
            ItemQuantity = itemQuantity;
            ItemFractionalAmount = itemFractionalAmount;
            ItemUnits = itemUnits;

            IsPositionMarkingCodeParams = false;
        }

        /// <summary>
        /// Тип кода маркировки
        /// </summary>
        /// <list type="bullet">
        /// <item>Обязательное поле</item>
        /// </list>
        [Display(Name = "Тип кода маркировки")]
        public ImcType ImcType { get; }

        /// <summary>
        /// Base64-представление значения кода маркировки
        /// </summary>
        /// <list type="bullet">
        /// <item>Обязательное поле</item>
        /// <item>Должно соответствовать регулярному выражению <see cref="RegexHelper.Base64Pattern"/></item>
        /// </list>
        [Display(Name = "base64-представление значения кода маркировки")]
        [Required(ErrorMessageResourceType = typeof(ErrorStrings), ErrorMessageResourceName = "RequiredError")]
        [RegularExpression(RegexHelper.Base64Pattern, ErrorMessageResourceType = typeof(ErrorStrings),
            ErrorMessageResourceName = "StringFormatError")]
        public string Imc { get; }

        /// <summary>
        /// Планируемый статус КМ
        /// </summary>
        /// <list type="bullet">
        /// <item>Обязательное поле если используется для КМ в позициях</item>
        /// </list>
        [Display(Name = "Планируемый статус КМ")]
        [RequiredIfValidation(nameof(IsPositionMarkingCodeParams), true,
            ErrorMessageResourceType = typeof(ErrorStrings), ErrorMessageResourceName = "RequiredError")]
        public ItemEstimatedStatus? ItemEstimatedStatus { get; }

        /// <summary>
        /// Режим обработки кода товара
        /// </summary>
        /// <list type="bullet">
        /// <item>Обязательное поле</item>
        /// </list>
        [Display(Name = "Режим обработки кода товара")]
        [Required(ErrorMessageResourceType = typeof(ErrorStrings), ErrorMessageResourceName = "RequiredError")]
        public int ImcModeProcessing { get; }

        /// <summary>
        /// Дробное количество маркированного товара
        /// </summary>
        /// <list type="bullet">
        /// <item>Должно соответствовать регулярному выражению <see cref="ItemFractionalAmountPattern"/></item>
        /// </list>
        [Display(Name = "Дробное количество маркированного товара")]
        [RegularExpression(ItemFractionalAmountPattern, ErrorMessageResourceType = typeof(ErrorStrings),
            ErrorMessageResourceName = "StringFormatError")]
        public string ItemFractionalAmount { get; }

        /// <summary>
        /// Идентификатор маркированного товара
        /// </summary>
        /// <list type="bullet">
        /// <item>Должно соответствовать регулярному выражению <see cref="RegexHelper.Base64Pattern"/></item>
        /// </list>
        [Display(Name = "Идентификатор маркированного товара")]
        [RegularExpression(RegexHelper.Base64Pattern, ErrorMessageResourceType = typeof(ErrorStrings),
            ErrorMessageResourceName = "StringFormatError")]
        public string ImcBarcode { get; set; }

        /// <summary>
        /// Результат проверки сведений о товаре
        /// </summary>
        [Display(Name = "Результат проверки сведений о товаре")]
        public ItemInfoCheckResult ItemInfoCheckResult { get; }

        /// <summary>
        /// Количество товара
        /// </summary>
        /// <list type="bullet">
        /// <item>Обязательное поле если используется для проверки КМ</item>
        /// <item>Должно лежать в диапазоне: 0-<see cref="int.MaxValue"/></item>
        /// </list>
        [Display(Name = "Количество товара")]
        [RequiredIfValidation(nameof(IsPositionMarkingCodeParams), false,
            ErrorMessageResourceType = typeof(ErrorStrings), ErrorMessageResourceName = "RequiredError")]
        [Range(0, int.MaxValue, ErrorMessageResourceType = typeof(ErrorStrings),
            ErrorMessageResourceName = "DigitRangeValuesError")]
        public int? ItemQuantity { get; }

        /// <summary>
        /// Мера количества товара
        /// </summary>
        /// <list type="bullet">
        /// <item>Обязательное поле если используется для проверки КМ</item>
        /// </list>
        [Display(Name = "Мера количества товара")]
        [RequiredIfValidation(nameof(IsPositionMarkingCodeParams), false,
            ErrorMessageResourceType = typeof(ErrorStrings), ErrorMessageResourceName = "RequiredError")]
        public ItemUnitType? ItemUnits { get; }

        /// <summary>
        /// Не отправлять запрос на сервер
        /// </summary>
        /// <remarks>
        /// Значение по умолчанию: false
        /// </remarks>
        [Display(Name = "Не отправлять запрос на сервер")]
        public bool NotSendToServer { get; set; } = false;
    }
}