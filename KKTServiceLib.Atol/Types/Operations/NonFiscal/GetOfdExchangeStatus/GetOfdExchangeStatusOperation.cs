#region

using System.ComponentModel;

#endregion

namespace KKTServiceLib.Atol.Types.Operations.NonFiscal.GetOfdExchangeStatus
{
    [Description("Запрос состояния обмена с ОФД")]
    public class GetOfdExchangeStatusOperation : Operation<GetOfdExchangeStatusResult>
    {
        /// <summary>
        /// Запрос состояния обмена с ОФД
        /// </summary>
        public GetOfdExchangeStatusOperation() : base("ofdExchangeStatus")
        {
        }
    }
}