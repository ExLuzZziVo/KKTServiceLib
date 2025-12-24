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
        /// <param name="paymentsPlace">Место расчетов</param>
        /// <param name="encryption">Признак шифрования данных</param>
        /// <param name="offlineMode">Признак работы в автономном режиме</param>
        /// <param name="service">Признак применения ККТ для расчетов за услуги</param>
        /// <param name="bso">Признак автоматизированной системы печати БСО</param>
        /// <param name="internet">Признак применения ККТ для расчетов только в сети Интернет</param>
        /// <param name="autoMode">Признак автоматического режима</param>
        /// <param name="fnsUrl">Адрес сайта ФНС</param>
        /// <param name="machineInstallation">Признак работы в составе автоматического устройства для расчётов</param>
        /// <param name="excise">Признак работы с подакцизными товарами</param>
        /// <param name="gambling">Признак применения ККТ для приёма ставок и выплате выигрышей при проведении азартных игр</param>
        /// <param name="lottery">Признак применения ККТ для реализации лотерейных билетов и выплате выигрышей при проведении лотерей</param>
        /// <param name="defaultTaxationType">Система налогообложения по умолчанию</param>
        /// <param name="ofdChannel">Канал обмена с ОФД</param>
        /// <param name="ffdVersion">Версия ФФД</param>
        /// <param name="insurance">Признак применения ККТ при осуществлении деятельности по страхованию</param>
        /// <param name="marking">Признак работы с маркированными товарами</param>
        /// <param name="pawnShop">Признак применения ККТ в ломбардах</param>
        /// <param name="vending">Признак применения ККТ в торговом автомате</param>
        /// <param name="catering">Признак применения ККТ в общественном питании</param>
        /// <param name="wholesale">Признак применения ККТ в оптовой торговле с организациями и ИП</param>
        public KKTParams(string registrationNumber,
            string paymentsPlace,
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

            if (paymentsPlace.IsNullOrEmptyOrWhiteSpace())
            {
                throw new ArgumentException(
                    string.Format(ValidationStrings.ResourceManager.GetString("StringFormatError"),
                        GetType().GetProperty(nameof(paymentsPlace)).GetPropertyDisplayName()),
                    nameof(paymentsPlace));
            }

            if (fnsUrl.IsNullOrEmptyOrWhiteSpace() || !Regex.IsMatch(fnsUrl, RegexExtensions.UrlPattern))
            {
                throw new ArgumentException(
                    string.Format(ValidationStrings.ResourceManager.GetString("StringFormatError"),
                        GetType().GetProperty(nameof(FnsUrl)).GetPropertyDisplayName()),
                    nameof(fnsUrl));
            }

            RegistrationNumber = registrationNumber;
            PaymentsPlace = paymentsPlace;
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
        /// Признак работы в автономном режиме
        /// </summary>
        /// <list type="bullet">
        /// <item>Обязательное поле</item>
        /// </list>
        [Required(ErrorMessageResourceType = typeof(ValidationStrings), ErrorMessageResourceName = "RequiredError")]
        [Display(Name = "Признак работы в автономном режиме")]
        public bool OfflineMode { get; }

        /// <summary>
        /// Признак работы в составе автоматического устройства для расчётов
        /// </summary>
        /// <list type="bullet">
        /// <item>Обязательное поле</item>
        /// </list>
        [Required(ErrorMessageResourceType = typeof(ValidationStrings), ErrorMessageResourceName = "RequiredError")]
        [Display(Name = "Признак работы в составе автоматического устройства для расчётов")]
        public bool MachineInstallation { get; }

        /// <summary>
        /// Признак автоматизированной системы печати БСО
        /// </summary>
        /// <list type="bullet">
        /// <item>Обязательное поле</item>
        /// </list>
        [Required(ErrorMessageResourceType = typeof(ValidationStrings), ErrorMessageResourceName = "RequiredError")]
        [Display(Name = "Признак автоматизированной системы печати БСО")]
        public bool Bso { get; }

        /// <summary>
        /// Признак шифрования данных
        /// </summary>
        /// <list type="bullet">
        /// <item>Обязательное поле</item>
        /// </list>
        [Required(ErrorMessageResourceType = typeof(ValidationStrings), ErrorMessageResourceName = "RequiredError")]
        [Display(Name = "Признак шифрования данных")]
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
        /// Признак применения ККТ для расчетов только в сети Интернет
        /// </summary>
        /// <list type="bullet">
        /// <item>Обязательное поле</item>
        /// </list>
        [Required(ErrorMessageResourceType = typeof(ValidationStrings), ErrorMessageResourceName = "RequiredError")]
        [Display(Name = "Признак применения ККТ для расчетов только в сети Интернет")]
        public bool Internet { get; }

        /// <summary>
        /// Признак применения ККТ для расчетов за услуги
        /// </summary>
        /// <list type="bullet">
        /// <item>Обязательное поле</item>
        /// </list>
        [Required(ErrorMessageResourceType = typeof(ValidationStrings), ErrorMessageResourceName = "RequiredError")]
        [Display(Name = "Признак применения ККТ для расчетов за услуги")]
        public bool Service { get; }

        /// <summary>
        /// Признак работы с подакцизными товарами
        /// </summary>
        /// <list type="bullet">
        /// <item>Обязательное поле</item>
        /// </list>
        [Required(ErrorMessageResourceType = typeof(ValidationStrings), ErrorMessageResourceName = "RequiredError")]
        [Display(Name = "Признак работы с подакцизными товарами")]
        public bool Excise { get; }

        /// <summary>
        /// Признак применения ККТ для приёма ставок и выплате выигрышей при проведении азартных игр
        /// </summary>
        /// <list type="bullet">
        /// <item>Обязательное поле</item>
        /// </list>
        [Required(ErrorMessageResourceType = typeof(ValidationStrings), ErrorMessageResourceName = "RequiredError")]
        [Display(Name = "Признак применения ККТ для приёма ставок и выплате выигрышей при проведении азартных игр")]
        public bool Gambling { get; }

        /// <summary>
        /// Признак применения ККТ для реализации лотерейных билетов и выплате выигрышей при проведении лотерей
        /// </summary>
        /// <list type="bullet">
        /// <item>Обязательное поле</item>
        /// </list>
        [Required(ErrorMessageResourceType = typeof(ValidationStrings), ErrorMessageResourceName = "RequiredError")]
        [Display(Name = "Признак применения ККТ для реализации лотерейных билетов и выплате выигрышей при проведении лотерей")]
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
        public string PaymentsPlace { get; }

        /// <summary>
        /// Признак применения ККТ при осуществлении деятельности по страхованию
        /// </summary>
        /// <list type="bullet">
        /// <item>Обязательное поле</item>
        /// </list>
        [Display(Name = "Признак применения ККТ при осуществлении деятельности по страхованию")]
        [Required(ErrorMessageResourceType = typeof(ValidationStrings), ErrorMessageResourceName = "RequiredError")]
        public bool Insurance { get; }

        /// <summary>
        /// Признак работы с маркированными товарами
        /// </summary>
        /// <list type="bullet">
        /// <item>Обязательное поле</item>
        /// </list>
        [Display(Name = "Признак работы с маркированными товарами")]
        [Required(ErrorMessageResourceType = typeof(ValidationStrings), ErrorMessageResourceName = "RequiredError")]
        public bool Marking { get; }

        /// <summary>
        /// Признак применения ККТ в ломбардах
        /// </summary>
        /// <list type="bullet">
        /// <item>Обязательное поле</item>
        /// </list>
        [Display(Name = "Признак применения ККТ в ломбардах")]
        [Required(ErrorMessageResourceType = typeof(ValidationStrings), ErrorMessageResourceName = "RequiredError")]
        public bool PawnShop { get; }

        /// <summary>
        /// Признак применения ККТ в торговом автомате
        /// </summary>
        /// <list type="bullet">
        /// <item>Обязательное поле</item>
        /// </list>
        [Display(Name = "Признак применения ККТ в торговом автомате")]
        [Required(ErrorMessageResourceType = typeof(ValidationStrings), ErrorMessageResourceName = "RequiredError")]
        public bool Vending { get; }

        /// <summary>
        /// Признак применения ККТ в общественном питании
        /// </summary>
        /// <list type="bullet">
        /// <item>Обязательное поле</item>
        /// </list>
        [Display(Name = "Признак применения ККТ в общественном питании")]
        [Required(ErrorMessageResourceType = typeof(ValidationStrings), ErrorMessageResourceName = "RequiredError")]
        public bool Catering { get; }

        /// <summary>
        /// Признак применения ККТ в оптовой торговле с организациями и ИП
        /// </summary>
        /// <list type="bullet">
        /// <item>Обязательное поле</item>
        /// </list>
        [Display(Name = "Признак применения ККТ в оптовой торговле с организациями и ИП")]
        [Required(ErrorMessageResourceType = typeof(ValidationStrings), ErrorMessageResourceName = "RequiredError")]
        public bool Wholesale { get; }
    }
}
