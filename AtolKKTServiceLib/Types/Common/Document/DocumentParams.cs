#region

using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using AtolKKTServiceLib.Types.Enums;
using KKTServiceLib.Shared.Resources;

#endregion

namespace AtolKKTServiceLib.Types.Common.Document
{
    [Description("Элемент документа")]
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
        [Required(ErrorMessageResourceType = typeof(ErrorStrings), ErrorMessageResourceName = "RequiredError")]
        [Display(Name = "Тип элемента")]
        public PrintDocumentType Type { get; }
    }
}