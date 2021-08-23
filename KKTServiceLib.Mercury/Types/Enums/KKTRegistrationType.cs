using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Serialization;

namespace KKTServiceLib.Mercury.Types.Enums
{
    /// <summary>
    /// Тип регистрации ККТ
    /// </summary>
    [JsonConverter(typeof(StringEnumConverter), typeof(CamelCaseNamingStrategy))]
    public enum KKTRegistrationType : byte
    {
        /// <summary>
        /// Регистрация ККТ
        /// </summary>
        [Display(Name = "Регистрация ККТ")] RegisterKKT,

        /// <summary>
        /// Перерегистрация ККТ
        /// </summary>
        [Display(Name = "Перерегистрация ККТ")]
        ReregisterKKT,
    }
}