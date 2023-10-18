#region

using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using CoreLib.CORE.Helpers.Converters;

#endregion

namespace KKTServiceLib.Mercury.Types.Enums
{
    /// <summary>
    /// Тип регистрации ККТ
    /// </summary>
    [JsonConverter(typeof(JsonCamelCaseStringEnumConverter))]
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
        ReregisterKKT
    }
}