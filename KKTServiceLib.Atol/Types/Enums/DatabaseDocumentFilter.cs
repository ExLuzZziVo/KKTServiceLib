#region

using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using CoreLib.CORE.Helpers.Converters;

#endregion

namespace KKTServiceLib.Atol.Types.Enums
{
    /// <summary>
    /// Фильтр документов БД ККТ
    /// </summary>
    [JsonConverter(typeof(JsonCamelCaseStringEnumConverter))]
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