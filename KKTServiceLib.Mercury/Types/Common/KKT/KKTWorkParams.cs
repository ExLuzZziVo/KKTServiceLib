using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using KKTServiceLib.Shared.Resources;
using Newtonsoft.Json;

namespace KKTServiceLib.Mercury.Types.Common.KKT
{
    [Description("Параметры работы ККТ")]
    public class KKTWorkParams
    {
        /// <summary>
        /// Параметры работы ККТ
        /// </summary>
        /// <param name="encryption">Шифрование данных</param>
        /// <param name="offlineMode">Работа в автономном режиме</param>
        /// <param name="service">Использование для услуг</param>
        /// <param name="bso">Автоматизированная система печати БСО</param>
        /// <param name="internet">ККТ для расчетов только в сети Интернет</param>
        /// <param name="autoMode">Работа в составе автоматического устройства для расчетов</param>
        public KKTWorkParams(bool encryption, bool offlineMode, bool service, bool bso, bool internet, bool autoMode)
        {
            EncryptData = encryption;
            Offline = offlineMode;
            ForService = service;
            ASBSO = bso;
            ForInternet = internet;
            Automat = autoMode;
        }

        [JsonConstructor]
        protected internal KKTWorkParams() { }

        /// <summary>
        /// Шифрование данных
        /// </summary>
        /// <list type="bullet">
        /// <item>Обязательное поле</item>
        /// </list>
        [Required(ErrorMessageResourceType = typeof(ErrorStrings), ErrorMessageResourceName = "RequiredError")]
        [Display(Name = "Шифрование данных")]
        public bool EncryptData { get; }

        /// <summary>
        /// Работа в автономном режиме
        /// </summary>
        /// <list type="bullet">
        /// <item>Обязательное поле</item>
        /// </list>
        [Required(ErrorMessageResourceType = typeof(ErrorStrings), ErrorMessageResourceName = "RequiredError")]
        [Display(Name = "Работа в автономном режиме")]
        public bool Offline { get; }

        /// <summary>
        /// Использование для услуг
        /// </summary>
        /// <list type="bullet">
        /// <item>Обязательное поле</item>
        /// </list>
        [Required(ErrorMessageResourceType = typeof(ErrorStrings), ErrorMessageResourceName = "RequiredError")]
        [Display(Name = "Использование для услуг")]
        public bool ForService { get; }

        /// <summary>
        /// Автоматизированная система печати БСО
        /// </summary>
        /// <list type="bullet">
        /// <item>Обязательное поле</item>
        /// </list>
        [Required(ErrorMessageResourceType = typeof(ErrorStrings), ErrorMessageResourceName = "RequiredError")]
        [Display(Name = "Автоматизированная система печати БСО")]
        public bool ASBSO { get; }

        /// <summary>
        /// ККТ для расчетов только в сети Интернет
        /// </summary>
        /// <list type="bullet">
        /// <item>Обязательное поле</item>
        /// </list>
        [Required(ErrorMessageResourceType = typeof(ErrorStrings), ErrorMessageResourceName = "RequiredError")]
        [Display(Name = "ККТ для расчетов только в сети Интернет")]
        public bool ForInternet { get; }

        /// <summary>
        /// Работа в составе автоматического устройства для расчетов
        /// </summary>
        /// <list type="bullet">
        /// <item>Обязательное поле</item>
        /// </list>
        [Required(ErrorMessageResourceType = typeof(ErrorStrings), ErrorMessageResourceName = "RequiredError")]
        [Display(Name = "Работа в составе автоматического устройства для расчетов")]
        public bool Automat { get; }

        /// <summary>
        /// Номер автомата
        /// </summary>
        /// <list type="bullet">
        /// <item>Обязательное поле, если <see cref="Automat"/> равен true</item>
        /// </list>
        [Display(Name = "Номер автомата")]
        public string AutomatNum { get; set; }

        /// <summary>
        /// Продажа подакцизного товара
        /// </summary>
        /// <remarks>
        /// Значение по умолчанию: false
        /// </remarks>
        [Display(Name = "Продажа подакцизного товара")]
        public bool? ForExcisableGoods { get; set; } = false;
    }
}