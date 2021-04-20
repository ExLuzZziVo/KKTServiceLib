#region

using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using AtolKKTServiceLib.Types.Common.Exchange;

#endregion

namespace AtolKKTServiceLib.Types.Operations.NonFiscal.GetOfdExchangeStatus
{
    [Description("Результат запроса состояния обмена с ОФД")]
    public class GetOfdExchangeStatusResult
    {
        /// <summary>
        /// Состояние
        /// </summary>
        [Display(Name = "Состояние")]
        public ExchangeStatus Status { get; set; }

        /// <summary>
        /// Ошибки обмена
        /// </summary>
        [Display(Name = "Ошибки обмена")]
        public ExchangeErrorStatus Errors { get; set; }
    }
}