#region

using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

#endregion

namespace KKTServiceLib.Atol.Types.Operations.Fiscal.CreateExchangeStatusReport
{
    [Description("Счетчики итогов операций")]
    public class FnTotals
    {
        /// <summary>
        /// Приход
        /// </summary>
        [Display(Name = "Приход")]
        public PaymentsStat Sell { get; set; }

        /// <summary>
        /// Возврат прихода
        /// </summary>
        [Display(Name = "Возврат прихода")]
        public PaymentsStat SellReturn { get; set; }

        /// <summary>
        /// Расход
        /// </summary>
        [Display(Name = "Расход")]
        public PaymentsStat Buy { get; set; }

        /// <summary>
        /// Возврат расхода
        /// </summary>
        [Display(Name = "Возврат расхода")]
        public PaymentsStat BuyReturn { get; set; }
    }
}