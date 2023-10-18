#region

using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using CoreLib.CORE.Resources;
using KKTServiceLib.Atol.Types.Enums;

#endregion

namespace KKTServiceLib.Atol.Types.Common.Document
{
    [Description("Элемент документа")]
    [JsonDerivedType(typeof(AdditionalAttributeDocumentParams))]
    [JsonDerivedType(typeof(BarcodeDocumentParams))]
    [JsonDerivedType(typeof(PictureDocumentParams))]
    [JsonDerivedType(typeof(PixelsDocumentParams))]
    [JsonDerivedType(typeof(PositionDocumentParams))]
    [JsonDerivedType(typeof(PositionDocumentParams_12))]
    [JsonDerivedType(typeof(TextDocumentParams))]
    [JsonDerivedType(typeof(UserAttributeDocumentParams))]
    public abstract class DocumentParams
    {
        /// <summary>
        /// Элемент документа
        /// </summary>
        /// <param name="type">Тип элемента</param>
        public DocumentParams(PrintDocumentType type)
        {
            Type = type;
        }

        /// <summary>
        /// Тип элемента
        /// </summary>
        /// <list type="bullet">
        /// <item>Обязательное поле</item>
        /// </list>
        [Required(ErrorMessageResourceType = typeof(ValidationStrings), ErrorMessageResourceName = "RequiredError")]
        [Display(Name = "Тип элемента")]
        public PrintDocumentType Type { get; }
    }
}