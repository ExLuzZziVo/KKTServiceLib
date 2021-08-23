#region

using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Serialization;

#endregion

namespace KKTServiceLib.Atol.Types.Enums
{
    /// <summary>
    /// Состояние смены
    /// </summary>
    [JsonConverter(typeof(StringEnumConverter), typeof(CamelCaseNamingStrategy))]
    public enum ShiftStatus : byte
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