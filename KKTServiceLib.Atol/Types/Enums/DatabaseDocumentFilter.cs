using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Serialization;

namespace KKTServiceLib.Atol.Types.Enums
{
    /// <summary>
    /// Фильтр документов БД ККТ
    /// </summary>
    [JsonConverter(typeof(StringEnumConverter), typeof(CamelCaseNamingStrategy))]
    public enum DatabaseDocumentFilter : byte
    {
        /// <summary>
        /// По номерам смен
        /// </summary>
        [Display(Name = "По номерам смен")] ShiftNumber,

        /// <summary>
        /// По номерам документов
        /// </summary>
        [Display(Name = "По номерам документов")]
        FiscalDocumentNumber
    }
}