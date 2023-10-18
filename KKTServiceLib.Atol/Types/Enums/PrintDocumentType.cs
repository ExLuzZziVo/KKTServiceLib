#region

using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using CoreLib.CORE.Helpers.Converters;

#endregion

namespace KKTServiceLib.Atol.Types.Enums
{
    /// <summary>
    /// Тип документа для печати
    /// </summary>
    [JsonConverter(typeof(JsonCamelCaseStringEnumConverter))]
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
        PictureFromMemory,

        /// <summary>
        /// Картинка (массив пикселей)
        /// </summary>
        [Display(Name = "Картинка (массив пикселей)")]
        Pixels
    }
}