#region

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using CoreLib.CORE.Helpers.EnumHelpers;
using CoreLib.CORE.Helpers.ObjectHelpers;
using CoreLib.CORE.Helpers.StringHelpers;
using CoreLib.CORE.Helpers.ValidationHelpers.Attributes;
using CoreLib.CORE.Resources;
using KKTServiceLib.Mercury.Types.Common;
using KKTServiceLib.Mercury.Types.Common.Agent;
using KKTServiceLib.Mercury.Types.Common.MarkingCodes;
using KKTServiceLib.Mercury.Types.Converters;
using KKTServiceLib.Mercury.Types.Enums;
using KKTServiceLib.Shared.Helpers;
using KKTServiceLib.Shared.Resources;

#endregion

namespace KKTServiceLib.Mercury.Types.Operations.Fiscal.Receipt.AddPositionToOpenedCheck
{
    [Description("Добавление позиции в открытый фискальный чек")]
    public class AddPositionToOpenedCheckOperation: Operation<AddPositionToOpenedCheckResult>
    {
        /// <summary>
        /// Добавление позиции в открытый фискальный чек
        /// </summary>
        /// <param name="name">Наименование предмета расчета</param>
        /// <param name="price">Цена единицы предмета расчета</param>
        /// <param name="quantity">Количество предмета расчета</param>
        /// <param name="watType">Налоговая ставка</param>
        /// <param name="paymentMethodType">Способ расчета</param>
        /// <param name="paymentObjectType">Тип предмета расчета</param>
        public AddPositionToOpenedCheckOperation(string name, decimal price, double quantity, WatType watType,
            PaymentMethodType paymentMethodType, PaymentObjectType paymentObjectType): base("AddGoods")
        {
            if (name.IsNullOrEmptyOrWhiteSpace())
            {
                throw new ArgumentException(
                    string.Format(
                        ValidationStrings.ResourceManager.GetString("StringFormatError"),
                        GetType().GetProperty(nameof(ProductName)).GetPropertyDisplayName()),
                    nameof(name));
            }

            if (price < 0 || price > 21474836)
            {
                throw new ArgumentException(
                    string.Format(ValidationStrings.ResourceManager.GetString("DigitRangeValuesError"),
                        GetType().GetProperty(nameof(Price)).GetPropertyDisplayName(), 0, 21474836),
                    nameof(price));
            }

            if (quantity < 0.001 || quantity > 214748)
            {
                throw new ArgumentException(
                    string.Format(ValidationStrings.ResourceManager.GetString("DigitRangeValuesError"),
                        GetType().GetProperty(nameof(Qty)).GetPropertyDisplayName(), 0.001, 214748),
                    nameof(quantity));
            }

            ProductName = name;
            Price = price;
            Qty = quantity;
            TaxCode = watType;
            PaymentFormCode = paymentMethodType;
            ProductTypeCode = paymentObjectType;
        }

        /// <summary>
        /// Код товара (ФФД < 1.2)
        /// </summary>
        /// <remarks>
        /// Будет проигнорировано, если <see cref="MarkingCode"/> имеет значение
        /// </remarks>
        [Display(Name = "Код товара")]
        public string NomenclatureCode { get; set; }

        /// <summary>
        /// Маркировка товара (ФФД < 1.2)
        /// </summary>
        /// <remarks>
        /// Если этот параметр будет задан, то значение <see cref="NomenclatureCode"/> будет проигнорировано
        /// </remarks>
        [Display(Name = "Маркировка товара")]
        public string MarkingCode { get; set; }

        /// <summary>
        /// Информация о маркированном товаре (ФФД ≥ 1.2)
        /// </summary>
        [Display(Name = "Информация о маркированном товаре")]
        [ComplexObjectValidation(ErrorMessageResourceType = typeof(ValidationStrings),
            ErrorMessageResourceName = "ComplexObjectValidationError")]
        public MarkingCodeFullInfo McInfo { get; set; }

        /// <summary>
        /// Наименование предмета расчета
        /// </summary>
        /// <list type="bullet">
        /// <item>Обязательное поле</item>
        /// </list>
        [Required(ErrorMessageResourceType = typeof(ValidationStrings), ErrorMessageResourceName = "RequiredError")]
        [Display(Name = "Наименование предмета расчета")]
        public string ProductName { get; }

        /// <summary>
        /// Количество предмета расчета
        /// </summary>
        /// <list type="bullet">
        /// <item>Обязательное поле</item>
        /// <item>Должно лежать в диапазоне: 0.001-214748</item>
        /// </list>
        [Required(ErrorMessageResourceType = typeof(ValidationStrings), ErrorMessageResourceName = "RequiredError")]
        [Range(0.001, 214748, ErrorMessageResourceType = typeof(ValidationStrings),
            ErrorMessageResourceName = "DigitRangeValuesError")]
        [Display(Name = "Количество предмета расчета")]
        [JsonConverter(typeof(QuantityConverter))]
        public double Qty { get; }

        /// <summary>
        /// Мера количества товара (ФФД ≥ 1.2)
        /// </summary>
        [Display(Name = "Мера количества товара")]
        public ItemUnitType? MeasureUnit { get; set; }

        /// <summary>
        /// Номер отдела (секции)
        /// </summary>
        /// <list type="bullet">
        /// <item>Обязательное поле</item>
        /// <item>Должно лежать в диапазоне: 1-16</item>
        /// </list>
        /// <remarks>
        /// Значение по умолчанию: 1
        /// </remarks>
        [Range(1, 16, ErrorMessageResourceType = typeof(ValidationStrings),
            ErrorMessageResourceName = "DigitRangeValuesError")]
        [Display(Name = "Номер отдела (секции)")]
        public ushort? Section { get; set; } = 1;

        /// <summary>
        /// Налоговая ставка
        /// </summary>
        /// <list type="bullet">
        /// <item>Обязательное поле</item>
        /// </list>
        [Required(ErrorMessageResourceType = typeof(ValidationStrings), ErrorMessageResourceName = "RequiredError")]
        [Display(Name = "Налоговая ставка")]
        public WatType TaxCode { get; }

        /// <summary>
        /// Способ расчета
        /// </summary>
        /// <list type="bullet">
        /// <item>Обязательное поле</item>
        /// </list>
        [Required(ErrorMessageResourceType = typeof(ValidationStrings), ErrorMessageResourceName = "RequiredError")]
        [Display(Name = "Способ расчета")]
        public PaymentMethodType PaymentFormCode { get; }

        /// <summary>
        /// Тип предмета расчета
        /// </summary>
        /// <list type="bullet">
        /// <item>Обязательное поле</item>
        /// </list>
        [Required(ErrorMessageResourceType = typeof(ValidationStrings), ErrorMessageResourceName = "RequiredError")]
        [Display(Name = "Тип предмета расчета")]
        public PaymentObjectType ProductTypeCode { get; }

        /// <summary>
        /// Код страны происхождения
        /// </summary>
        /// <list type="bullet">
        /// <item>Должно соответствовать регулярному выражению <see cref="RegexHelper.CountryOfOriginCodePattern"/></item>
        /// </list>
        [RegularExpression(RegexHelper.CountryOfOriginCodePattern, ErrorMessageResourceType = typeof(ValidationStrings),
            ErrorMessageResourceName = "StringFormatError")]
        [Display(Name = "Код страны происхождения")]
        public string CountryOfOrigin { get; set; }

        /// <summary>
        /// Регистрационный номер таможенной декларации
        /// </summary>
        /// <list type="bullet">
        /// <item>Максимальная длина: 32</item>
        /// </list>
        [MaxLength(32, ErrorMessageResourceType = typeof(ValidationStrings),
            ErrorMessageResourceName = "StringMaxLengthError")]
        [Display(Name = "Регистрационный номер таможенной декларации")]
        public string CustomsDeclaration { get; set; }

        /// <summary>
        /// Дополнительный реквизит предмета расчета
        /// </summary>
        /// <list type="bullet">
        /// <item>Максимальная длина: 64</item>
        /// </list>
        [MaxLength(64, ErrorMessageResourceType = typeof(ValidationStrings),
            ErrorMessageResourceName = "StringMaxLengthError")]
        [Display(Name = "Дополнительный реквизит предмета расчета")]
        public string AdditionalAttribute { get; set; }

        /// <summary>
        /// Цена единицы предмета расчета
        /// </summary>
        /// <list type="bullet">
        /// <item>Обязательное поле</item>
        /// <item>Должно лежать в диапазоне: 0-21474836</item>
        /// </list>
        [Required(ErrorMessageResourceType = typeof(ValidationStrings), ErrorMessageResourceName = "RequiredError")]
        [Display(Name = "Цена единицы предмета расчета")]
        [JsonConverter(typeof(MoneyConverter))]
        [Range(0, 21474836, ErrorMessageResourceType = typeof(ValidationStrings),
            ErrorMessageResourceName = "DigitRangeValuesError")]
        public decimal Price { get; }

        /// <summary>
        /// Стоимость предмета расчета.
        /// Рассчитывается автоматически как <see cref="Price"/> * <see cref="Qty"/>
        /// </summary>
        /// <list type="bullet">
        /// <item>Должно лежать в диапазоне: 0-21474836</item>
        /// </list>
        [Display(Name = "Стоимость предмета расчета")]
        [JsonConverter(typeof(MoneyConverter))]
        [Range(0, 21474836, ErrorMessageResourceType = typeof(ValidationStrings),
            ErrorMessageResourceName = "DigitRangeValuesError")]
        public decimal? Sum => Price * (decimal)Qty;

        /// <summary>
        /// Сумма акциза, включенная в стоимость предмета расчета
        /// </summary>
        /// <list type="bullet">
        /// <item>Должно лежать в диапазоне: 0.01-21474836</item>
        /// </list>
        [Display(Name = "Сумма акциза, включенная в стоимость предмета расчета")]
        [JsonConverter(typeof(MoneyConverter))]
        [Range(0.01, 21474836, ErrorMessageResourceType = typeof(ValidationStrings),
            ErrorMessageResourceName = "DigitRangeValuesError")]
        public decimal? ExciseAmount { get; set; }

        /// <summary>
        /// Дополнительная информация
        /// </summary>
        /// <list type="bullet">
        /// <item>Максимальная длина: 64</item>
        /// </list>
        [MaxLength(64, ErrorMessageResourceType = typeof(ValidationStrings),
            ErrorMessageResourceName = "StringMaxLengthError")]
        [Display(Name = "Дополнительная информация")]
        public string AddInfo { get; set; }

        /// <summary>
        /// Данные платежного агента
        /// </summary>
        [Display(Name = "Данные платежного агента")]
        [ComplexObjectValidation(ErrorMessageResourceType = typeof(ValidationStrings),
            ErrorMessageResourceName = "ComplexObjectValidationError")]
        public AgentParams Agent { get; set; }

        /// <summary>
        /// Отраслевой реквизит
        /// </summary>
        /// <list type="bullet">
        /// <item>Максимальное кол-во элементов: 3</item>
        /// </list>
        [Display(Name = "Отраслевой реквизит")]
        [MaxLength(3, ErrorMessageResourceType = typeof(ValidationStrings),
            ErrorMessageResourceName = "CollectionMaxLengthError")]
        [ComplexObjectCollectionValidation(AllowNullItems = false, ErrorMessageResourceType = typeof(ValidationStrings),
            ErrorMessageResourceName = "ComplexObjectCollectionValidationError")]
        public IndustryRequisiteParams[] IndustryAttribute { get; set; }

        public override IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (Agent != null)
            {
                switch (Agent.Code)
                {
                    case AgentType.BankPayingAgent:
                    case AgentType.BankPayingSubagent:
                        if (Agent.PayingOp.IsNullOrEmptyOrWhiteSpace())
                        {
                            yield return GenerateValidationResult(Agent.Code, nameof(Agent.PayingOp),
                                true);
                        }

                        if (Agent.PayingPhone == null)
                        {
                            yield return GenerateValidationResult(Agent.Code, nameof(Agent.PayingPhone),
                                true);
                        }

                        if (Agent.TransfName.IsNullOrEmptyOrWhiteSpace())
                        {
                            yield return GenerateValidationResult(Agent.Code, nameof(Agent.TransfName),
                                true);
                        }

                        if (Agent.TransfINN.IsNullOrEmptyOrWhiteSpace())
                        {
                            yield return GenerateValidationResult(Agent.Code, nameof(Agent.TransfINN),
                                true);
                        }

                        if (Agent.TransfAddress.IsNullOrEmptyOrWhiteSpace())
                        {
                            yield return GenerateValidationResult(Agent.Code, nameof(Agent.TransfAddress),
                                true);
                        }

                        if (Agent.TransfPhone == null)
                        {
                            yield return GenerateValidationResult(Agent.Code, nameof(Agent.TransfPhone),
                                true);
                        }

                        if (Agent.OperatorPhone != null)
                        {
                            yield return GenerateValidationResult(Agent.Code, nameof(Agent.OperatorPhone),
                                false);
                        }

                        if (Agent.SupplierPhone == null)
                        {
                            yield return GenerateValidationResult(Agent.Code, nameof(Agent.SupplierPhone),
                                true);
                        }

                        if (Agent.SupplierName.IsNullOrEmptyOrWhiteSpace())
                        {
                            yield return GenerateValidationResult(Agent.Code, nameof(Agent.SupplierName),
                                true);
                        }

                        break;
                    case AgentType.PayingAgent:
                    case AgentType.PayingSubagent:
                        if (!Agent.PayingOp.IsNullOrEmptyOrWhiteSpace())
                        {
                            yield return GenerateValidationResult(Agent.Code, nameof(Agent.PayingOp),
                                false);
                        }

                        if (Agent.PayingPhone == null)
                        {
                            yield return GenerateValidationResult(Agent.Code, nameof(Agent.PayingPhone),
                                true);
                        }

                        if (!Agent.TransfName.IsNullOrEmptyOrWhiteSpace())
                        {
                            yield return GenerateValidationResult(Agent.Code, nameof(Agent.TransfName),
                                false);
                        }

                        if (!Agent.TransfINN.IsNullOrEmptyOrWhiteSpace())
                        {
                            yield return GenerateValidationResult(Agent.Code, nameof(Agent.TransfINN),
                                false);
                        }

                        if (!Agent.TransfAddress.IsNullOrEmptyOrWhiteSpace())
                        {
                            yield return GenerateValidationResult(Agent.Code, nameof(Agent.TransfAddress),
                                false);
                        }

                        if (Agent.TransfPhone != null)
                        {
                            yield return GenerateValidationResult(Agent.Code, nameof(Agent.TransfPhone),
                                false);
                        }

                        if (Agent.OperatorPhone == null)
                        {
                            yield return GenerateValidationResult(Agent.Code, nameof(Agent.OperatorPhone),
                                true);
                        }

                        if (Agent.SupplierPhone == null)
                        {
                            yield return GenerateValidationResult(Agent.Code, nameof(Agent.SupplierPhone),
                                true);
                        }

                        if (Agent.SupplierName.IsNullOrEmptyOrWhiteSpace())
                        {
                            yield return GenerateValidationResult(Agent.Code, nameof(Agent.SupplierName),
                                true);
                        }

                        break;

                    default:
                        if (!Agent.PayingOp.IsNullOrEmptyOrWhiteSpace())
                        {
                            yield return GenerateValidationResult(Agent.Code, nameof(Agent.PayingOp),
                                false);
                        }

                        if (Agent.PayingPhone != null)
                        {
                            yield return GenerateValidationResult(Agent.Code, nameof(Agent.PayingPhone),
                                false);
                        }

                        if (!Agent.TransfName.IsNullOrEmptyOrWhiteSpace())
                        {
                            yield return GenerateValidationResult(Agent.Code, nameof(Agent.TransfName),
                                false);
                        }

                        if (!Agent.TransfINN.IsNullOrEmptyOrWhiteSpace())
                        {
                            yield return GenerateValidationResult(Agent.Code, nameof(Agent.TransfINN),
                                false);
                        }

                        if (!Agent.TransfAddress.IsNullOrEmptyOrWhiteSpace())
                        {
                            yield return GenerateValidationResult(Agent.Code, nameof(Agent.TransfAddress),
                                false);
                        }

                        if (Agent.TransfPhone != null)
                        {
                            yield return GenerateValidationResult(Agent.Code, nameof(Agent.TransfPhone),
                                false);
                        }

                        if (Agent.OperatorPhone != null)
                        {
                            yield return GenerateValidationResult(Agent.Code, nameof(Agent.OperatorPhone),
                                false);
                        }

                        if (Agent.SupplierPhone != null)
                        {
                            yield return GenerateValidationResult(Agent.Code, nameof(Agent.SupplierPhone),
                                false);
                        }

                        if (!Agent.SupplierName.IsNullOrEmptyOrWhiteSpace())
                        {
                            yield return GenerateValidationResult(Agent.Code, nameof(Agent.SupplierName),
                                false);
                        }

                        break;
                }
            }

            if (McInfo?.Part != null)
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

                if (!(McInfo.PlannedStatus == ItemEstimatedStatus.ItemDryForSale ||
                      McInfo.PlannedStatus == ItemEstimatedStatus.ItemDryReturn))
                {
                    yield return new ValidationResult(string.Format(
                            ErrorStrings.ResourceManager.GetString("MustBeEqualError"),
                            GetType().GetProperty(nameof(McInfo.PlannedStatus)).GetPropertyDisplayName(),
                            $"{ItemEstimatedStatus.ItemDryForSale.GetDisplayName()}, {ItemEstimatedStatus.ItemDryReturn.GetDisplayName()}"),
                        new[] { nameof(McInfo.PlannedStatus) });
                }
            }
        }

        private static ValidationResult GenerateValidationResult(AgentType agentType, string invalidPropertyName,
            bool isRequired)
        {
            return new ValidationResult(string.Format(
                    $"{ErrorStrings.ResourceManager.GetString("AgentPropertiesRequirementValidationError")}: {(isRequired ? ErrorStrings.ResourceManager.GetString("AgentPropertyIsRequiredValidationError") : ErrorStrings.ResourceManager.GetString("AgentPropertyIsNotRequiredValidationError"))}",
                    agentType.GetDisplayName(),
                    typeof(AgentParams).GetProperty(invalidPropertyName).GetPropertyDisplayName()),
                new[] { invalidPropertyName });
        }
    }
}