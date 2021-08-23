#region

using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Serialization;

#endregion

namespace KKTServiceLib.Atol.Types.Enums
{
    /// <summary>
    /// Тип фискального документа
    /// </summary>
    [JsonConverter(typeof(StringEnumConverter), typeof(CamelCaseNamingStrategy))]
    public enum FiscalDocumentType : byte
    {
        /// <summary>
        /// Регистрация ККТ
        /// </summary>
        [Display(Name = "Регистрация ККТ")] Registration,

        /// <summary>
        /// Перерегистрация ККТ
        /// </summary>
        [Display(Name = "Перерегистрация ККТ")]
        ChangeRegistrationParameters,

        /// <summary>
        /// Закрытие ФН
        /// </summary>
        [Display(Name = "Закрытие ФН")] CloseArchive,

        /// <summary>
        /// Отчет о состоянии расчетов
        /// </summary>
        [Display(Name = "Отчет о состоянии расчетов")]
        OfdExchangeStatus,

        /// <summary>
        /// Открытие смены
        /// </summary>
        [Display(Name = "Открытие смены")] OpenShift,

        /// <summary>
        /// Закрытие смены
        /// </summary>
        [Display(Name = "Закрытие смены")] CloseShift,

        /// <summary>
        /// Чек
        /// </summary>
        [Display(Name = "Чек")] Receipt,

        /// <summary>
        /// Чек коррекции
        /// </summary>
        [Display(Name = "Чек коррекции")] ReceiptCorrection,

        /// <summary>
        /// БСО
        /// </summary>
        [Display(Name = "БСО")] Bso,

        /// <summary>
        /// БСО коррекции
        /// </summary>
        [Display(Name = "БСО коррекции")] BsoCorrection
    }
}