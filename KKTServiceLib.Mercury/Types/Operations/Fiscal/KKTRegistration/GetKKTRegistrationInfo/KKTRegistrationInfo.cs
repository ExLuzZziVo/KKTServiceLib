#region

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using CoreLib.CORE.Helpers.Converters;
using CoreLib.CORE.Resources;
using KKTServiceLib.Mercury.Types.Common;
using KKTServiceLib.Mercury.Types.Enums;

#endregion

namespace KKTServiceLib.Mercury.Types.Operations.Fiscal.KKTRegistration.GetKKTRegistrationInfo
{
    [Description("Информация о регистрации ККТ")]
    public class KKTRegistrationInfo
    {
        /// <summary>
        /// Дата и время регистрации ККТ
        /// </summary>
        [CustomDateTimeConverter("yyyy-MM-ddTHH:mm:ss")]
        [Display(Name = "Дата и время регистрации ККТ")]
        public DateTime DateTime { get; set; }

        /// <summary>
        /// Владелец ККТ
        /// </summary>
        [Display(Name = "Владелец ККТ")]
        public OrganizationParams Owner { get; set; }

        /// <summary>
        /// Параметры ККТ
        /// </summary>
        [Display(Name = "Параметры ККТ")]
        public KKTParamsInfo Kkt { get; set; }

        /// <summary>
        /// Параметры ОФД
        /// </summary>
        [Display(Name = "Параметры ОФД")]
        public OfdParams Ofd { get; set; }

        /// <summary>
        /// Системы налогообложения, с которыми работает ККТ
        /// </summary>
        /// <list type="bullet">
        /// <item>Обязательное поле</item>
        /// <item>Минимальное кол-во элементов: 1</item>
        /// </list>
        [Display(Name = "Системы налогообложения, с которыми работает ККТ")]
        [MinLength(1, ErrorMessageResourceType = typeof(ValidationStrings),
            ErrorMessageResourceName = "CollectionMinLengthError")]
        [Required(ErrorMessageResourceType = typeof(ValidationStrings), ErrorMessageResourceName = "RequiredError")]
        public ISet<TaxationType> TaxSystem { get; } =
#if NETSTANDARD2_0
            new HashSet<TaxationType>();
#else
            new HashSet<TaxationType>(Enum.GetNames(typeof(TaxationType)).Length);
#endif

        /// <summary>
        /// Агенты, в роли которых может выступать владелец ККТ
        /// </summary>
        [Display(Name = "Агенты, в роли которых может выступать владелец ККТ")]
        public ISet<AgentType> Agent { get; set; }

        /// <summary>
        /// Причина перерегистрации
        /// </summary>
        [Display(Name = "Причина перерегистрации")]
        public KKTRegistrationReason Reason { get; set; }
    }
}