#region

using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using KKTServiceLib.Atol.Types.Common;
using KKTServiceLib.Atol.Types.Common.KKT;
using KKTServiceLib.Atol.Types.Enums;
using KKTServiceLib.Shared.Helpers;
using KKTServiceLib.Shared.Resources;
using KKTServiceLib.Shared.Types.ValidationAttributes;

#endregion

namespace KKTServiceLib.Atol.Types.Operations.Fiscal.KKTRegistration.RegisterKKT
{
    [Description("Регистрация/перерегистрация ККТ")]
    public class RegisterKKTOperation : Operation<RegisterKKTOperation>
    {
        /// <summary>
        /// Регистрация/перерегистрация ККТ
        /// </summary>
        /// <param name="type">Тип регистрации ККТ</param>
        /// <param name="operatorParams">Оператор (кассир)</param>
        /// <param name="organizationParams">Информация об организации-пользователе</param>
        /// <param name="kktParams">Параметры ККТ</param>
        /// <param name="ofdParams">Параметры ОФД</param>
        /// <param name="kktRegistrationReason">Причина перерегистрации ККТ</param>
        public RegisterKKTOperation(KKTRegistrationType type, OperatorParams operatorParams,
            OrganizationParams organizationParams, KKTParams kktParams, OfdParams ofdParams,
            KKTRegistrationReason? kktRegistrationReason = null) : base(type.ToString()
            .ToLowerFirstChar())
        {
            Operator = operatorParams ?? throw new ArgumentNullException(nameof(operatorParams));
            Organization = organizationParams ?? throw new ArgumentNullException(nameof(organizationParams));
            Device = kktParams ?? throw new ArgumentNullException(nameof(kktParams));
            Ofd = ofdParams ?? throw new ArgumentNullException(nameof(ofdParams));

            if (type == KKTRegistrationType.ChangeRegistrationParameters && kktRegistrationReason == null)
            {
                throw new ArgumentNullException(nameof(kktRegistrationReason));
            }

            Reason = kktRegistrationReason;
        }

        /// <summary>
        /// Оператор (кассир)
        /// </summary>
        /// <list type="bullet">
        /// <item>Обязательное поле</item>
        /// </list>
        [ComplexObjectValidation(ErrorMessageResourceType = typeof(ErrorStrings),
            ErrorMessageResourceName = "ComplexObjectValidationError")]
        [Required(ErrorMessageResourceType = typeof(ErrorStrings), ErrorMessageResourceName = "RequiredError")]
        [Display(Name = "Оператор (кассир)")]
        public OperatorParams Operator { get; }

        /// <summary>
        /// Причина перерегистрации
        /// </summary>
        /// <list type="bullet">
        /// <item>Обязательное поле, если тип регистрации ККТ - <see cref="KKTRegistrationType.ChangeRegistrationParameters"/></item>
        /// </list>
        [Display(Name = "Причина перерегистрации")]
        public KKTRegistrationReason? Reason { get; }

        /// <summary>
        /// Список причин изменения параметров регистрации
        /// </summary>
        [Display(Name = "Список причин изменения параметров регистрации")]
        public int[] ChangeInfoReasons { get; set; }

        /// <summary>
        /// Информация об организации
        /// </summary>
        /// <list type="bullet">
        /// <item>Обязательное поле</item>
        /// </list>
        [ComplexObjectValidation(ErrorMessageResourceType = typeof(ErrorStrings),
            ErrorMessageResourceName = "ComplexObjectValidationError")]
        [Required(ErrorMessageResourceType = typeof(ErrorStrings), ErrorMessageResourceName = "RequiredError")]
        [Display(Name = "Информация об организации")]
        public OrganizationParams Organization { get; }

        /// <summary>
        /// Параметры ККТ
        /// </summary>
        /// <list type="bullet">
        /// <item>Обязательное поле</item>
        /// </list>
        [ComplexObjectValidation(ErrorMessageResourceType = typeof(ErrorStrings),
            ErrorMessageResourceName = "ComplexObjectValidationError")]
        [Required(ErrorMessageResourceType = typeof(ErrorStrings), ErrorMessageResourceName = "RequiredError")]
        [Display(Name = "Параметры ККТ")]
        public KKTParams Device { get; }

        /// <summary>
        /// Параметры ОФД
        /// </summary>
        /// <list type="bullet">
        /// <item>Обязательное поле</item>
        /// </list>
        [ComplexObjectValidation(ErrorMessageResourceType = typeof(ErrorStrings),
            ErrorMessageResourceName = "ComplexObjectValidationError")]
        [Required(ErrorMessageResourceType = typeof(ErrorStrings), ErrorMessageResourceName = "RequiredError")]
        [Display(Name = "Параметры ОФД")]
        public OfdParams Ofd { get; }

        /// <summary>
        /// Электронный отчет
        /// </summary>
        [Display(Name = "Электронный отчет")]
        public bool Electronically { get; set; }
    }
}