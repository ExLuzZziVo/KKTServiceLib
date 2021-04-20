#region

using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using AtolKKTServiceLib.Types.Common.CashDrawer;

#endregion

namespace AtolKKTServiceLib.Types.Operations.Fiscal.Cash.CreateCashManipulation
{
    [Description("Результат операции по внесению или выплате наличных")]
    public class CreateCashManipulationResult
    {
        /// <summary>
        /// Сумма в денежном ящике
        /// </summary>
        [Display(Name = "Сумма в денежном ящике")]
        public CashDrawerCounter Counters { get; set; }
    }
}