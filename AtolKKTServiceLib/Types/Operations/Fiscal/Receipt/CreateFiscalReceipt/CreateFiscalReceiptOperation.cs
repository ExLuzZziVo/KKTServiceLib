#region

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using Atol.Drivers10.Fptr;
using AtolKKTServiceLib.Types.Common;
using AtolKKTServiceLib.Types.Common.Agent;
using AtolKKTServiceLib.Types.Common.Document;
using AtolKKTServiceLib.Types.Enums;
using AtolKKTServiceLib.Types.Interfaces;
using KKTServiceLib.Shared.Helpers;
using KKTServiceLib.Shared.Resources;
using KKTServiceLib.Shared.Types.Exceptions;
using KKTServiceLib.Shared.Types.ValidationAttributes;

#endregion

namespace AtolKKTServiceLib.Types.Operations.Fiscal.Receipt.CreateFiscalReceipt
{
    [Description("Создание фискального чека")]
    public class CreateFiscalReceiptOperation : Operation<CreateFiscalReceiptResult>
    {
        /// <summary>
        /// Создание фискального чека
        /// </summary>
        /// <param name="type">Тип фискального чека</param>
        /// <param name="operatorParams">Оператор (кассир)</param>
        /// <param name="taxationType">Система налогообложения</param>
        /// <param name="items">Элементы документа (предметы расчета и тд.)</param>
        /// <param name="payments">Оплаты</param>
        public CreateFiscalReceiptOperation(FiscalReceiptType type, OperatorParams operatorParams,
            TaxationType taxationType, DocumentParams[] items, PaymentParams[] payments) : base(type.ToString()
            .ToLowerFirstChar())
        {
            if (items?.Any() != true)
            {
                throw new ArgumentException(
                    string.Format(
                        ErrorStrings.ResourceManager.GetString("MinLengthError"),
                        this.GetType().GetProperty(nameof(Items)).GetDisplayName(), 1),
                    nameof(items));
            }

            if (payments?.Any() != true)
            {
                throw new ArgumentException(
                    string.Format(ErrorStrings.ResourceManager.GetString("MinLengthError"),
                        this.GetType().GetProperty(nameof(Payments)).GetDisplayName(), 1),
                    nameof(payments));
            }

            Operator = operatorParams ?? throw new ArgumentNullException(nameof(operatorParams));
            Items = items;
            Payments = payments;
            TaxationType = taxationType;
        }

        /// <summary>
        /// Игнорировать ошибки при печати нефискальных элементов
        /// </summary>
        [Display(Name = "Игнорировать ошибки при печати нефискальных элементов")]
        public bool IgnoreNonFiscalPrintErrors { get; set; }

        /// <summary>
        /// Электронный чек
        /// </summary>
        [Display(Name = "Электронный чек")]
        public bool Electronically { get; set; }

        /// <summary>
        /// Использовать при регистрации чека ставку налога 18%
        /// </summary>
        [Display(Name = "Использовать при регистрации чека ставку налога 18%")]
        public bool UserVAT18 { get; set; }

        /// <summary>
        /// Система налогообложения
        /// </summary>
        /// <list type="bullet">
        /// <item>Обязательное поле</item>
        /// </list>
        [Display(Name = "Система налогообложения")]
        [Required(ErrorMessageResourceType = typeof(ErrorStrings), ErrorMessageResourceName = "RequiredError")]
        public TaxationType TaxationType { get; }

        /// <summary>
        /// Место проведения расчета
        /// </summary>
        [Display(Name = "Место проведения расчета")]
        public string PaymentsPlace { get; set; }

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
        [ComplexObjectValidation(ErrorMessageResourceType = typeof(ErrorStrings),
            ErrorMessageResourceName = "ComplexObjectValidationError")]
        [Display(Name = "Оператор (кассир)")]
        [Required(ErrorMessageResourceType = typeof(ErrorStrings), ErrorMessageResourceName = "RequiredError")]
        public OperatorParams Operator { get; }

        /// <summary>
        /// Данные покупателя
        /// </summary>
        [ComplexObjectValidation(ErrorMessageResourceType = typeof(ErrorStrings),
            ErrorMessageResourceName = "ComplexObjectValidationError")]
        [Display(Name = "Данные покупателя")]
        public BuyerParams ClientInfo { get; set; }

        /// <summary>
        /// Данные продавца
        /// </summary>
        [ComplexObjectValidation(ErrorMessageResourceType = typeof(ErrorStrings),
            ErrorMessageResourceName = "ComplexObjectValidationError")]
        [Display(Name = "Данные продавца")]
        public SellerParams CompanyInfo { get; set; }

        /// <summary>
        /// Данные агента
        /// </summary>
        [ComplexObjectValidation(ErrorMessageResourceType = typeof(ErrorStrings),
            ErrorMessageResourceName = "ComplexObjectValidationError")]
        [Display(Name = "Данные агента")]
        public AgentParams AgentInfo { get; set; }

        /// <summary>
        /// Данные поставщика
        /// </summary>
        [ComplexObjectValidation(ErrorMessageResourceType = typeof(ErrorStrings),
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
        [Required(ErrorMessageResourceType = typeof(ErrorStrings), ErrorMessageResourceName = "RequiredError")]
        [ComplexObjectCollectionValidation(AllowNullItems = false, ErrorMessageResourceType = typeof(ErrorStrings),
            ErrorMessageResourceName = "ComplexObjectCollectionValidationError")]
        [MinLength(1, ErrorMessageResourceType = typeof(ErrorStrings), ErrorMessageResourceName = "MinLengthError")]
        [Display(Name = "Элементы документа")]
        public DocumentParams[] Items { get; }

        /// <summary>
        /// Оплаты
        /// </summary>
        /// <list type="bullet">
        /// <item>Обязательное поле</item>
        /// <item>Минимальное кол-во элементов: 1</item>
        /// </list>
        [ComplexObjectCollectionValidation(AllowNullItems = false, ErrorMessageResourceType = typeof(ErrorStrings),
            ErrorMessageResourceName = "ComplexObjectCollectionValidationError")]
        [Required(ErrorMessageResourceType = typeof(ErrorStrings), ErrorMessageResourceName = "RequiredError")]
        [MinLength(1, ErrorMessageResourceType = typeof(ErrorStrings), ErrorMessageResourceName = "MinLengthError")]
        [Display(Name = "Оплаты")]
        public PaymentParams[] Payments { get; }

        /// <summary>
        /// Налоги на чек
        /// </summary>
        [ComplexObjectCollectionValidation(AllowNullItems = false, ErrorMessageResourceType = typeof(ErrorStrings),
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
        [Range(0.01, (double) decimal.MaxValue, ErrorMessageResourceType = typeof(ErrorStrings),
            ErrorMessageResourceName = "DigitRangeValuesError")]
        public decimal? Total { get; set; }

        /// <summary>
        /// Элементы для печати до документа
        /// </summary>
        [ComplexObjectCollectionValidation(AllowNullItems = false, ErrorMessageResourceType = typeof(ErrorStrings),
            ErrorMessageResourceName = "ComplexObjectCollectionValidationError")]
        [Display(Name = "Элементы для печати до документа")]
        public ICommonDocumentElement[] PreItems { get; set; }

        /// <summary>
        /// Элементы для печати после документа
        /// </summary>
        [ComplexObjectCollectionValidation(AllowNullItems = false, ErrorMessageResourceType = typeof(ErrorStrings),
            ErrorMessageResourceName = "ComplexObjectCollectionValidationError")]
        [Display(Name = "Элементы для печати после документа")]
        public ICommonDocumentElement[] PostItems { get; set; }

        protected override IEnumerable<ValidationResult> Validate()
        {
            var validationResults = base.Validate();

            if (AgentInfo != null)
            {
                validationResults = validationResults.Concat(AgentInfo.Validate());
            }

            foreach (var i in Items)
            {
                if (i is PositionDocumentParams p)
                {
                    if (p.AgentInfo != null)
                    {
                        var positionAgentValidationErrors = p.AgentInfo.Validate();

                        if (positionAgentValidationErrors.Any())
                        {
                            validationResults = new List<ValidationResult>(validationResults)
                            {
                                new ValidationResult(
                                    string.Format(
                                        ErrorStrings.ResourceManager.GetString("AgentInPositionValidationError"),
                                        p.Name) +
                                    positionAgentValidationErrors.Aggregate(string.Empty,
                                        (current, c) => current + "\n\t" + c.ErrorMessage))
                            };
                        }
                    }
                }
            }

            return validationResults;
        }
    }
}