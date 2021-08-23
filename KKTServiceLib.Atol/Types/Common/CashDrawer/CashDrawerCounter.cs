#region

using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

#endregion

namespace KKTServiceLib.Atol.Types.Common.CashDrawer
{
    [Description("Состояние счетчиков наличности")]
    public class CashDrawerCounter
    {
        /// <summary>
        /// Сумма в денежном ящике
        /// </summary>
        [Display(Name = "Сумма в денежном ящике")]
        public decimal CashSum { get; set; }
    }
}