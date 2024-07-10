#region

using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

#endregion

namespace KKTServiceLib.Mercury.Types.Operations.Fiscal.Receipt.OpenCheck
{
    [Description("Результат открытия фискального чека")]
    public class OpenCheckResult: OperationResult
    {
        /// <summary>
        /// Номер текущей кассовой смены
        /// </summary>
        [Display(Name = "Номер текущей кассовой смены")]
        public int ShiftNum { get; set; }

        /// <summary>
        /// Номер открытого чека
        /// </summary>
        [Display(Name = "Номер открытого чека")]
        public int CheckNum { get; set; }
    }
}