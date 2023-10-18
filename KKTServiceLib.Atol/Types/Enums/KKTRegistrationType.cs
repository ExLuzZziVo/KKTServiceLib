#region

using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using CoreLib.CORE.Helpers.Converters;

#endregion

namespace KKTServiceLib.Atol.Types.Enums
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
        [Display(Name = "Регистрация ККТ")] Registration,

        /// <summary>
        /// Замена ФН
        /// </summary>
        [Display(Name = "Замена ФН")] FnChange,

        /// <summary>
        /// Изменение параметров регистрации
        /// </summary>
        [Display(Name = "Изменение параметров регистрации")]
        ChangeRegistrationParameters
    }
}