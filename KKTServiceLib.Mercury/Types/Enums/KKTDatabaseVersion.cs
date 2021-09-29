using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Serialization;

namespace KKTServiceLib.Mercury.Types.Enums
{
    /// <summary>
    /// Версия формата базы товаров ККТ
    /// </summary>
    [JsonConverter(typeof(StringEnumConverter), typeof(CamelCaseNamingStrategy))]
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
        _04
    }
}