#region

using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

#endregion

namespace KKTServiceLib.Mercury.Types.Common
{
    [Description("Информация о чеке")]
    public class ReceiptInfo
    {
        /// <summary>
        /// Признак, определяющий: открыт ли чек
        /// </summary>
        [Display(Name = "Признак, определяющий: открыт ли чек")]
        public bool IsOpen { get; set; }

        /// <summary>
        /// Номер последнего закрытого чека в смене
        /// </summary>
        [Display(Name = "Номер последнего закрытого чека в смене")]
        public int? Num { get; set; }

        /// <summary>
        /// Количество предметов расчета в чековом буфере
        /// </summary>
        [Display(Name = "Количество предметов расчета в чековом буфере")]
        public int GoodsQty { get; set; }
    }
}