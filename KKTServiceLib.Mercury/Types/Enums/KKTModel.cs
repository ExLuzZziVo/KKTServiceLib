using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Serialization;

namespace KKTServiceLib.Mercury.Types.Enums
{
    /// <summary>
    /// Модель ККТ
    /// </summary>
    [JsonConverter(typeof(StringEnumConverter), typeof(CamelCaseNamingStrategy))]
    public enum KKTModel : byte
    {
        /// <summary>
        /// 119Ф
        /// </summary>
        [Display(Name = "119Ф")] [EnumMember(Value = "119F")]
        _119F,

        /// <summary>
        /// 115Ф/130Ф/180Ф/185Ф
        /// </summary>
        [Display(Name = "115Ф/130Ф/180Ф/185Ф")] [EnumMember(Value = "185F")]
        _185F
    }
}