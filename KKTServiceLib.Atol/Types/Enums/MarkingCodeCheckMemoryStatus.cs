using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Serialization;

namespace KKTServiceLib.Atol.Types.Enums
{
    /// <summary>
    /// Ресурс области уведомлений
    /// </summary>
    [JsonConverter(typeof(StringEnumConverter), typeof(CamelCaseNamingStrategy))]
    public enum MarkingCodeCheckMemoryStatus : byte
    {
        /// <summary>
        /// Область заполнена менее чем на 50%
        /// </summary>
        [Display(Name = "Область заполнена менее чем на 50%")]
        Less50,

        /// <summary>
        /// Область заполнена от 50 до 80%
        /// </summary>
        [Display(Name = "Область заполнена от 50 до 80%")] [EnumMember(Value = "50to80")]
        _50to80,

        /// <summary>
        /// Область заполнена от 80 до 90%
        /// </summary>
        [Display(Name = "Область заполнена от 80 до 90%")] [EnumMember(Value = "80to90")]
        _80to90,

        /// <summary>
        /// Область заполнена более чем на 90%
        /// </summary>
        [Display(Name = "Область заполнена более чем на 90%")]
        More90,

        /// <summary>
        /// Область полностью заполнена
        /// </summary>
        [Display(Name = "Область полностью заполнена")]
        OutOfMemory
    }
}