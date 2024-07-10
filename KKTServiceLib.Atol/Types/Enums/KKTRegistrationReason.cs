#region

using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using CoreLib.CORE.Helpers.Converters;

#endregion

namespace KKTServiceLib.Atol.Types.Enums
{
    /// <summary>
    /// Причина перерегистрации ККТ
    /// </summary>
    [JsonConverter(typeof(JsonCamelCaseStringEnumConverter))]
    public enum KKTRegistrationReason: byte
    {
        /// <summary>
        /// Смена ОФД
        /// </summary>
        [Display(Name = "Смена ОФД")] OfdChange,

        /// <summary>
        /// Изменение реквизитов
        /// </summary>
        [Display(Name = "Изменение реквизитов")]
        AttributesChange,

        /// <summary>
        /// Изменение настроек ККТ
        /// </summary>
        [Display(Name = "Изменение настроек ККТ")]
        SettingsChange
    }
}