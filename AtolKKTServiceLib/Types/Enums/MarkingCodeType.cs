using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Serialization;

namespace AtolKKTServiceLib.Types.Enums
{
    /// <summary>
    /// Тип маркировки
    /// </summary>
    [JsonConverter(typeof(StringEnumConverter), typeof(CamelCaseNamingStrategy))]
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