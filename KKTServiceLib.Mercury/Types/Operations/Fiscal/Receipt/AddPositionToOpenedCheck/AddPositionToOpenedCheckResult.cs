#region

using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

#endregion

namespace KKTServiceLib.Mercury.Types.Operations.Fiscal.Receipt.AddPositionToOpenedCheck
{
    [Description("Результат добавления позиции в открытый фискальный чек")]
    public class AddPositionToOpenedCheckResult : OperationResult
    {
        /// <summary>
        /// Номер текущей кассовой смены
        /// </summary>
        [Display(Name = "Номер текущей кассовой смены")]
        public int ShiftNum { get; set; }

        /// <summary>
        /// Номер чека
        /// </summary>
        [Display(Name = "Номер чека")]
        public int? CheckNum { get; set; }

        /// <summary>
        /// Порядковый номер добавленного предмета расчета
        /// </summary>
        [Display(Name = "Порядковый номер добавленного предмета расчета")]
        public int GoodsNum { get; set; }
    }
}