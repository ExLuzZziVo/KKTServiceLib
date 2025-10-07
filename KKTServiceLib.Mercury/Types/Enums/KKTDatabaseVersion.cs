#region

using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;
using CoreLib.CORE.Helpers.Converters;

#endregion

namespace KKTServiceLib.Mercury.Types.Enums
{
    /// <summary>
    /// Версия формата базы товаров ККТ
    /// </summary>
    [JsonConverter(typeof(JsonStringEnumMemberConverter))]
    public enum KKTDatabaseVersion
    {
        /// <summary>
        /// 0.1
        /// </summary>
        [EnumMember(Value = "0.1")] [Display(Name = "0.1")]
        _01,

        /// <summary>
        /// 0.2
        /// </summary>
        [EnumMember(Value = "0.2")] [Display(Name = "0.2")]
        _02,

        /// <summary>
        /// 0.3
        /// </summary>
        [EnumMember(Value = "0.3")] [Display(Name = "0.3")]
        _03,

        /// <summary>
        /// 0.4
        /// </summary>
        [EnumMember(Value = "0.4")] [Display(Name = "0.4")]
        _04,

        /// <summary>
        /// 0.5
        /// </summary>
        [EnumMember(Value = "0.5")] [Display(Name = "0.5")]
        _05,

        /// <summary>
        /// 0.6
        /// </summary>
        [EnumMember(Value = "0.6")] [Display(Name = "0.6")]
        _06
    }
}
