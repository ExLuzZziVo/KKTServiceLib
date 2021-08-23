#region

using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using KKTServiceLib.Atol.Types.Common.Exchange;

#endregion

namespace KKTServiceLib.Atol.Types.Operations.NonFiscal.GetOfdExchangeStatus
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