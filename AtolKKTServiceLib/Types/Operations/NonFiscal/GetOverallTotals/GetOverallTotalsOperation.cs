#region

using System.ComponentModel;

#endregion

namespace AtolKKTServiceLib.Types.Operations.NonFiscal.GetOverallTotals
{
    [Description("Запрос необнуляемых итогов")]
    public class GetOverallTotalsOperation : Operation<GetOverallTotalsResult>
    {
        /// <summary>
        /// Запрос необнуляемых итогов
        /// </summary>
        public GetOverallTotalsOperation() : base("getOverallTotals")
        {
        }
    }
}