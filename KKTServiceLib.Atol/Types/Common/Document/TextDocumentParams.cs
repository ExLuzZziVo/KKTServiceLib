#region

using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using KKTServiceLib.Atol.Types.Enums;
using KKTServiceLib.Atol.Types.Interfaces;

#endregion

namespace KKTServiceLib.Atol.Types.Common.Document
{
    [Description("Текстовый элемент")]
    public class TextDocumentParams : DocumentParams, ICommonDocumentElement
    {
        /// <summary>
        /// Текстовый элемент
        /// </summary>
        public TextDocumentParams() : base(PrintDocumentType.Text)
        {
        }

        /// <summary>
        /// Текстовый элемент
        /// </summary>
        /// <param name="text">Строка для печати</param>
        public TextDocumentParams(string text) : base(PrintDocumentType.Text)
        {
            Text = text ?? throw new ArgumentNullException(nameof(text));
        }

        /// <summary>
        /// Строка для печати
        /// </summary>
        [Display(Name = "Строка для печати")]
        public string Text { get; }

        /// <summary>
        /// Перенос
        /// </summary>
        [Display(Name = "Перенос")]
        public WrapType Wrap { get; set; }

        /// <summary>
        /// Шрифт
        /// </summary>
        [Display(Name = "Шрифт")]
        public ushort? Font { get; set; }

        /// <summary>
        /// Двойная ширина
        /// </summary>
        [Display(Name = "Двойная ширина")]
        public bool DoubleWidth { get; set; }

        /// <summary>
        /// Двойная высота
        /// </summary>
        [Display(Name = "Двойная высота")]
        public bool DoubleHeight { get; set; }

        /// <summary>
        /// Выравнивание
        /// </summary>
        [Display(Name = "Выравнивание")]
        public AlignmentType Alignment { get; set; }
    }
}