#region

using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Serialization;

#endregion

namespace AtolKKTServiceLib.Types.Enums
{
    /// <summary>
    /// Фаза жизни ФН
    /// </summary>
    [JsonConverter(typeof(StringEnumConverter), typeof(CamelCaseNamingStrategy))]
    public enum FnLivePhaseType : byte
    {
        /// <summary>
        /// Настройка ФН
        /// </summary>
        [Display(Name = "Настройка ФН")] Init,

        /// <summary>
        /// Готов к фискализации
        /// </summary>
        [Display(Name = "Готов к фискализации")]
        Configured,

        /// <summary>
        /// Фискальный режим
        /// </summary>
        [Display(Name = "Фискальный режим")] FiscalMode,

        /// <summary>
        /// Постфискальный режим (идет передача ФД в ОФД)
        /// </summary>
        [Display(Name = "Постфискальный режим (идет передача ФД в ОФД)")]
        PostFiscalMode,

        /// <summary>
        /// Закрыт (доступен только в режиме чтения данных из архива)
        /// </summary>
        [Display(Name = "Закрыт (доступен только в режиме чтения данных из архива)")]
        AccessArchive,

        /// <summary>
        /// Неизвестная фаза жизни
        /// </summary>
        [Display(Name = "Неизвестная фаза жизни")]
        Unknown
    }
}