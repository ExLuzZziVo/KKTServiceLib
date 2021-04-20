#region

using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

#endregion

namespace AtolKKTServiceLib.Types.Common.CashDrawer
{
    [Description("Состояние ДЯ")]
    public class CashDrawerStatus
    {
        /// <summary>
        /// Денежный ящик открыт
        /// </summary>
        [Display(Name = "Денежный ящик открыт")]
        public bool CashDrawerOpened { get; set; }
    }
}