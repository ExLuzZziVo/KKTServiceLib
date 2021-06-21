using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using KKTServiceLib.Shared.Helpers;
using KKTServiceLib.Shared.Resources;
using KKTServiceLib.Shared.Types.ValidationAttributes;
using MercuryKKTServiceLib.Types.Common.Agent;
using MercuryKKTServiceLib.Types.Converters;
using MercuryKKTServiceLib.Types.Enums;
using Newtonsoft.Json;

namespace MercuryKKTServiceLib.Types.Operations.Fiscal.Receipt.AddPositionToOpenedCheck
{
    [Description("Добавление позиции в открытый фискальный чек")]
    public class AddPositionToOpenedCheckOperation : Operation<AddPositionToOpenedCheckResult>
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
            PaymentMethodType paymentMethodType, PaymentObjectType paymentObjectType) : base("AddGoods")
        {
            if (name.IsNullOrEmptyOrWhiteSpace())
            {
                throw new ArgumentException(
                    string.Format(
                        ErrorStrings.ResourceManager.GetString("StringFormatError"),
                        GetType().GetProperty(nameof(ProductName)).GetDisplayName()),
                    nameof(name));
            }

            if (price < 0 || price > 21474836)
            {
                throw new ArgumentException(
                    string.Format(ErrorStrings.ResourceManager.GetString("DigitRangeValuesError"),
                        GetType().GetProperty(nameof(Price)).GetDisplayName(), 0, 21474836),
                    nameof(price));
            }

            if (quantity < 0.001 || quantity > 214748)
            {
                throw new ArgumentException(
                    string.Format(ErrorStrings.ResourceManager.GetString("DigitRangeValuesError"),
                        GetType().GetProperty(nameof(Qty)).GetDisplayName(), 0.001, 214748),
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
        /// Код товара
        /// </summary>
        /// <remarks>
        /// Будет проигнорировано, если <see cref="MarkingCode"/> имеет значение
        /// </remarks>
        [Display(Name = "Код товара")]
        public string NomenclatureCode { get; set; }

        /// <summary>
        /// Маркировка товара
        /// </summary>
        /// <remarks>
        /// Если этот параметр будет задан, то значение <see cref="NomenclatureCode"/> будет проигнорировано
        /// </remarks>
        [Display(Name = "Маркировка товара")]
        public string MarkingCode { get; set; }

        /// <summary>
        /// Наименование предмета расчета
        /// </summary>
        /// <list type="bullet">
        /// <item>Обязательное поле</item>
        /// </list>
        [Required(ErrorMessageResourceType = typeof(ErrorStrings), ErrorMessageResourceName = "RequiredError")]
        [Display(Name = "Наименование предмета расчета")]
        public string ProductName { get; }

        /// <summary>
        /// Количество предмета расчета
        /// </summary>
        /// <list type="bullet">
        /// <item>Обязательное поле</item>
        /// <item>Должно лежать в диапазоне: 0.001-214748</item>
        /// </list>
        [Required(ErrorMessageResourceType = typeof(ErrorStrings), ErrorMessageResourceName = "RequiredError")]
        [Range(0.001, 214748, ErrorMessageResourceType = typeof(ErrorStrings),
            ErrorMessageResourceName = "DigitRangeValuesError")]
        [Display(Name = "Количество предмета расчета")]
        [JsonConverter(typeof(QuantityConverter))]
        public double Qty { get; }

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
        [Range(1, 16, ErrorMessageResourceType = typeof(ErrorStrings),
            ErrorMessageResourceName = "DigitRangeValuesError")]
        [Display(Name = "Номер отдела (секции)")]
        public ushort? Section { get; set; } = 1;

        /// <summary>
        /// Налоговая ставка
        /// </summary>
        /// <list type="bullet">
        /// <item>Обязательное поле</item>
        /// </list>
        [Required(ErrorMessageResourceType = typeof(ErrorStrings), ErrorMessageResourceName = "RequiredError")]
        [Display(Name = "Налоговая ставка")]
        public WatType TaxCode { get; }

        /// <summary>
        /// Способ расчета
        /// </summary>
        /// <list type="bullet">
        /// <item>Обязательное поле</item>
        /// </list>
        [Required(ErrorMessageResourceType = typeof(ErrorStrings), ErrorMessageResourceName = "RequiredError")]
        [Display(Name = "Способ расчета")]
        public PaymentMethodType PaymentFormCode { get; }

        /// <summary>
        /// Тип предмета расчета
        /// </summary>
        /// <list type="bullet">
        /// <item>Обязательное поле</item>
        /// </list>
        [Required(ErrorMessageResourceType = typeof(ErrorStrings), ErrorMessageResourceName = "RequiredError")]
        [Display(Name = "Тип предмета расчета")]
        public PaymentObjectType ProductTypeCode { get; }

        /// <summary>
        /// Код страны происхождения
        /// </summary>
        /// <list type="bullet">
        /// <item>Должно соответствовать регулярному выражению <see cref="RegexHelper.CountryOfOriginCodePattern"/></item>
        /// </list>
        [RegularExpression(RegexHelper.CountryOfOriginCodePattern, ErrorMessageResourceType = typeof(ErrorStrings),
            ErrorMessageResourceName = "StringFormatError")]
        [Display(Name = "Код страны происхождения")]
        public string CountryOfOrigin { get; set; }

        /// <summary>
        /// Регистрационный номер таможенной декларации
        /// </summary>
        /// <list type="bullet">
        /// <item>Максимальная длина: 32</item>
        /// </list>
        [MaxLength(32, ErrorMessageResourceType = typeof(ErrorStrings),
            ErrorMessageResourceName = "StringMaxLengthError")]
        [Display(Name = "Регистрационный номер таможенной декларации")]
        public string CustomsDeclaration { get; set; }

        /// <summary>
        /// Дополнительный реквизит предмета расчета
        /// </summary>
        /// <list type="bullet">
        /// <item>Максимальная длина: 64</item>
        /// </list>
        [MaxLength(64, ErrorMessageResourceType = typeof(ErrorStrings),
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
        [Required(ErrorMessageResourceType = typeof(ErrorStrings), ErrorMessageResourceName = "RequiredError")]
        [Display(Name = "Цена единицы предмета расчета")]
        [JsonConverter(typeof(MoneyConverter))]
        [Range(0, 21474836, ErrorMessageResourceType = typeof(ErrorStrings),
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
        [Range(0, 21474836, ErrorMessageResourceType = typeof(ErrorStrings),
            ErrorMessageResourceName = "DigitRangeValuesError")]
        public decimal? Sum => Price * (decimal) Qty;

        /// <summary>
        /// Сумма акциза, включенная в стоимость предмета расчета
        /// </summary>
        /// <list type="bullet">
        /// <item>Должно лежать в диапазоне: 0.01-21474836</item>
        /// </list>
        [Display(Name = "Сумма акциза, включенная в стоимость предмета расчета")]
        [JsonConverter(typeof(MoneyConverter))]
        [Range(0.01, 21474836, ErrorMessageResourceType = typeof(ErrorStrings),
            ErrorMessageResourceName = "DigitRangeValuesError")]
        public decimal? ExciseAmount { get; set; }

        /// <summary>
        /// Дополнительная информация
        /// </summary>
        /// <list type="bullet">
        /// <item>Максимальная длина: 64</item>
        /// </list>
        [MaxLength(64, ErrorMessageResourceType = typeof(ErrorStrings),
            ErrorMessageResourceName = "StringMaxLengthError")]
        [Display(Name = "Дополнительная информация")]
        public string AddInfo { get; set; }

        /// <summary>
        /// Данные платежного агента
        /// </summary>
        [Display(Name = "Данные платежного агента")]
        [ComplexObjectValidation(ErrorMessageResourceType = typeof(ErrorStrings),
            ErrorMessageResourceName = "ComplexObjectValidationError")]
        public AgentParams Agent { get; set; }

        protected override IEnumerable<ValidationResult> Validate()
        {
            var validationResults = base.Validate();

            if (Agent != null)
            {
                var agentValidationResults = new List<ValidationResult>(32);

                switch (Agent.Code)
                {
                    case AgentType.BankPayingAgent:
                    case AgentType.BankPayingSubagent:
                        if (Agent.PayingOp.IsNullOrEmptyOrWhiteSpace())
                        {
                            agentValidationResults.Add(GenerateValidationResult(Agent.Code, nameof(Agent.PayingOp),
                                true));
                        }

                        if (Agent.PayingPhone == null)
                        {
                            agentValidationResults.Add(GenerateValidationResult(Agent.Code, nameof(Agent.PayingPhone),
                                true));
                        }

                        if (Agent.TransfName.IsNullOrEmptyOrWhiteSpace())
                        {
                            agentValidationResults.Add(GenerateValidationResult(Agent.Code, nameof(Agent.TransfName),
                                true));
                        }

                        if (Agent.TransfINN.IsNullOrEmptyOrWhiteSpace())
                        {
                            agentValidationResults.Add(GenerateValidationResult(Agent.Code, nameof(Agent.TransfINN),
                                true));
                        }

                        if (Agent.TransfAddress.IsNullOrEmptyOrWhiteSpace())
                        {
                            agentValidationResults.Add(GenerateValidationResult(Agent.Code, nameof(Agent.TransfAddress),
                                true));
                        }

                        if (Agent.TransfPhone == null)
                        {
                            agentValidationResults.Add(GenerateValidationResult(Agent.Code, nameof(Agent.TransfPhone),
                                true));
                        }

                        if (Agent.OperatorPhone != null)
                        {
                            agentValidationResults.Add(GenerateValidationResult(Agent.Code, nameof(Agent.OperatorPhone),
                                false));
                        }

                        if (Agent.SupplierPhone == null)
                        {
                            agentValidationResults.Add(GenerateValidationResult(Agent.Code, nameof(Agent.SupplierPhone),
                                true));
                        }

                        if (Agent.SupplierName.IsNullOrEmptyOrWhiteSpace())
                        {
                            agentValidationResults.Add(GenerateValidationResult(Agent.Code, nameof(Agent.SupplierName),
                                true));
                        }

                        break;
                    case AgentType.PayingAgent:
                    case AgentType.PayingSubagent:
                        if (!Agent.PayingOp.IsNullOrEmptyOrWhiteSpace())
                        {
                            agentValidationResults.Add(GenerateValidationResult(Agent.Code, nameof(Agent.PayingOp),
                                false));
                        }

                        if (Agent.PayingPhone == null)
                        {
                            agentValidationResults.Add(GenerateValidationResult(Agent.Code, nameof(Agent.PayingPhone),
                                true));
                        }

                        if (!Agent.TransfName.IsNullOrEmptyOrWhiteSpace())
                        {
                            agentValidationResults.Add(GenerateValidationResult(Agent.Code, nameof(Agent.TransfName),
                                false));
                        }

                        if (!Agent.TransfINN.IsNullOrEmptyOrWhiteSpace())
                        {
                            agentValidationResults.Add(GenerateValidationResult(Agent.Code, nameof(Agent.TransfINN),
                                false));
                        }

                        if (!Agent.TransfAddress.IsNullOrEmptyOrWhiteSpace())
                        {
                            agentValidationResults.Add(GenerateValidationResult(Agent.Code, nameof(Agent.TransfAddress),
                                false));
                        }

                        if (Agent.TransfPhone != null)
                        {
                            agentValidationResults.Add(GenerateValidationResult(Agent.Code, nameof(Agent.TransfPhone),
                                false));
                        }

                        if (Agent.OperatorPhone == null)
                        {
                            agentValidationResults.Add(GenerateValidationResult(Agent.Code, nameof(Agent.OperatorPhone),
                                true));
                        }

                        if (Agent.SupplierPhone == null)
                        {
                            agentValidationResults.Add(GenerateValidationResult(Agent.Code, nameof(Agent.SupplierPhone),
                                true));
                        }

                        if (Agent.SupplierName.IsNullOrEmptyOrWhiteSpace())
                        {
                            agentValidationResults.Add(GenerateValidationResult(Agent.Code, nameof(Agent.SupplierName),
                                true));
                        }

                        break;

                    default:
                        if (!Agent.PayingOp.IsNullOrEmptyOrWhiteSpace())
                        {
                            agentValidationResults.Add(GenerateValidationResult(Agent.Code, nameof(Agent.PayingOp),
                                false));
                        }

                        if (Agent.PayingPhone != null)
                        {
                            agentValidationResults.Add(GenerateValidationResult(Agent.Code, nameof(Agent.PayingPhone),
                                false));
                        }

                        if (!Agent.TransfName.IsNullOrEmptyOrWhiteSpace())
                        {
                            agentValidationResults.Add(GenerateValidationResult(Agent.Code, nameof(Agent.TransfName),
                                false));
                        }

                        if (!Agent.TransfINN.IsNullOrEmptyOrWhiteSpace())
                        {
                            agentValidationResults.Add(GenerateValidationResult(Agent.Code, nameof(Agent.TransfINN),
                                false));
                        }

                        if (!Agent.TransfAddress.IsNullOrEmptyOrWhiteSpace())
                        {
                            agentValidationResults.Add(GenerateValidationResult(Agent.Code, nameof(Agent.TransfAddress),
                                false));
                        }

                        if (Agent.TransfPhone != null)
                        {
                            agentValidationResults.Add(GenerateValidationResult(Agent.Code, nameof(Agent.TransfPhone),
                                false));
                        }

                        if (Agent.OperatorPhone != null)
                        {
                            agentValidationResults.Add(GenerateValidationResult(Agent.Code, nameof(Agent.OperatorPhone),
                                false));
                        }

                        if (Agent.SupplierPhone != null)
                        {
                            agentValidationResults.Add(GenerateValidationResult(Agent.Code, nameof(Agent.SupplierPhone),
                                false));
                        }

                        if (!Agent.SupplierName.IsNullOrEmptyOrWhiteSpace())
                        {
                            agentValidationResults.Add(GenerateValidationResult(Agent.Code, nameof(Agent.SupplierName),
                                false));
                        }

                        break;
                }

                if (agentValidationResults.Any())
                {
                    validationResults = new List<ValidationResult>(validationResults)
                    {
                        new ValidationResult(
                            string.Format(
                                ErrorStrings.ResourceManager.GetString("AgentPropertiesRequirementValidationError"),
                                GetType().GetProperty(nameof(Agent)).GetDisplayName()) +
                            agentValidationResults.Aggregate(string.Empty,
                                (current, c) => current + "\n\t" + c.ErrorMessage))
                    };
                }
            }

            return validationResults;
        }

        private static ValidationResult GenerateValidationResult(AgentType agentType, string invalidPropertyName,
            bool isRequired)
        {
            return new ValidationResult(string.Format(
                isRequired
                    ? ErrorStrings.ResourceManager.GetString("AgentPropertyIsRequiredValidationError")
                    : ErrorStrings.ResourceManager.GetString("AgentPropertyIsNotRequiredValidationError"),
                agentType.GetDisplayName(),
                typeof(AgentParams).GetProperty(invalidPropertyName).GetDisplayName()));
        }
    }
}