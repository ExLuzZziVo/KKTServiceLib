#region

using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using CoreLib.CORE.Helpers.Converters;

#endregion

namespace KKTServiceLib.Atol.Types.Enums
{
    /// <summary>
    /// Тип маркировки
    /// </summary>
    [JsonConverter(typeof(JsonCamelCaseStringEnumConverter))]
    public enum MarkingCodeType
    {
        /// <summary>
        /// Другой
        /// </summary>
        [Display(Name = "Другой")] Other,

        /// <summary>
        /// ЕГАИС 2.0
        /// </summary>
        [Display(Name = "ЕГАИС 2.0")] Egais20,

        /// <summary>
        /// ЕГАИС 3.0
        /// </summary>
        [Display(Name = "ЕГАИС 3.0")] Egais30
    }
}