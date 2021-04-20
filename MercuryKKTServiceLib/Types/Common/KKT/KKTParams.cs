using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using KKTServiceLib.Shared.Helpers;
using KKTServiceLib.Shared.Resources;
using KKTServiceLib.Shared.Types.ValidationAttributes;
using Newtonsoft.Json;

namespace MercuryKKTServiceLib.Types.Common.KKT
{
    [Description("Параметры ККТ")]
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
                        ErrorStrings.ResourceManager.GetString("StringFormatError"),
                        this.GetType().GetProperty(nameof(RegNum)).GetDisplayName()),
                    nameof(registrationNumber));
            }

            if (address.IsNullOrEmptyOrWhiteSpace())
            {
                throw new ArgumentException(
                    string.Format(
                        ErrorStrings.ResourceManager.GetString("StringFormatError"),
                        this.GetType().GetProperty(nameof(Address)).GetDisplayName()),
                    nameof(address));
            }

            if (location.IsNullOrEmptyOrWhiteSpace())
            {
                throw new ArgumentException(
                    string.Format(
                        ErrorStrings.ResourceManager.GetString("StringFormatError"),
                        this.GetType().GetProperty(nameof(Location)).GetDisplayName()),
                    nameof(location));
            }

            Mode = kktWorkParams ?? throw new ArgumentNullException(nameof(kktWorkParams));

            RegNum = registrationNumber;
            Address = address;
            Location = location;
        }

        [JsonConstructor]
        private KKTParams()
        {
        }

        /// <summary>
        /// Регистрационный номер ККТ
        /// </summary>
        /// <list type="bullet">
        /// <item>Обязательное поле</item>
        /// </list>
        [Required(ErrorMessageResourceType = typeof(ErrorStrings), ErrorMessageResourceName = "RequiredError")]
        [Display(Name = "Регистрационный номер ККТ")]
        public string RegNum { get; }

        /// <summary>
        /// Адрес расчетов
        /// </summary>
        /// <list type="bullet">
        /// <item>Обязательное поле</item>
        /// </list>
        [Required(ErrorMessageResourceType = typeof(ErrorStrings), ErrorMessageResourceName = "RequiredError")]
        [Display(Name = "Адрес расчетов")]
        public string Address { get; }

        /// <summary>
        /// Место расчетов
        /// </summary>
        /// <list type="bullet">
        /// <item>Обязательное поле</item>
        /// </list>
        [Required(ErrorMessageResourceType = typeof(ErrorStrings), ErrorMessageResourceName = "RequiredError")]
        [Display(Name = "Место расчетов")]
        public string Location { get; }

        /// <summary>
        /// Параметры работы ККТ
        /// </summary>
        /// <list type="bullet">
        /// <item>Обязательное поле</item>
        /// </list>
        [Required(ErrorMessageResourceType = typeof(ErrorStrings), ErrorMessageResourceName = "RequiredError")]
        [Display(Name = "Параметры работы ККТ")]
        [ComplexObjectValidation(ErrorMessageResourceType = typeof(ErrorStrings),
            ErrorMessageResourceName = "ComplexObjectValidationError")]
        public KKTWorkParams Mode { get; }
    }
}