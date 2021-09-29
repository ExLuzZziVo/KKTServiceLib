using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Serialization;

namespace KKTServiceLib.Atol.Types.Enums
{
    /// <summary>
    /// Состояние проверки КМ
    /// </summary>
    [JsonConverter(typeof(StringEnumConverter), typeof(CamelCaseNamingStrategy))]
    public enum MarkingCodeCheckCurrentStatus : byte
    {
        /// <summary>
        /// Работа с КМ временно заблокирована (переполнение области уведомлений)
        /// </summary>
        [Display(Name = "Работа с КМ временно заблокирована (переполнение области уведомлений)")]
        Blocked,

        /// <summary>
        /// Нет КМ на проверке
        /// </summary>
        [Display(Name = "Нет КМ на проверке")] NoImcForCheck,

        /// <summary>
        /// Передан КМ на проверку
        /// </summary>
        [Display(Name = "Передан КМ на проверку")]
        ReceivedImc,

        /// <summary>
        /// Сформирован запрос о статусе КМ
        /// </summary>
        [Display(Name = "Сформирован запрос о статусе КМ")]
        RequestedImcStatus,

        /// <summary>
        /// Получен ответ на запрос о статусе КМ
        /// </summary>
        [Display(Name = "Получен ответ на запрос о статусе КМ")]
        ReceivedImcStatus
    }
}