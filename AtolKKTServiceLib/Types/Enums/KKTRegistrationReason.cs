#region

using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Serialization;

#endregion

namespace AtolKKTServiceLib.Types.Enums
{
    /// <summary>
    /// Причина перерегистрации ККТ
    /// </summary>
    [JsonConverter(typeof(StringEnumConverter), typeof(CamelCaseNamingStrategy))]
    public enum KKTRegistrationReason : byte
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