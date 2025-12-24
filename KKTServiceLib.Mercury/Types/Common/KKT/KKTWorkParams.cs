#region

using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using CoreLib.CORE.Resources;
using KKTServiceLib.Mercury.Types.Operations.Fiscal.KKTRegistration.GetKKTRegistrationInfo;

#endregion

namespace KKTServiceLib.Mercury.Types.Common.KKT
{
    [Description("Параметры работы ККТ")]
    [JsonDerivedType(typeof(KKTWorkParamsInfo))]
    public class KKTWorkParams
    {
        /// <summary>
        /// Параметры работы ККТ
        /// </summary>
        /// <param name="encryption">Признак шифрования данных</param>
        /// <param name="offlineMode">Признак работы в автономном режиме</param>
        /// <param name="service">Признак применения ККТ для расчетов за услуги</param>
        /// <param name="bso">Признак автоматизированной системы печати БСО</param>
        /// <param name="internet">Признак применения ККТ для расчетов только в сети Интернет</param>
        /// <param name="autoMode">Признак автоматического режима</param>
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
        /// Признак шифрования данных
        /// </summary>
        /// <list type="bullet">
        /// <item>Обязательное поле</item>
        /// </list>
        [Required(ErrorMessageResourceType = typeof(ValidationStrings), ErrorMessageResourceName = "RequiredError")]
        [Display(Name = "Признак шифрования данных")]
        public bool EncryptData { get; }

        /// <summary>
        /// Признак работы в автономном режиме
        /// </summary>
        /// <list type="bullet">
        /// <item>Обязательное поле</item>
        /// </list>
        [Required(ErrorMessageResourceType = typeof(ValidationStrings), ErrorMessageResourceName = "RequiredError")]
        [Display(Name = "Признак работы в автономном режиме")]
        public bool Offline { get; }

        /// <summary>
        /// Признак применения ККТ для расчетов за услуги
        /// </summary>
        /// <list type="bullet">
        /// <item>Обязательное поле</item>
        /// </list>
        [Required(ErrorMessageResourceType = typeof(ValidationStrings), ErrorMessageResourceName = "RequiredError")]
        [Display(Name = "Признак применения ККТ для расчетов за услуги")]
        public bool ForService { get; }

        /// <summary>
        /// Признак автоматизированной системы печати БСО
        /// </summary>
        /// <list type="bullet">
        /// <item>Обязательное поле</item>
        /// </list>
        [Required(ErrorMessageResourceType = typeof(ValidationStrings), ErrorMessageResourceName = "RequiredError")]
        [Display(Name = "Признак автоматизированной системы печати БСО")]
        public bool ASBSO { get; }

        /// <summary>
        /// Признак применения ККТ для расчетов только в сети Интернет
        /// </summary>
        /// <list type="bullet">
        /// <item>Обязательное поле</item>
        /// </list>
        [Required(ErrorMessageResourceType = typeof(ValidationStrings), ErrorMessageResourceName = "RequiredError")]
        [Display(Name = "Признак применения ККТ для расчетов только в сети Интернет")]
        public bool ForInternet { get; }

        /// <summary>
        /// Признак автоматического режима
        /// </summary>
        /// <list type="bullet">
        /// <item>Обязательное поле</item>
        /// </list>
        [Required(ErrorMessageResourceType = typeof(ValidationStrings), ErrorMessageResourceName = "RequiredError")]
        [Display(Name = "Признак автоматического режима")]
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
        /// Признак работы с подакцизными товарами
        /// </summary>
        /// <remarks>
        /// Значение по умолчанию: false
        /// </remarks>
        [Display(Name = "Признак работы с подакцизными товарами")]
        public bool? ForExcisableGoods { get; set; } = false;
    }
}
