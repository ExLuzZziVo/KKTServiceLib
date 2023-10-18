#region

using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;
using CoreLib.CORE.Helpers.Converters;

#endregion

namespace KKTServiceLib.Atol.Types.Enums
{
    /// <summary>
    /// Ресурс области уведомлений
    /// </summary>
    [JsonConverter(typeof(JsonStringEnumMemberConverter))]
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