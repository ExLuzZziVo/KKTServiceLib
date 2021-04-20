#region

using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

#endregion

namespace AtolKKTServiceLib.Types.Operations.NonFiscal.GetOverallTotals
{
    [Description("Результат запроса необнуляемых итогов")]
    public class GetOverallTotalsResult
    {
        /// <summary>
        /// Необнуляемые итоги
        /// </summary>
        [Display(Name = "Необнуляемые итоги")]
        public OverallTotals OverallTotals { get; set; }
    }
}