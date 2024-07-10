#region

using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;
using CoreLib.CORE.Helpers.Converters;

#endregion

namespace KKTServiceLib.Atol.Types.Enums
{
    /// <summary>
    /// Версия ФФД
    /// </summary>
    [JsonConverter(typeof(JsonStringEnumMemberConverter))]
    public enum FfdVersionType: byte
    {
        /// <summary>
        /// 1.05
        /// </summary>
        [EnumMember(Value = "1.05")] [Display(Name = "1.05")]
        _105,

        /// <summary>
        /// 1.1
        /// </summary>
        [EnumMember(Value = "1.1")] [Display(Name = "1.1")]
        _11,

        /// <summary>
        /// 1.2
        /// </summary>
        [EnumMember(Value = "1.2")] [Display(Name = "1.2")]
        _12
    }
}