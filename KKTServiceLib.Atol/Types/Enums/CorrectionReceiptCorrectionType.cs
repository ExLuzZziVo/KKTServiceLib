#region

using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using CoreLib.CORE.Helpers.Converters;

#endregion

namespace KKTServiceLib.Atol.Types.Enums
{
    /// <summary>
    /// Тип коррекции
    /// </summary>
    [JsonConverter(typeof(JsonCamelCaseStringEnumConverter))]
    public enum CorrectionReceiptCorrectionType : byte
    {
        /// <summary>
        /// Самостоятельно
        /// </summary>
        [Display(Name = "Самостоятельно")] Self,

        /// <summary>
        /// По предписанию
        /// </summary>
        [Display(Name = "По предписанию")] Instruction
    }
}