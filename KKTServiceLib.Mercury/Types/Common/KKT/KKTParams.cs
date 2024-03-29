﻿#region

using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using CoreLib.CORE.Helpers.ObjectHelpers;
using CoreLib.CORE.Helpers.StringHelpers;
using CoreLib.CORE.Helpers.ValidationHelpers.Attributes;
using CoreLib.CORE.Resources;
using KKTServiceLib.Mercury.Types.Operations.Fiscal.KKTRegistration.GetKKTRegistrationInfo;

#endregion

namespace KKTServiceLib.Mercury.Types.Common.KKT
{
    [Description("Параметры ККТ")]
    [JsonDerivedType(typeof(KKTParamsInfo))]
    public class KKTParams
    {
        /// <summary>
        /// Параметры ККТ
        /// </summary>
        /// <param name="registrationNumber">Регистрационный номер</param>
        /// <param name="address">Адрес расчетов</param>
        /// <param name="location">Место расчетов</param>
        /// <param name="kktWorkParams">Параметры работы ККТ</param>
        public KKTParams(string registrationNumber, string address, string location, KKTWorkParams kktWorkParams)
        {
            if (registrationNumber.IsNullOrEmptyOrWhiteSpace())
            {
                throw new ArgumentException(
                    string.Format(
                        ValidationStrings.ResourceManager.GetString("StringFormatError"),
                        GetType().GetProperty(nameof(RegNum)).GetPropertyDisplayName()),
                    nameof(registrationNumber));
            }

            if (address.IsNullOrEmptyOrWhiteSpace())
            {
                throw new ArgumentException(
                    string.Format(
                        ValidationStrings.ResourceManager.GetString("StringFormatError"),
                        GetType().GetProperty(nameof(Address)).GetPropertyDisplayName()),
                    nameof(address));
            }

            if (location.IsNullOrEmptyOrWhiteSpace())
            {
                throw new ArgumentException(
                    string.Format(
                        ValidationStrings.ResourceManager.GetString("StringFormatError"),
                        GetType().GetProperty(nameof(Location)).GetPropertyDisplayName()),
                    nameof(location));
            }

            Mode = kktWorkParams ?? throw new ArgumentNullException(nameof(kktWorkParams));

            RegNum = registrationNumber;
            Address = address;
            Location = location;
        }

        [JsonConstructor]
        protected internal KKTParams() { }

        /// <summary>
        /// Регистрационный номер ККТ
        /// </summary>
        /// <list type="bullet">
        /// <item>Обязательное поле</item>
        /// </list>
        [Required(ErrorMessageResourceType = typeof(ValidationStrings), ErrorMessageResourceName = "RequiredError")]
        [Display(Name = "Регистрационный номер ККТ")]
        public string RegNum { get; }

        /// <summary>
        /// Адрес расчетов
        /// </summary>
        /// <list type="bullet">
        /// <item>Обязательное поле</item>
        /// </list>
        [Required(ErrorMessageResourceType = typeof(ValidationStrings), ErrorMessageResourceName = "RequiredError")]
        [Display(Name = "Адрес расчетов")]
        public string Address { get; }

        /// <summary>
        /// Место расчетов
        /// </summary>
        /// <list type="bullet">
        /// <item>Обязательное поле</item>
        /// </list>
        [Required(ErrorMessageResourceType = typeof(ValidationStrings), ErrorMessageResourceName = "RequiredError")]
        [Display(Name = "Место расчетов")]
        public string Location { get; }

        /// <summary>
        /// Параметры работы ККТ
        /// </summary>
        /// <list type="bullet">
        /// <item>Обязательное поле</item>
        /// </list>
        [Required(ErrorMessageResourceType = typeof(ValidationStrings), ErrorMessageResourceName = "RequiredError")]
        [Display(Name = "Параметры работы ККТ")]
        [ComplexObjectValidation(ErrorMessageResourceType = typeof(ValidationStrings),
            ErrorMessageResourceName = "ComplexObjectValidationError")]
        public KKTWorkParams Mode { get; }
    }
}