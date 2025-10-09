#region

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
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

namespace KKTServiceLib.Atol.Types.Operations.Fiscal.Receipt.CreateFiscalReceipt
{
    [Description("Создание фискального чека")]
    public class CreateFiscalReceiptOperation: Operation<CreateFiscalReceiptResult>
    {
        /// <summary>
        /// Создание фискального чека
        /// </summary>
        /// <param name="type">Тип фискального чека</param>
        /// <param name="operatorParams">Оператор (кассир)</param>
        /// <param name="taxationType">Система налогообложения</param>
        /// <param name="items">Элементы документа (предметы расчета и тд.)</param>
        /// <param name="payments">Оплаты</param>
        /// <param name="additionalAttributeValue">Дополнительный реквизит чека (БСО)</param>
        public CreateFiscalReceiptOperation(FiscalReceiptType type, OperatorParams operatorParams,
            TaxationType taxationType, DocumentParams[] items, PaymentParams[] payments,
            string additionalAttributeValue = null): base(type.ToString()
            .ToLowerFirstChar())
        {
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

            if (additionalAttributeValue?.Length > 16)
            {
                throw new ArgumentException(
                    string.Format(
                        ValidationStrings.ResourceManager.GetString("StringFormatError"),
                        typeof(AdditionalAttributeDocumentParams)
                            .GetProperty(nameof(AdditionalAttributeDocumentParams.Value)).GetPropertyDisplayName()),
                    nameof(additionalAttributeValue));
            }

            Operator = operatorParams ?? throw new ArgumentNullException(nameof(operatorParams));
            Items = items;

            if (!additionalAttributeValue.IsNullOrEmptyOrWhiteSpace())
            {
                Items = items.Append(new AdditionalAttributeDocumentParams(additionalAttributeValue)).ToArray();
            }

            Payments = payments;
            TaxationType = taxationType;
        }

        /// <summary>
        /// Игнорировать ошибки при печати нефискальных элементов
        /// </summary>
        [Display(Name = "Игнорировать ошибки при печати нефискальных элементов")]
        public bool IgnoreNonFiscalPrintErrors { get; set; }

        /// <summary>
        /// Выполнить предварительную проверку размера чека
        /// </summary>
        /// <remarks>
        /// Доступна только при активной лицензии 19. Чек пробит не будет.
        /// Значение по умолчанию: false
        /// </remarks>
        [Display(Name = "Выполнить предварительную проверку размера чека")]
        public bool CheckSize { get; set; } = false;

        /// <summary>
        /// Электронный чек
        /// </summary>
        [Display(Name = "Электронный чек")]
        public bool Electronically { get; set; }

        /// <summary>
        /// Признак расчета в 'Интернет'
        /// </summary>
        /// <remarks>
        /// Значение по умолчанию: false
        /// </remarks>
        [Display(Name = "Признак расчета в 'Интернет'")]
        public bool Internet { get; set; } = false;

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
        /// Место проведения расчётов
        /// </summary>
        /// <list type="bullet">
        /// <item>Обязательное поле, если <see cref="Internet"/> имеет значение true</item>
        /// </list>
        [Display(Name = "Место проведения расчётов")]
        [RequiredIf(nameof(Internet), true,
            ErrorMessageResourceType = typeof(ValidationStrings), ErrorMessageResourceName = "RequiredError")]
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
        /// Оператор (кассир)
        /// </summary>
        /// <list type="bullet">
        /// <item>Обязательное поле</item>
        /// </list>
        [ComplexObjectValidation(ErrorMessageResourceType = typeof(ValidationStrings),
            ErrorMessageResourceName = "ComplexObjectValidationError")]
        [Display(Name = "Оператор (кассир)")]
        [Required(ErrorMessageResourceType = typeof(ValidationStrings), ErrorMessageResourceName = "RequiredError")]
        public OperatorParams Operator { get; }

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
        /// Операционный реквизит
        /// </summary>
        /// <remarks>
        /// Только для ФФД ≥ 1.2
        /// </remarks>
        [Display(Name = "Операционный реквизит")]
        [ComplexObjectValidation(ErrorMessageResourceType = typeof(ValidationStrings),
            ErrorMessageResourceName = "ComplexObjectValidationError")]
        public OperationParams OperationInfo { get; set; }

        /// <summary>
        /// Отраслевой реквизит
        /// </summary>
        /// <remarks>
        /// Только для ФФД ≥ 1.2
        /// </remarks>
        [Display(Name = "Отраслевой реквизит")]
        [ComplexObjectCollectionValidation(AllowNullItems = false, ErrorMessageResourceType = typeof(ValidationStrings),
            ErrorMessageResourceName = "ComplexObjectCollectionValidationError")]
        public IndustryRequisiteParams[] IndustryInfo { get; set; }

        /// <summary>
        /// Элементы документа
        /// </summary>
        /// <list type="bullet">
        /// <item>Обязательное поле</item>
        /// <item>Минимальное кол-во элементов: 1</item>
        /// </list>
        [Required(ErrorMessageResourceType = typeof(ValidationStrings), ErrorMessageResourceName = "RequiredError")]
        [ComplexObjectCollectionValidation(AllowNullItems = false, ErrorMessageResourceType = typeof(ValidationStrings),
            ErrorMessageResourceName = "ComplexObjectCollectionValidationError")]
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
        /// Сведения обо всех оплатах по чеку безналичными
        /// </summary>
        [ComplexObjectCollectionValidation(AllowNullItems = false, ErrorMessageResourceType = typeof(ValidationStrings),
            ErrorMessageResourceName = "ComplexObjectCollectionValidationError")]
        [Display(Name = "Сведения обо всех оплатах по чеку безналичными")]
        public ElectronicallyPaymentParams[] PaymentsAddInfo { get; set; }

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
        /// Предварительно проверить имеющиеся в чеке КМ
        /// </summary>
        /// <remarks>
        /// Только для ФФД ≥ 1.2
        /// </remarks>
        [Display(Name = "Предварительно проверить имеющиеся в чеке КМ")]
        public bool? ValidateMarkingCodes { get; set; }

        /// <summary>
        /// Пользовательские параметры
        /// </summary>
        [Display(Name = "Пользовательские параметры")]
        [ComplexObjectCollectionValidation(AllowNullItems = false, ErrorMessageResourceType = typeof(ValidationStrings),
            ErrorMessageResourceName = "ComplexObjectCollectionValidationError")]
        public UserParams[] CustomParameters { get; set; }

        /// <summary>
        /// Данные уведомления
        /// </summary>
        [Display(Name = "Данные уведомления")]
        [ComplexObjectCollectionValidation(AllowNullItems = false, ErrorMessageResourceType = typeof(ValidationStrings),
            ErrorMessageResourceName = "ComplexObjectCollectionValidationError")]
        public NotificationData[] SalesNotice { get; set; }

        public override IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (Internet && ClientInfo?.EmailOrPhone.IsNullOrEmptyOrWhiteSpace() != false)
            {
                yield return new ValidationResult(string.Format(
                        ValidationStrings.ResourceManager.GetString("RequiredError"),
                        GetType().GetProperty(nameof(ClientInfo.EmailOrPhone)).GetPropertyDisplayName()),
                    new[] { nameof(ClientInfo.EmailOrPhone) });
            }

            if (PaymentsAddInfo != null)
            {
                var electronicallyPaymentsSum =
                    Payments.Where(p => p.Type == PaymentType.Electronically).Sum(p => p.Sum);
                var electronicallyTotalPaymentsSum = PaymentsAddInfo.Sum(p => p.Sum);

                if (electronicallyTotalPaymentsSum != electronicallyPaymentsSum)
                {
                    yield return new ValidationResult(
                        ErrorStrings.ResourceManager.GetString("ElectronicallyTotalPaymentSumError"),
                        new[] { nameof(Payments) });
                }
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
