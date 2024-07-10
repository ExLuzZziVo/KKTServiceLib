#region

using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using System.Text.RegularExpressions;
using CoreLib.CORE.Helpers.ObjectHelpers;
using CoreLib.CORE.Helpers.StringHelpers;
using CoreLib.CORE.Resources;
using KKTServiceLib.Atol.Types.Enums;

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
        /// <param name="insurance">Признак осуществления страховой деятельности</param>
        /// <param name="marking">Признак торговли маркированными товарами</param>
        /// <param name="pawnShop">Признак осуществления ломбардной деятельности</param>
        /// <param name="vending">Признак применения в торговом автомате</param>
        /// <param name="catering">Признак осуществления услуг общ. питания</param>
        /// <param name="wholesale">Признак оптовой торговли</param>
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
            FfdVersionType ffdVersion,
            bool insurance,
            bool marking,
            bool pawnShop,
            bool vending,
            bool catering,
            bool wholesale)
        {
            if (registrationNumber.IsNullOrEmptyOrWhiteSpace())
            {
                throw new ArgumentException(
                    string.Format(
                        ValidationStrings.ResourceManager.GetString("StringFormatError"),
                        GetType().GetProperty(nameof(RegistrationNumber)).GetPropertyDisplayName()),
                    nameof(registrationNumber));
            }

            if (address.IsNullOrEmptyOrWhiteSpace())
            {
                throw new ArgumentException(
                    string.Format(ValidationStrings.ResourceManager.GetString("StringFormatError"),
                        GetType().GetProperty(nameof(address)).GetPropertyDisplayName()),
                    nameof(address));
            }

            if (fnsUrl.IsNullOrEmptyOrWhiteSpace() || !Regex.IsMatch(fnsUrl, RegexExtensions.UrlPattern))
            {
                throw new ArgumentException(
                    string.Format(ValidationStrings.ResourceManager.GetString("StringFormatError"),
                        GetType().GetProperty(nameof(FnsUrl)).GetPropertyDisplayName()),
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
            Insurance = insurance;
            Marking = marking;
            PawnShop = pawnShop;
            Vending = vending;
            Catering = catering;
            Wholesale = wholesale;
        }

        [JsonConstructor]
        private KKTParams() { }

        /// <summary>
        /// Регистрационный номер ККТ
        /// </summary>
        /// <list type="bullet">
        /// <item>Обязательное поле</item>
        /// </list>
        [Required(ErrorMessageResourceType = typeof(ValidationStrings), ErrorMessageResourceName = "RequiredError")]
        [Display(Name = "Регистрационный номер ККТ")]
        public string RegistrationNumber { get; }

        /// <summary>
        /// Адрес сайта ФНС
        /// </summary>
        /// <list type="bullet">
        /// <item>Обязательное поле</item>
        /// <item>Должно соответствовать регулярному выражению <see cref="RegexExtensions.UrlPattern"/></item>
        /// </list>
        [RegularExpression(
            RegexExtensions.UrlPattern,
            ErrorMessageResourceType = typeof(ValidationStrings), ErrorMessageResourceName = "StringFormatError")]
        [Required(ErrorMessageResourceType = typeof(ValidationStrings), ErrorMessageResourceName = "RequiredError")]
        [Display(Name = "Адрес сайта ФНС")]
        public string FnsUrl { get; }

        /// <summary>
        /// Работа в автономном режиме
        /// </summary>
        /// <list type="bullet">
        /// <item>Обязательное поле</item>
        /// </list>
        [Required(ErrorMessageResourceType = typeof(ValidationStrings), ErrorMessageResourceName = "RequiredError")]
        [Display(Name = "Работа в автономном режиме")]
        public bool OfflineMode { get; }

        /// <summary>
        /// Признак установки принтера в автомате
        /// </summary>
        /// <list type="bullet">
        /// <item>Обязательное поле</item>
        /// </list>
        [Required(ErrorMessageResourceType = typeof(ValidationStrings), ErrorMessageResourceName = "RequiredError")]
        [Display(Name = "Признак установки принтера в автомате")]
        public bool MachineInstallation { get; }

        /// <summary>
        /// Автоматизированная система печати БСО
        /// </summary>
        /// <list type="bullet">
        /// <item>Обязательное поле</item>
        /// </list>
        [Required(ErrorMessageResourceType = typeof(ValidationStrings), ErrorMessageResourceName = "RequiredError")]
        [Display(Name = "Автоматизированная система печати БСО")]
        public bool Bso { get; }

        /// <summary>
        /// Шифрование данных
        /// </summary>
        /// <list type="bullet">
        /// <item>Обязательное поле</item>
        /// </list>
        [Required(ErrorMessageResourceType = typeof(ValidationStrings), ErrorMessageResourceName = "RequiredError")]
        [Display(Name = "Шифрование данных")]
        public bool Encryption { get; }

        /// <summary>
        /// Признак автоматического режима
        /// </summary>
        /// <list type="bullet">
        /// <item>Обязательное поле</item>
        /// </list>
        [Required(ErrorMessageResourceType = typeof(ValidationStrings), ErrorMessageResourceName = "RequiredError")]
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
        [Required(ErrorMessageResourceType = typeof(ValidationStrings), ErrorMessageResourceName = "RequiredError")]
        [Display(Name = "ККТ для расчетов только в сети Интернет")]
        public bool Internet { get; }

        /// <summary>
        /// Использование для услуг
        /// </summary>
        /// <list type="bullet">
        /// <item>Обязательное поле</item>
        /// </list>
        [Required(ErrorMessageResourceType = typeof(ValidationStrings), ErrorMessageResourceName = "RequiredError")]
        [Display(Name = "Использование для услуг")]
        public bool Service { get; }

        /// <summary>
        /// Продажа подакцизного товара
        /// </summary>
        /// <list type="bullet">
        /// <item>Обязательное поле</item>
        /// </list>
        [Required(ErrorMessageResourceType = typeof(ValidationStrings), ErrorMessageResourceName = "RequiredError")]
        [Display(Name = "Продажа подакцизного товара")]
        public bool Excise { get; }

        /// <summary>
        /// Признак проведения азартных игр
        /// </summary>
        /// <list type="bullet">
        /// <item>Обязательное поле</item>
        /// </list>
        [Required(ErrorMessageResourceType = typeof(ValidationStrings), ErrorMessageResourceName = "RequiredError")]
        [Display(Name = "Признак проведения азартных игр")]
        public bool Gambling { get; }

        /// <summary>
        /// Признак проведения лотереи
        /// </summary>
        /// <list type="bullet">
        /// <item>Обязательное поле</item>
        /// </list>
        [Required(ErrorMessageResourceType = typeof(ValidationStrings), ErrorMessageResourceName = "RequiredError")]
        [Display(Name = "Признак проведения лотереи")]
        public bool Lottery { get; }

        /// <summary>
        /// Система налогообложения по умолчанию
        /// </summary>
        /// <list type="bullet">
        /// <item>Обязательное поле</item>
        /// </list>
        [Required(ErrorMessageResourceType = typeof(ValidationStrings), ErrorMessageResourceName = "RequiredError")]
        [Display(Name = "Система налогообложения по умолчанию")]
        public TaxationType DefaultTaxationType { get; }

        /// <summary>
        /// Канал обмена с ОФД
        /// </summary>
        /// <list type="bullet">
        /// <item>Обязательное поле</item>
        /// </list>
        [Required(ErrorMessageResourceType = typeof(ValidationStrings), ErrorMessageResourceName = "RequiredError")]
        [Display(Name = "Канал обмена с ОФД")]
        public OfdChannelType OfdChannel { get; }

        /// <summary>
        /// Версия ФФД
        /// </summary>
        /// <list type="bullet">
        /// <item>Обязательное поле</item>
        /// </list>
        [Required(ErrorMessageResourceType = typeof(ValidationStrings), ErrorMessageResourceName = "RequiredError")]
        [Display(Name = "Версия ФФД")]
        public FfdVersionType FfdVersion { get; }

        /// <summary>
        /// Место расчетов
        /// </summary>
        /// <list type="bullet">
        /// <item>Обязательное поле</item>
        /// </list>
        [Required(ErrorMessageResourceType = typeof(ValidationStrings), ErrorMessageResourceName = "RequiredError")]
        [Display(Name = "Место расчетов")]
        public string PaymentsAddress { get; }

        /// <summary>
        /// Признак осуществления страховой деятельности
        /// </summary>
        /// <list type="bullet">
        /// <item>Обязательное поле</item>
        /// </list>
        [Display(Name = "Признак осуществления страховой деятельности")]
        [Required(ErrorMessageResourceType = typeof(ValidationStrings), ErrorMessageResourceName = "RequiredError")]
        public bool Insurance { get; }

        /// <summary>
        /// Признак торговли маркированными товарами
        /// </summary>
        /// <list type="bullet">
        /// <item>Обязательное поле</item>
        /// </list>
        [Display(Name = "Признак торговли маркированными товарами")]
        [Required(ErrorMessageResourceType = typeof(ValidationStrings), ErrorMessageResourceName = "RequiredError")]
        public bool Marking { get; }

        /// <summary>
        /// Признак осуществления ломбардной деятельности
        /// </summary>
        /// <list type="bullet">
        /// <item>Обязательное поле</item>
        /// </list>
        [Display(Name = "Признак осуществления ломбардной деятельности")]
        [Required(ErrorMessageResourceType = typeof(ValidationStrings), ErrorMessageResourceName = "RequiredError")]
        public bool PawnShop { get; }

        /// <summary>
        /// Признак применения в торговом автомате
        /// </summary>
        /// <list type="bullet">
        /// <item>Обязательное поле</item>
        /// </list>
        [Display(Name = "Признак применения в торговом автомате")]
        [Required(ErrorMessageResourceType = typeof(ValidationStrings), ErrorMessageResourceName = "RequiredError")]
        public bool Vending { get; }

        /// <summary>
        /// Признак осуществления услуг общ. питания
        /// </summary>
        /// <list type="bullet">
        /// <item>Обязательное поле</item>
        /// </list>
        [Display(Name = "Признак осуществления услуг общ. питания")]
        [Required(ErrorMessageResourceType = typeof(ValidationStrings), ErrorMessageResourceName = "RequiredError")]
        public bool Catering { get; }

        /// <summary>
        /// Признак оптовой торговли
        /// </summary>
        /// <list type="bullet">
        /// <item>Обязательное поле</item>
        /// </list>
        [Display(Name = "Признак оптовой торговли")]
        [Required(ErrorMessageResourceType = typeof(ValidationStrings), ErrorMessageResourceName = "RequiredError")]
        public bool Wholesale { get; }
    }
}