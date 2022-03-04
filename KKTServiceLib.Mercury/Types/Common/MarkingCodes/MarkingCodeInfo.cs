using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using KKTServiceLib.Mercury.Types.Enums;

namespace KKTServiceLib.Mercury.Types.Common.MarkingCodes
{
    [Description("Информация о коде маркировки")]
    public class MarkingCodeInfo
    {
        /// <summary>
        /// Тип кода маркировки
        /// </summary>
        [Display(Name = "Тип кода маркировки")]
        public MarkingCodeCheckImcType? McType { get; set; }

        /// <summary>
        /// Идентификатор товара
        /// </summary>
        [Display(Name = "Идентификатор товара")]
        public string McGoodsID { get; set; }
    }
}