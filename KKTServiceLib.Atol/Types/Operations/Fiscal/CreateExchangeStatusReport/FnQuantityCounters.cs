using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace KKTServiceLib.Atol.Types.Operations.Fiscal.CreateExchangeStatusReport
{
    [Description("Счетчики количеств операций")]
    public class FnQuantityCounters
    {
        /// <summary>
        /// Общее количество чеков (включая коррекции)
        /// </summary>
        [Display(Name = "Общее количество чеков (включая коррекции)")]
        public uint CountAll { get; set; }

        /// <summary>
        /// Номер смены
        /// </summary>
        [Display(Name = "Номер смены")]
        public uint ShiftNumber { get; set; }

        /// <summary>
        /// Приход
        /// </summary>
        [Display(Name = "Приход")]
        public FnQuantityCounter Sell { get; set; }

        /// <summary>
        /// Возврат прихода
        /// </summary>
        [Display(Name = "Возврат прихода")]
        public FnQuantityCounter SellReturn { get; set; }

        /// <summary>
        /// Расход
        /// </summary>
        [Display(Name = "Расход")]
        public FnQuantityCounter Buy { get; set; }

        /// <summary>
        /// Возврат расхода
        /// </summary>
        [Display(Name = "Возврат расхода")]
        public FnQuantityCounter BuyReturn { get; set; }
    }
}