#region

using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using KKTServiceLib.Atol.Types.Enums;
using KKTServiceLib.Atol.Types.Interfaces;
using KKTServiceLib.Shared.Resources;

#endregion

namespace KKTServiceLib.Atol.Types.Common.Document
{
    [Description("Картинка из памяти ККТ")]
    public class PictureDocumentParams : DocumentParams, ICommonDocumentElement
    {
        /// <summary>
        /// Картинка из памяти ККТ
        /// </summary>
        /// <param name="pictureNumber">Номер картинки</param>
        public PictureDocumentParams(uint pictureNumber) : base(PrintDocumentType.PictureFromMemory)
        {
            PictureNumber = pictureNumber;
        }

        /// <summary>
        /// Номер картинки
        /// </summary>
        /// <list type="bullet">
        /// <item>Обязательное поле</item>
        /// </list>
        [Required(ErrorMessageResourceType = typeof(ErrorStrings), ErrorMessageResourceName = "RequiredError")]
        [Display(Name = "Номер картинки")]
        public uint PictureNumber { get; }

        /// <summary>
        /// Выравнивание
        /// </summary>
        [Display(Name = "Выравнивание")]
        public AlignmentType Alignment { get; set; }
    }
}