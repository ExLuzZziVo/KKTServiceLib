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
    /// Канал связи с ОФД
    /// </summary>
    [JsonConverter(typeof(StringEnumConverter), typeof(CamelCaseNamingStrategy))]
    public enum OfdChannelType : byte
    {
        /// <summary>
        /// USB (EoU)
        /// </summary>
        [Display(Name = "USB (EoU)")] Usb,

        /// <summary>
        /// Ethernet
        /// </summary>
        [Display(Name = "Ethernet")] Ethernet,

        /// <summary>
        /// Wi-Fi
        /// </summary>
        [Display(Name = "Wi-Fi")] Wifi,

        /// <summary>
        /// GSM-модем
        /// </summary>
        [Display(Name = "GSM-модем")] Gsm,

        /// <summary>
        /// Средствами протокола ККТ
        /// </summary>
        [Display(Name = "Средствами протокола ККТ")]
        Proto
    }
}