using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace KKTServiceLib.Mercury.Types.Operations.Fiscal.Receipt.CloseCheck
{
    [Description("Результат закрытия фискального чека")]
    public class CloseCheckResult : FiscalOperationResult
    {
        /// <summary>
        /// Номер текущей кассовой смены
        /// </summary>
        [Display(Name = "Номер текущей кассовой смены")]
        public int ShiftNum { get; set; }

        /// <summary>
        /// Номер закрытого чека
        /// </summary>
        [Display(Name = "Номер закрытого чека")]
        public int? CheckNum { get; set; }
    }
}