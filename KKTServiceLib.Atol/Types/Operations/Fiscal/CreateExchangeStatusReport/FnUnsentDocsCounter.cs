using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace KKTServiceLib.Atol.Types.Operations.Fiscal.CreateExchangeStatusReport
{
    [Description("Счетчик итогов непереданных документов")]
    public class FnUnsentDocsCounter
    {
        /// <summary>
        /// Количество
        /// </summary>
        [Display(Name = "Количество")]
        public uint Count { get; set; }

        /// <summary>
        /// Сумма
        /// </summary>
        [Display(Name = "Сумма")]
        public decimal Sum { get; set; }
    }
}