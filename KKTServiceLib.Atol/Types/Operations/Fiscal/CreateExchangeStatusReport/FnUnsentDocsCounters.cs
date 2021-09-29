using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace KKTServiceLib.Atol.Types.Operations.Fiscal.CreateExchangeStatusReport
{
    [Description("Счетчики итогов непереданных документов")]
    public class FnUnsentDocsCounters
    {
        /// <summary>
        /// Общее количество чеков
        /// </summary>
        [Display(Name = "Общее количество чеков")]
        public uint CountAll { get; set; }

        /// <summary>
        /// Приход
        /// </summary>
        [Display(Name = "Приход")]
        public FnUnsentDocsCounter Sell { get; set; }

        /// <summary>
        /// Возврат прихода
        /// </summary>
        [Display(Name = "Возврат прихода")]
        public FnUnsentDocsCounter SellReturn { get; set; }

        /// <summary>
        /// Расход
        /// </summary>
        [Display(Name = "Расход")]
        public FnUnsentDocsCounter Buy { get; set; }

        /// <summary>
        /// Возврат расхода
        /// </summary>
        [Display(Name = "Возврат расхода")]
        public FnUnsentDocsCounter BuyReturn { get; set; }
    }
}