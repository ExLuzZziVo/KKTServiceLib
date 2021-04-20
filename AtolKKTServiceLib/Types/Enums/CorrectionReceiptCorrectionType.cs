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
    /// Тип коррекции
    /// </summary>
    [JsonConverter(typeof(StringEnumConverter), typeof(CamelCaseNamingStrategy))]
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