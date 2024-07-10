#region

using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using CoreLib.CORE.Helpers.Converters;

#endregion

namespace KKTServiceLib.Atol.Types.Enums
{
    /// <summary>
    /// Состояние смены
    /// </summary>
    [JsonConverter(typeof(JsonCamelCaseStringEnumConverter))]
    public enum ShiftStatus: byte
    {
        /// <summary>
        /// Закрыта
        /// </summary>
        [Display(Name = "Закрыта")] Closed,

        /// <summary>
        /// Открыта
        /// </summary>
        [Display(Name = "Открыта")] Opened,

        /// <summary>
        /// Истекла
        /// </summary>
        [Display(Name = "Истекла")] Expired
    }
}