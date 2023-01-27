﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;
using KKTServiceLib.Mercury.Types.Common;
using KKTServiceLib.Mercury.Types.Common.Document;
using KKTServiceLib.Mercury.Types.Common.FiscalDocuments;
using KKTServiceLib.Mercury.Types.Enums;
using KKTServiceLib.Shared.Helpers;
using KKTServiceLib.Shared.Resources;
using KKTServiceLib.Shared.Types.ValidationAttributes;

namespace KKTServiceLib.Mercury.Types.Operations.Fiscal.Receipt.OpenCheck
{
    [Description("Открытие фискального чека")]
    public class OpenCheckOperation : Operation<OpenCheckResult>
    {
        /// <summary>
        /// Открытие фискального чека
        /// </summary>
        /// <param name="fiscalReceiptType">Тип открываемого чека</param>
        /// <param name="operatorParams">Оператор (кассир)</param>
        /// <param name="taxationType">Система налогообложения</param>
        public OpenCheckOperation(FiscalReceiptType fiscalReceiptType, OperatorParams operatorParams,
            TaxationType taxationType) : base("OpenCheck")
        {
            CheckType = fiscalReceiptType;
            TaxSystem = taxationType;
            CashierInfo = operatorParams ?? throw new ArgumentNullException(nameof(operatorParams));
        }

        /// <summary>
        /// Тип открываемого чека
        /// </summary>
        /// <list type="bullet">
        /// <item>Обязательное поле</item>
        /// </list>
        [Required(ErrorMessageResourceType = typeof(ErrorStrings), ErrorMessageResourceName = "RequiredError")]
        [Display(Name = "Тип открываемого чека")]
        public FiscalReceiptType CheckType { get; }

        /// <summary>
        /// Система налогообложения
        /// </summary>
        /// <list type="bullet">
        /// <item>Обязательное поле</item>
        /// </list>
        [Required(ErrorMessageResourceType = typeof(ErrorStrings), ErrorMessageResourceName = "RequiredError")]
        [Display(Name = "Система налогообложения")]
        public TaxationType TaxSystem { get; }

        /// <summary>
        /// Адрес проведения расчета
        /// </summary>
        [Display(Name = "Адрес проведения расчета")]
        public string Address { get; set; }

        /// <summary>
        /// Место проведения расчета
        /// </summary>
        [Display(Name = "Место проведения расчета")]
        public string Location { get; set; }

        /// <summary>
        /// Адрес электронной почты отправителя чека
        /// </summary>
        /// <list type="bullet">
        /// <item>Должно соответствовать регулярному выражению <see cref="RegexHelper.EmailAddressPattern"/></item>
        /// </list>
        [RegularExpression(RegexHelper.EmailAddressPattern,
            ErrorMessageResourceType = typeof(ErrorStrings), ErrorMessageResourceName = "StringFormatError")]
        [Display(Name = "Адрес электронной почты отправителя чека")]
        public string SenderEmail { get; set; }

        /// <summary>
        /// Печать документа на ККТ
        /// </summary>
        /// <remarks>
        /// Значение по умолчанию: true
        /// </remarks>
        [Display(Name = "Печать документа на ККТ")]
        public bool? PrintDoc { get; set; } = true;

        /// <summary>
        /// Дополнительный реквизит чека (БСО)
        /// </summary>
        /// <list type="bullet">
        /// <item>Максимальная длина: 16</item>
        /// </list>
        [MaxLength(16, ErrorMessageResourceType = typeof(ErrorStrings),
            ErrorMessageResourceName = "StringMaxLengthError")]
        [Display(Name = "Дополнительный реквизит чека (БСО)")]
        public string AdditionalProps { get; set; }

        /// <summary>
        /// Оператор (кассир)
        /// </summary>
        /// <list type="bullet">
        /// <item>Обязательное поле</item>
        /// </list>
        [Required(ErrorMessageResourceType = typeof(ErrorStrings), ErrorMessageResourceName = "RequiredError")]
        [Display(Name = "Оператор (кассир)")]
        [ComplexObjectValidation(ErrorMessageResourceType = typeof(ErrorStrings),
            ErrorMessageResourceName = "ComplexObjectValidationError")]
        public OperatorParams CashierInfo { get; }

        /// <summary>
        /// Данные покупателя
        /// </summary>
        [Display(Name = "Данные покупателя")]
        [ComplexObjectValidation(ErrorMessageResourceType = typeof(ErrorStrings),
            ErrorMessageResourceName = "ComplexObjectValidationError")]
        public BuyerParams BuyerInfo { get; set; }

        /// <summary>
        /// Информация о чеке коррекции
        /// </summary>
        [Display(Name = "Информация о чеке коррекции")]
        [ComplexObjectValidation(ErrorMessageResourceType = typeof(ErrorStrings),
            ErrorMessageResourceName = "ComplexObjectValidationError")]
        public CorrectionReceiptFiscalDocumentParams CorrectionInfo { get; set; }

        /// <summary>
        /// Дополнительный реквизит пользователя
        /// </summary>
        [Display(Name = "Дополнительный реквизит пользователя")]
        [ComplexObjectValidation(ErrorMessageResourceType = typeof(ErrorStrings),
            ErrorMessageResourceName = "ComplexObjectValidationError")]
        public UserAttributeDocumentParams UserAttribute { get; set; }

        public override IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            switch (CheckType)
            {
                case FiscalReceiptType.Buy:
                case FiscalReceiptType.Sell:
                case FiscalReceiptType.BuyReturn:
                case FiscalReceiptType.SellReturn:
                    if (CorrectionInfo != null)
                    {
                        yield return new ValidationResult(
                            ErrorStrings.ResourceManager.GetString("IsNotCorrectionReceiptError"),
                            new[] { nameof(CorrectionInfo) });
                    }

                    break;
                default:
                    if (CorrectionInfo == null)
                    {
                        yield return new ValidationResult(string.Format(
                                ErrorStrings.ResourceManager.GetString("RequiredError"),
                                GetType().GetProperty(nameof(CorrectionInfo)).GetDisplayName()),
                            new[] { nameof(CorrectionInfo) });
                    }
                    else if (CorrectionInfo.CorrectionType == CorrectionReceiptCorrectionType.Instruction &&
                             CorrectionInfo.CauseDocNum.IsNullOrEmptyOrWhiteSpace())
                    {
                        yield return new ValidationResult(string.Format(
                                ErrorStrings.ResourceManager.GetString("RequiredError"),
                                GetType().GetProperty(nameof(CorrectionInfo.CauseDocNum)).GetDisplayName()),
                            new[] { nameof(CorrectionInfo.CauseDocNum) });
                    }

                    if (AdditionalProps.IsNullOrEmptyOrWhiteSpace() || !Regex.IsMatch(AdditionalProps, @"^[0-9]+$"))
                    {
                        yield return new ValidationResult(string.Format(
                                ErrorStrings.ResourceManager.GetString("StringFormatError"),
                                GetType().GetProperty(nameof(AdditionalProps)).GetDisplayName()),
                            new[] { nameof(AdditionalProps) });
                    }

                    break;
            }
        }
    }
}