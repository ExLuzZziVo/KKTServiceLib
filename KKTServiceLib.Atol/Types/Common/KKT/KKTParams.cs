#region

using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;
using KKTServiceLib.Atol.Types.Enums;
using KKTServiceLib.Shared.Helpers;
using KKTServiceLib.Shared.Resources;
using Newtonsoft.Json;

#endregion

namespace KKTServiceLib.Atol.Types.Common.KKT
{
    [Description("Параметры ККТ")]
    public class KKTParams
    {
        /// <summary>
        /// Параметры ККТ
        /// </summary>
        /// <param name="registrationNumber">Регистрационный номер</param>
        /// <param name="address">Место расчетов</param>
        /// <param name="encryption">Шифрование данных</param>
        /// <param name="offlineMode">Работа в автономном режиме</param>
        /// <param name="service">Использование для услуг</param>
        /// <param name="bso">Автоматизированная система печати БСО</param>
        /// <param name="internet">ККТ для расчетов только в сети Интернет</param>
        /// <param name="autoMode">Признак автоматического режима</param>
        /// <param name="fnsUrl">Адрес сайта ФНС</param>
        /// <param name="machineInstallation">Признак установки принтера в автомате</param>
        /// <param name="excise">Продажа подакцизного товара</param>
        /// <param name="gambling">Признак проведения азартных игр</param>
        /// <param name="lottery">Признак проведения лотереи</param>
        /// <param name="defaultTaxationType">Система налогообложения по умолчанию</param>
        /// <param name="ofdChannel">Канал обмена с ОФД</param>
        /// <param name="ffdVersion">Версия ФФД</param>
        public KKTParams(string registrationNumber,
            string address,
            bool encryption,
            bool offlineMode,
            bool service,
            bool bso,
            bool internet,
            bool autoMode,
            string fnsUrl,
            bool machineInstallation,
            bool excise,
            bool gambling,
            bool lottery,
            TaxationType defaultTaxationType,
            OfdChannelType ofdChannel,
            FfdVersionType ffdVersion)
        {
            if (registrationNumber.IsNullOrEmptyOrWhiteSpace())
            {
                throw new ArgumentException(
                    string.Format(
                        ErrorStrings.ResourceManager.GetString("StringFormatError"),
                        this.GetType().GetProperty(nameof(RegistrationNumber)).GetDisplayName()),
                    nameof(registrationNumber));
            }

            if (address.IsNullOrEmptyOrWhiteSpace())
            {
                throw new ArgumentException(
                    string.Format(ErrorStrings.ResourceManager.GetString("StringFormatError"),
                        this.GetType().GetProperty(nameof(address)).GetDisplayName()),
                    nameof(address));
            }

            if (fnsUrl.IsNullOrEmptyOrWhiteSpace() || !Regex.IsMatch(fnsUrl, RegexHelper.UrlPattern))
            {
                throw new ArgumentException(
                    string.Format(ErrorStrings.ResourceManager.GetString("StringFormatError"),
                        this.GetType().GetProperty(nameof(FnsUrl)).GetDisplayName()),
                    nameof(fnsUrl));
            }

            RegistrationNumber = registrationNumber;
            PaymentsAddress = address;
            FnsUrl = fnsUrl;
            Encryption = encryption;
            OfflineMode = offlineMode;
            Service = service;
            Bso = bso;
            Internet = internet;
            AutoMode = autoMode;
            MachineInstallation = machineInstallation;
            Excise = excise;
            Gambling = gambling;
            Lottery = lottery;
            DefaultTaxationType = defaultTaxationType;
            OfdChannel = ofdChannel;
            FfdVersion = ffdVersion;
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
        public string RegistrationNumber { get; }

        /// <summary>
        /// Адрес сайта ФНС
        /// </summary>
        /// <list type="bullet">
        /// <item>Обязательное поле</item>
        /// <item>Должно соответствовать регулярному выражению <see cref="RegexHelper.UrlPattern"/></item>
        /// </list>
        [RegularExpression(
            RegexHelper.UrlPattern,
            ErrorMessageResourceType = typeof(ErrorStrings), ErrorMessageResourceName = "StringFormatError")]
        [Required(ErrorMessageResourceType = typeof(ErrorStrings), ErrorMessageResourceName = "RequiredError")]
        [Display(Name = "Адрес сайта ФНС")]
        public string FnsUrl { get; }

        /// <summary>
        /// Работа в автономном режиме
        /// </summary>
        /// <list type="bullet">
        /// <item>Обязательное поле</item>
        /// </list>
        [Required(ErrorMessageResourceType = typeof(ErrorStrings), ErrorMessageResourceName = "RequiredError")]
        [Display(Name = "Работа в автономном режиме")]
        public bool OfflineMode { get; }

        /// <summary>
        /// Признак установки принтера в автомате
        /// </summary>
        /// <list type="bullet">
        /// <item>Обязательное поле</item>
        /// </list>
        [Required(ErrorMessageResourceType = typeof(ErrorStrings), ErrorMessageResourceName = "RequiredError")]
        [Display(Name = "Признак установки принтера в автомате")]
        public bool MachineInstallation { get; }

        /// <summary>
        /// Автоматизированная система печати БСО
        /// </summary>
        /// <list type="bullet">
        /// <item>Обязательное поле</item>
        /// </list>
        [Required(ErrorMessageResourceType = typeof(ErrorStrings), ErrorMessageResourceName = "RequiredError")]
        [Display(Name = "Автоматизированная система печати БСО")]
        public bool Bso { get; }

        /// <summary>
        /// Шифрование данных
        /// </summary>
        /// <list type="bullet">
        /// <item>Обязательное поле</item>
        /// </list>
        [Required(ErrorMessageResourceType = typeof(ErrorStrings), ErrorMessageResourceName = "RequiredError")]
        [Display(Name = "Шифрование данных")]
        public bool Encryption { get; }

        /// <summary>
        /// Признак автоматического режима
        /// </summary>
        /// <list type="bullet">
        /// <item>Обязательное поле</item>
        /// </list>
        [Required(ErrorMessageResourceType = typeof(ErrorStrings), ErrorMessageResourceName = "RequiredError")]
        [Display(Name = "Признак автоматического режима")]
        public bool AutoMode { get; }

        /// <summary>
        /// Номер автомата
        /// </summary>
        [Display(Name = "Номер автомата")]
        public string MachineNumber { get; set; }

        /// <summary>
        /// ККТ для расчетов только в сети Интернет
        /// </summary>
        /// <list type="bullet">
        /// <item>Обязательное поле</item>
        /// </list>
        [Required(ErrorMessageResourceType = typeof(ErrorStrings), ErrorMessageResourceName = "RequiredError")]
        [Display(Name = "ККТ для расчетов только в сети Интернет")]
        public bool Internet { get; }

        /// <summary>
        /// Использование для услуг
        /// </summary>
        /// <list type="bullet">
        /// <item>Обязательное поле</item>
        /// </list>
        [Required(ErrorMessageResourceType = typeof(ErrorStrings), ErrorMessageResourceName = "RequiredError")]
        [Display(Name = "Использование для услуг")]
        public bool Service { get; }

        /// <summary>
        /// Продажа подакцизного товара
        /// </summary>
        /// <list type="bullet">
        /// <item>Обязательное поле</item>
        /// </list>
        [Required(ErrorMessageResourceType = typeof(ErrorStrings), ErrorMessageResourceName = "RequiredError")]
        [Display(Name = "Продажа подакцизного товара")]
        public bool Excise { get; }

        /// <summary>
        /// Признак проведения азартных игр
        /// </summary>
        /// <list type="bullet">
        /// <item>Обязательное поле</item>
        /// </list>
        [Required(ErrorMessageResourceType = typeof(ErrorStrings), ErrorMessageResourceName = "RequiredError")]
        [Display(Name = "Признак проведения азартных игр")]
        public bool Gambling { get; }

        /// <summary>
        /// Признак проведения лотереи
        /// </summary>
        /// <list type="bullet">
        /// <item>Обязательное поле</item>
        /// </list>
        [Required(ErrorMessageResourceType = typeof(ErrorStrings), ErrorMessageResourceName = "RequiredError")]
        [Display(Name = "Признак проведения лотереи")]
        public bool Lottery { get; }

        /// <summary>
        /// Система налогообложения по умолчанию
        /// </summary>
        /// <list type="bullet">
        /// <item>Обязательное поле</item>
        /// </list>
        [Required(ErrorMessageResourceType = typeof(ErrorStrings), ErrorMessageResourceName = "RequiredError")]
        [Display(Name = "Система налогообложения по умолчанию")]
        public TaxationType DefaultTaxationType { get; }

        /// <summary>
        /// Канал обмена с ОФД
        /// </summary>
        /// <list type="bullet">
        /// <item>Обязательное поле</item>
        /// </list>
        [Required(ErrorMessageResourceType = typeof(ErrorStrings), ErrorMessageResourceName = "RequiredError")]
        [Display(Name = "Канал обмена с ОФД")]
        public OfdChannelType OfdChannel { get; }

        /// <summary>
        /// Версия ФФД
        /// </summary>
        /// <list type="bullet">
        /// <item>Обязательное поле</item>
        /// </list>
        [Required(ErrorMessageResourceType = typeof(ErrorStrings), ErrorMessageResourceName = "RequiredError")]
        [Display(Name = "Версия ФФД")]
        public FfdVersionType FfdVersion { get; }

        /// <summary>
        /// Место расчетов
        /// </summary>
        /// <list type="bullet">
        /// <item>Обязательное поле</item>
        /// </list>
        [Required(ErrorMessageResourceType = typeof(ErrorStrings), ErrorMessageResourceName = "RequiredError")]
        [Display(Name = "Место расчетов")]
        public string PaymentsAddress { get; }
    }
}