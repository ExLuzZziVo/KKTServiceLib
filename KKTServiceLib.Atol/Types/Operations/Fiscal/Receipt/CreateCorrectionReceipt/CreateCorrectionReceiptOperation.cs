#region

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.RegularExpressions;
using CoreLib.CORE.Helpers.Converters;
using CoreLib.CORE.Helpers.ObjectHelpers;
using CoreLib.CORE.Helpers.StringHelpers;
using CoreLib.CORE.Helpers.ValidationHelpers.Attributes;
using CoreLib.CORE.Resources;
using KKTServiceLib.Atol.Types.Common;
using KKTServiceLib.Atol.Types.Common.Agent;
using KKTServiceLib.Atol.Types.Common.Document;
using KKTServiceLib.Atol.Types.Enums;
using KKTServiceLib.Atol.Types.Interfaces;
using KKTServiceLib.Shared.Resources;

#endregion

namespace KKTServiceLib.Atol.Types.Operations.Fiscal.Receipt.CreateCorrectionReceipt
{
    [Description("Создание чека коррекции")]
    public class CreateCorrectionReceiptOperation: Operation<CreateCorrectionReceiptResult>
    {
        /// <summary>
        /// Создание чека коррекции
        /// </summary>
        /// <param name="type">Тип чека коррекции</param>
        /// <param name="correctionType">Способ коррекции</param>
        /// <param name="receiptToCorrectDocumentSign">Фискальный признак ошибочного чека</param>
        /// <param name="correctionBaseDate">Дата совершения корректируемого расчета</param>
        /// <param name="operatorParams">Оператор (кассир)</param>
        /// <param name="taxationType">Система налогообложения</param>
        /// <param name="items">Элементы документа (предметы расчета и тд.)</param>
        /// <param name="payments">Оплаты</param>
        public CreateCorrectionReceiptOperation(CorrectionReceiptType type,
            CorrectionReceiptCorrectionType correctionType, string receiptToCorrectDocumentSign,
            DateTime correctionBaseDate,
            OperatorParams operatorParams,
            TaxationType taxationType, DocumentParams[] items, PaymentParams[] payments): base(type.ToString()
            .ToLowerFirstChar())
        {
            if (receiptToCorrectDocumentSign.IsNullOrEmptyOrWhiteSpace() || receiptToCorrectDocumentSign.Length > 16 ||
                !Regex.IsMatch(receiptToCorrectDocumentSign, @"^[0-9]+$"))
            {
                throw new ArgumentException(
                    string.Format(
                        ValidationStrings.ResourceManager.GetString("StringFormatError"),
                        "Фискальный признак ошибочного чека"),
                    nameof(receiptToCorrectDocumentSign));
            }

            if (items?.Any() != true)
            {
                throw new ArgumentException(
                    string.Format(
                        ValidationStrings.ResourceManager.GetString("CollectionMinLengthError"),
                        GetType().GetProperty(nameof(Items)).GetPropertyDisplayName(), 1),
                    nameof(items));
            }

            if (payments?.Any() != true)
            {
                throw new ArgumentException(
                    string.Format(ValidationStrings.ResourceManager.GetString("CollectionMinLengthError"),
                        GetType().GetProperty(nameof(Payments)).GetPropertyDisplayName(), 1),
                    nameof(payments));
            }

            CorrectionType = correctionType;
            CorrectionBaseDate = correctionBaseDate;
            Operator = operatorParams ?? throw new ArgumentNullException(nameof(operatorParams));
            Items = items.Append(new AdditionalAttributeDocumentParams(receiptToCorrectDocumentSign)).ToArray();
            Payments = payments;
            TaxationType = taxationType;
        }

        /// <summary>
        /// Игнорировать ошибки при печати нефискальных элементов
        /// </summary>
        [Display(Name = "Игнорировать ошибки при печати нефискальных элементов")]
        public bool IgnoreNonFiscalPrintErrors { get; set; }

        /// <summary>
        /// Оператор (кассир)
        /// </summary>
        /// <list type="bullet">
        /// <item>Обязательное поле</item>
        /// </list>
        [ComplexObjectValidation(ErrorMessageResourceType = typeof(ValidationStrings),
            ErrorMessageResourceName = "ComplexObjectValidationError")]
        [Required(ErrorMessageResourceType = typeof(ValidationStrings), ErrorMessageResourceName = "RequiredError")]
        [Display(Name = "Оператор (кассир)")]
        public OperatorParams Operator { get; }

        /// <summary>
        /// Тип коррекции
        /// </summary>
        /// <list type="bullet">
        /// <item>Обязательное поле</item>
        /// </list>
        [Display(Name = "Тип коррекции")]
        [Required(ErrorMessageResourceType = typeof(ValidationStrings), ErrorMessageResourceName = "RequiredError")]
        public CorrectionReceiptCorrectionType CorrectionType { get; }

        /// <summary>
        /// Дата совершения корректируемого расчета
        /// </summary>
        /// <list type="bullet">
        /// <item>Обязательное поле</item>
        /// </list>
        [Required(ErrorMessageResourceType = typeof(ValidationStrings), ErrorMessageResourceName = "RequiredError")]
        [CustomDateTimeConverter("yyyy.MM.dd")]
        [Display(Name = "Дата совершения корректируемого расчета")]
        public DateTime CorrectionBaseDate { get; }

        /// <summary>
        /// Номер предписания налогового органа
        /// </summary>
        /// <list type="bullet">
        /// <item>Обязательное поле, если тип коррекции - <see cref="CorrectionReceiptCorrectionType.Instruction"/></item>
        /// </list>
        [Display(Name = "Номер предписания налогового органа")]
        public string CorrectionBaseNumber { get; set; }

        /// <summary>
        /// Электронный чек
        /// </summary>
        [Display(Name = "Электронный чек")]
        public bool Electronically { get; set; }

        /// <summary>
        /// Система налогообложения
        /// </summary>
        /// <list type="bullet">
        /// <item>Обязательное поле</item>
        /// </list>
        [Display(Name = "Система налогообложения")]
        [Required(ErrorMessageResourceType = typeof(ValidationStrings), ErrorMessageResourceName = "RequiredError")]
        public TaxationType TaxationType { get; }

        /// <summary>
        /// Место проведения расчетов
        /// </summary>
        /// <list type="bullet">
        /// <item>Обязательное поле, если чек является электронным</item>
        /// </list>
        [Display(Name = "Место проведения расчета")]
        public string PaymentsPlace { get; set; }

        /// <summary>
        /// Адрес расчётов
        /// </summary>
        [Display(Name = "Адрес расчётов")]
        public string PaymentsAddress { get; set; }

        /// <summary>
        /// Номер автомата
        /// </summary>
        [Display(Name = "Номер автомата")]
        public string MachineNumber { get; set; }

        /// <summary>
        /// Данные покупателя
        /// </summary>
        [ComplexObjectValidation(ErrorMessageResourceType = typeof(ValidationStrings),
            ErrorMessageResourceName = "ComplexObjectValidationError")]
        [Display(Name = "Данные покупателя")]
        public BuyerParams ClientInfo { get; set; }

        /// <summary>
        /// Данные продавца
        /// </summary>
        [ComplexObjectValidation(ErrorMessageResourceType = typeof(ValidationStrings),
            ErrorMessageResourceName = "ComplexObjectValidationError")]
        [Display(Name = "Данные продавца")]
        public SellerParams CompanyInfo { get; set; }

        /// <summary>
        /// Данные агента
        /// </summary>
        [ComplexObjectValidation(ErrorMessageResourceType = typeof(ValidationStrings),
            ErrorMessageResourceName = "ComplexObjectValidationError")]
        [Display(Name = "Данные агента")]
        public AgentParams AgentInfo { get; set; }

        /// <summary>
        /// Данные поставщика
        /// </summary>
        [ComplexObjectValidation(ErrorMessageResourceType = typeof(ValidationStrings),
            ErrorMessageResourceName = "ComplexObjectValidationError")]
        [Display(Name = "Данные поставщика")]
        public SupplierParams SupplierInfo { get; set; }

        /// <summary>
        /// Элементы документа
        /// </summary>
        /// <list type="bullet">
        /// <item>Обязательное поле</item>
        /// <item>Минимальное кол-во элементов: 1</item>
        /// </list>
        [ComplexObjectCollectionValidation(AllowNullItems = false, ErrorMessageResourceType = typeof(ValidationStrings),
            ErrorMessageResourceName = "ComplexObjectCollectionValidationError")]
        [Required(ErrorMessageResourceType = typeof(ValidationStrings), ErrorMessageResourceName = "RequiredError")]
        [MinLength(1, ErrorMessageResourceType = typeof(ValidationStrings),
            ErrorMessageResourceName = "CollectionMinLengthError")]
        [Display(Name = "Элементы документа")]
        public DocumentParams[] Items { get; }

        /// <summary>
        /// Оплаты
        /// </summary>
        /// <list type="bullet">
        /// <item>Обязательное поле</item>
        /// <item>Минимальное кол-во элементов: 1</item>
        /// </list>
        [ComplexObjectCollectionValidation(AllowNullItems = false, ErrorMessageResourceType = typeof(ValidationStrings),
            ErrorMessageResourceName = "ComplexObjectCollectionValidationError")]
        [Required(ErrorMessageResourceType = typeof(ValidationStrings), ErrorMessageResourceName = "RequiredError")]
        [MinLength(1, ErrorMessageResourceType = typeof(ValidationStrings),
            ErrorMessageResourceName = "CollectionMinLengthError")]
        [Display(Name = "Оплаты")]
        public PaymentParams[] Payments { get; }

        /// <summary>
        /// Налоги на чек
        /// </summary>
        [ComplexObjectCollectionValidation(AllowNullItems = false, ErrorMessageResourceType = typeof(ValidationStrings),
            ErrorMessageResourceName = "ComplexObjectCollectionValidationError")]
        [Display(Name = "Налоги на чек")]
        public TaxParams[] Taxes { get; set; }

        /// <summary>
        /// Итог чека
        /// </summary>
        /// <list type="bullet">
        /// <item>Должно лежать в диапазоне: 0.01-<see cref="decimal.MaxValue"/></item>
        /// </list>
        [Display(Name = "Итог чека")]
        [Range(0.01, (double)decimal.MaxValue, ErrorMessageResourceType = typeof(ValidationStrings),
            ErrorMessageResourceName = "DigitRangeValuesError")]
        public decimal? Total { get; set; }

        /// <summary>
        /// Элементы для печати до документа
        /// </summary>
        [ComplexObjectCollectionValidation(AllowNullItems = false, ErrorMessageResourceType = typeof(ValidationStrings),
            ErrorMessageResourceName = "ComplexObjectCollectionValidationError")]
        [Display(Name = "Элементы для печати до документа")]
        public ICommonDocumentElement[] PreItems { get; set; }

        /// <summary>
        /// Элементы для печати после документа
        /// </summary>
        [ComplexObjectCollectionValidation(AllowNullItems = false, ErrorMessageResourceType = typeof(ValidationStrings),
            ErrorMessageResourceName = "ComplexObjectCollectionValidationError")]
        [Display(Name = "Элементы для печати после документа")]
        public ICommonDocumentElement[] PostItems { get; set; }

        /// <summary>
        /// Пользовательские параметры
        /// </summary>
        [Display(Name = "Пользовательские параметры")]
        [ComplexObjectCollectionValidation(AllowNullItems = false, ErrorMessageResourceType = typeof(ValidationStrings),
            ErrorMessageResourceName = "ComplexObjectCollectionValidationError")]
        public UserParams[] CustomParameters { get; set; }

        public override IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (CorrectionType == CorrectionReceiptCorrectionType.Instruction &&
                CorrectionBaseNumber.IsNullOrEmptyOrWhiteSpace())
            {
                yield return new ValidationResult(string.Format(
                        ValidationStrings.ResourceManager.GetString("RequiredError"),
                        GetType().GetProperty(nameof(CorrectionBaseNumber)).GetPropertyDisplayName()),
                    new[] { nameof(CorrectionBaseNumber) });
            }

            if (AgentInfo != null)
            {
                foreach (var vr in AgentInfo.Validate(validationContext))
                {
                    yield return vr;
                }
            }

            foreach (var i in Items)
            {
                if (i is PositionDocumentParams p)
                {
                    if (p.AgentInfo != null)
                    {
                        foreach (var vr in p.AgentInfo.Validate(validationContext))
                        {
                            vr.ErrorMessage =
                                $"{string.Format(ErrorStrings.ResourceManager.GetString("AgentInPositionValidationError"), p.Name)}: {vr.ErrorMessage}";

                            yield return vr;
                        }
                    }
                }
            }
        }
    }
}