#region

using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Serialization;

#endregion

namespace KKTServiceLib.Atol.Types.Enums
{
    /// <summary>
    /// Версия ФФД
    /// </summary>
    [JsonConverter(typeof(StringEnumConverter), typeof(CamelCaseNamingStrategy))]
    public enum FfdVersionType : byte
    {
        /// <summary>
        /// 1.0
        /// </summary>
        [EnumMember(Value = "1.0")] 
        [Display(Name = "1.0")]
        _10,

        /// <summary>
        /// 1.05
        /// </summary>
        [EnumMember(Value = "1.05")] 
        [Display(Name = "1.05")]
        _105,

        /// <summary>
        /// 1.1
        /// </summary>
        [EnumMember(Value = "1.1")] 
        [Display(Name = "1.1")]
        _11
    }
}