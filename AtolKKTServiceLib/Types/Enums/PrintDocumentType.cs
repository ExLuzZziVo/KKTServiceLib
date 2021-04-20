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
    /// Тип документа для печати
    /// </summary>
    [JsonConverter(typeof(StringEnumConverter), typeof(CamelCaseNamingStrategy))]
    public enum PrintDocumentType : byte
    {
        /// <summary>
        /// Товар
        /// </summary>
        [Display(Name = "Товар")] Position,

        /// <summary>
        /// Текстовая строка
        /// </summary>
        [Display(Name = "Текстовая строка")] Text,

        /// <summary>
        /// Штрихкод
        /// </summary>
        [Display(Name = "Штрихкод")] Barcode,

        /// <summary>
        /// Дополнительный реквизит пользователя
        /// </summary>
        [Display(Name = "Дополнительный реквизит пользователя")]
        UserAttribute,

        /// <summary>
        /// Дополнительный реквизит чека (БСО)
        /// </summary>
        [Display(Name = "Дополнительный реквизит чека (БСО)")]
        AdditionalAttribute,

        /// <summary>
        /// Картинка из памяти ККТ
        /// </summary>
        [Display(Name = "Картинка из памяти ККТ")]
        PictureFromMemory
    }
}