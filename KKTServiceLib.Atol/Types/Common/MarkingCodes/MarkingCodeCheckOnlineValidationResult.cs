#region

using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using KKTServiceLib.Atol.Types.Enums;

#endregion

namespace KKTServiceLib.Atol.Types.Common.MarkingCodes
{
    [Description("Результат проверки на сервере ИСМ")]
    public class MarkingCodeCheckOnlineValidationResult
    {
        /// <summary>
        /// Результат проверки сведений о товаре
        /// </summary>
        [Display(Name = "Результат проверки сведений о товаре")]
        public ItemInfoCheckResult ItemInfoCheckResult { get; set; }

        /// <summary>
        /// Сведения о статусе товара
        /// </summary>
        [Display(Name = "Сведения о статусе товара")]
        public MarkingCodeCheckItemStatusResult? MarkOperatorItemStatus { get; set; }

        /// <summary>
        /// Результаты обработки запроса
        /// </summary>
        [Display(Name = "Результаты обработки запроса")]
        public IsmResponseResult MarkOperatorResponse { get; set; }

        /// <summary>
        /// Код обработки запроса
        /// </summary>
        [Display(Name = "Код обработки запроса")]
        public MarkingCodeCheckResponseResult? MarkOperatorResponseResult { get; set; }

        /// <summary>
        /// Тип кода маркировки
        /// </summary>
        [Display(Name = "Тип кода маркировки")]
        public MarkingCodeCheckImcType? ImcType { get; set; }

        /// <summary>
        /// Идентификатор товара
        /// </summary>
        [Display(Name = "Идентификатор товара")]
        public string ImcBarcode { get; set; }

        /// <summary>
        /// Режим обработки кода товара
        /// </summary>
        [Display(Name = "Режим обработки кода товара")]
        public int ImcModeProcessing { get; set; }
    }
}