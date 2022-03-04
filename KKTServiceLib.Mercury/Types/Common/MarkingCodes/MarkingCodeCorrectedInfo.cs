using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace KKTServiceLib.Mercury.Types.Common.MarkingCodes
{
    [Description("Исправленная информация о коде маркировки")]
    public class MarkingCodeCorrectedInfo : MarkingCodeInfo
    {
        /// <summary>
        /// Режим обработки кода товара
        /// </summary>
        [Display(Name = "Режим обработки кода товара")]
        public int? ProcessingMode { get; set; }
    }
}