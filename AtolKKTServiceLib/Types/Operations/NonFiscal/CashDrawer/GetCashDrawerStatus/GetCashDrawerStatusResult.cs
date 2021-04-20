#region

using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using AtolKKTServiceLib.Types.Common.CashDrawer;

#endregion

namespace AtolKKTServiceLib.Types.Operations.NonFiscal.CashDrawer.GetCashDrawerStatus
{
    [Description("Результат запроса состояния денежного ящика")]
    public class GetCashDrawerStatusResult
    {
        /// <summary>
        /// Состояние денежного ящика
        /// </summary>
        [Display(Name = "Состояние денежного ящика")]
        public CashDrawerStatus CashDrawerStatus { get; set; }

        /// <summary>
        /// Состояние счетчиков наличности
        /// </summary>
        [Display(Name = "Состояние счетчиков наличности")]
        public CashDrawerCounter Counters { get; set; }
    }
}