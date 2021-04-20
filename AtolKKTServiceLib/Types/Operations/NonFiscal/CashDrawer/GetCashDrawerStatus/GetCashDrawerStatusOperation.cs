#region

using System.ComponentModel;

#endregion

namespace AtolKKTServiceLib.Types.Operations.NonFiscal.CashDrawer.GetCashDrawerStatus
{
    [Description("Запрос состояния денежного ящика")]
    public class GetCashDrawerStatusOperation : Operation<GetCashDrawerStatusResult>
    {
        /// <summary>
        /// Запрос состояния денежного ящика
        /// </summary>
        public GetCashDrawerStatusOperation() : base("getCashDrawerStatus")
        {
        }
    }
}