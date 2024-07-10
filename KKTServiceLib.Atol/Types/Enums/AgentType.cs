#region

using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using CoreLib.CORE.Helpers.Converters;

#endregion

namespace KKTServiceLib.Atol.Types.Enums
{
    /// <summary>
    /// Тип агента
    /// </summary>
    [JsonConverter(typeof(JsonCamelCaseStringEnumConverter))]
    public enum AgentType: byte
    {
        /// <summary>
        /// Банковский платежный агент
        /// </summary>
        [Display(Name = "Банковский платежный агент")]
        BankPayingAgent,

        /// <summary>
        /// Банковский платежный субагент
        /// </summary>
        [Display(Name = "Банковский платежный субагент")]
        BankPayingSubagent,

        /// <summary>
        /// Платежный агент
        /// </summary>
        [Display(Name = "Платежный агент")] PayingAgent,

        /// <summary>
        /// Платежный субагент
        /// </summary>
        [Display(Name = "Платежный субагент")] PayingSubagent,

        /// <summary>
        /// Поверенный
        /// </summary>
        [Display(Name = "Поверенный")] Attorney,

        /// <summary>
        /// Комиссионер
        /// </summary>
        [Display(Name = "Комиссионер")] CommissionAgent,

        /// <summary>
        /// Другой тип агента
        /// </summary>
        [Display(Name = "Другой тип агента")] Another
    }
}