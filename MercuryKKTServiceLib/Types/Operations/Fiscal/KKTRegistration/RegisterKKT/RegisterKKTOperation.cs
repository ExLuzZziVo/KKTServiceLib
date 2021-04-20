using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using KKTServiceLib.Shared.Helpers;
using KKTServiceLib.Shared.Resources;
using KKTServiceLib.Shared.Types.ValidationAttributes;
using MercuryKKTServiceLib.Types.Common;
using MercuryKKTServiceLib.Types.Common.KKT;
using MercuryKKTServiceLib.Types.Enums;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace MercuryKKTServiceLib.Types.Operations.Fiscal.KKTRegistration.RegisterKKT
{
    [Description("Регистрация/перерегистрация ККТ")]
    public class RegisterKKTOperation : Operation<RegisterKKTResult>
    {
        /// <summary>
        /// Регистрация/перерегистрация ККТ
        /// </summary>
        /// <param name="type">Тип регистрации ККТ</param>
        /// <param name="operatorParams">Оператор (кассир)</param>
        /// <param name="organizationParams">Информация об организации</param>
        /// <param name="kktParams">Параметры ККТ</param>
        /// <param name="ofdParams">Параметры ОФД</param>
        /// <param name="localDateTime">Локальные дата и время в месте (по адресу) осуществления расчетов</param>
        /// <param name="taxationTypes">Системы налогообложения, с которыми работает ККТ</param>
        /// <param name="kktRegistrationReason">Причина перерегистрации ККТ</param>
        public RegisterKKTOperation(KKTRegistrationType type,
            OperatorParams operatorParams,
            OrganizationParams organizationParams,
            KKTParams kktParams,
            OfdParams ofdParams,
            DateTime localDateTime, ISet<TaxationType> taxationTypes,
            KKTRegistrationReason? kktRegistrationReason = null) : base(type.ToString())
        {
            DateTime = localDateTime;

            CashierInfo = operatorParams ?? throw new ArgumentNullException(nameof(operatorParams));
            Owner = organizationParams ?? throw new ArgumentNullException(nameof(organizationParams));
            Kkt = kktParams ?? throw new ArgumentNullException(nameof(kktParams));
            Ofd = ofdParams ?? throw new ArgumentNullException(nameof(ofdParams));

            if (taxationTypes?.Any() != true)
            {
                throw new ArgumentException(string.Format(ErrorStrings.ResourceManager.GetString("MinLengthError"),
                        this.GetType().GetProperty(nameof(TaxSystem)).GetDisplayName(), 1),
                    nameof(taxationTypes));
            }

            TaxSystem = taxationTypes;

            if (type == KKTRegistrationType.ReregisterKKT && kktRegistrationReason == null)
            {
                throw new ArgumentNullException(nameof(kktRegistrationReason));
            }

            Reason = kktRegistrationReason;
        }

        /// <summary>
        /// Локальные дата и время в месте (по адресу) осуществления расчетов
        /// </summary>
        /// <list type="bullet">
        /// <item>Обязательное поле</item>
        /// </list>
        [Required(ErrorMessageResourceType = typeof(ErrorStrings), ErrorMessageResourceName = "RequiredError")]
        [JsonConverter(typeof(IsoDateTimeConverter))]
        [Display(Name = "Локальные дата и время в месте (по адресу) осуществления расчетов")]
        public DateTime DateTime { get; }

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
        /// Информация об организации
        /// </summary>
        /// <list type="bullet">
        /// <item>Обязательное поле</item>
        /// </list>
        [Required(ErrorMessageResourceType = typeof(ErrorStrings), ErrorMessageResourceName = "RequiredError")]
        [Display(Name = "Информация об организации")]
        [ComplexObjectValidation(ErrorMessageResourceType = typeof(ErrorStrings),
            ErrorMessageResourceName = "ComplexObjectValidationError")]
        public OrganizationParams Owner { get; }

        /// <summary>
        /// Параметры ККТ
        /// </summary>
        /// <list type="bullet">
        /// <item>Обязательное поле</item>
        /// </list>
        [Required(ErrorMessageResourceType = typeof(ErrorStrings), ErrorMessageResourceName = "RequiredError")]
        [Display(Name = "Параметры ККТ")]
        [ComplexObjectValidation(ErrorMessageResourceType = typeof(ErrorStrings),
            ErrorMessageResourceName = "ComplexObjectValidationError")]
        public KKTParams Kkt { get; }

        /// <summary>
        /// Параметры ОФД
        /// </summary>
        /// <list type="bullet">
        /// <item>Обязательное поле</item>
        /// </list>
        [Required(ErrorMessageResourceType = typeof(ErrorStrings), ErrorMessageResourceName = "RequiredError")]
        [Display(Name = "Параметры ОФД")]
        [ComplexObjectValidation(ErrorMessageResourceType = typeof(ErrorStrings),
            ErrorMessageResourceName = "ComplexObjectValidationError")]
        public OfdParams Ofd { get; }

        /// <summary>
        /// Системы налогообложения, с которыми работает ККТ
        /// </summary>
        /// <list type="bullet">
        /// <item>Обязательное поле</item>
        /// <item>Минимальное кол-во элементов: 1</item>
        /// </list>
        [Required(ErrorMessageResourceType = typeof(ErrorStrings), ErrorMessageResourceName = "RequiredError")]
        [Display(Name = "Системы налогообложения, с которыми работает ККТ")]
        [MinLength(1, ErrorMessageResourceType = typeof(ErrorStrings), ErrorMessageResourceName = "MinLengthError")]
        public ISet<TaxationType> TaxSystem { get; }

        /// <summary>
        /// Агенты, в роли которых может выступать владелец ККТ
        /// </summary>
        [Display(Name = "Агенты, в роли которых может выступать владелец ККТ")]
        public ISet<AgentType> Agent { get; set; }

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
        /// Адрес сайта ФНС
        /// </summary>
        /// <list type="bullet">
        /// <item>Должно соответствовать регулярному выражению <see cref="RegexHelper.UrlPattern"/></item>
        /// </list>
        /// <remarks>
        /// Значение по умолчанию: www.nalog.ru
        /// </remarks>
        [RegularExpression(RegexHelper.UrlPattern,
            ErrorMessageResourceType = typeof(ErrorStrings), ErrorMessageResourceName = "StringFormatError")]
        [Display(Name = "Адрес сайта ФНС")]
        public string SiteFNS { get; set; } = "www.nalog.ru";

        /// <summary>
        /// Причина перерегистрации ККТ
        /// </summary>
        /// <list type="bullet">
        /// <item>Обязательное поле, если тип регистрации ККТ - <see cref="KKTRegistrationType.ReregisterKKT"/></item>
        /// </list>
        [Display(Name = "Причина перерегистрации ККТ")]
        public KKTRegistrationReason? Reason { get; }

        protected override IEnumerable<ValidationResult> Validate()
        {
            var validationResults = base.Validate();

            if (Kkt?.Mode?.Automat == true && Kkt?.Mode?.AutomatNum.IsNullOrEmptyOrWhiteSpace() == true)
            {
                validationResults = new List<ValidationResult>(validationResults)
                {
                    new ValidationResult(string.Format(
                        ErrorStrings.ResourceManager.GetString("RequiredError"),
                        typeof(KKTWorkParams).GetProperty(nameof(Kkt.Mode.AutomatNum)).GetDisplayName()))
                };
            }

            return validationResults;
        }
    }
}