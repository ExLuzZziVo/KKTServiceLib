using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace KKTServiceLib.Atol.Types.Common.MarkingCodes
{
    [Description("Результат проверки сведений о товаре")]
    public class ItemInfoCheckResult
    {
        /// <summary>
        /// Код маркировки был проверен ФН и (или) ИСМ
        /// </summary>
        [Display(Name = "Код маркировки был проверен ФН и (или) ИСМ")]
        public bool ImcCheckFlag { get; set; }

        /// <summary>
        /// Результат проверки КП КМ положительный (true) или отрицательный
        /// </summary>
        [Display(Name = "Результат проверки КП КМ положительный (true) или отрицательный")]
        public bool ImcCheckResult { get; set; }

        /// <summary>
        /// Проверка статуса ИСМ выполнена
        /// </summary>
        [Display(Name = "Проверка статуса ИСМ выполнена")]
        public bool ImcStatusInfo { get; set; }

        /// <summary>
        /// Корректность сведений от ИСМ о планируемом статусе товара
        /// </summary>
        [Display(Name = "Корректность сведений от ИСМ о планируемом статусе товара")]
        public bool ImcEstimatedStatusCorrect { get; set; }

        /// <summary>
        /// Результат проверки КП КМ сформирован ККТ, работающей в автономном режиме
        /// </summary>
        [Display(Name = "Результат проверки КП КМ сформирован ККТ, работающей в автономном режиме")]
        public bool EcrStandAloneFlag { get; set; }
    }
}