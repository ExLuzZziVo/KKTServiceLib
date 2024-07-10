#region

using System.ComponentModel;

#endregion

namespace KKTServiceLib.Atol.Types.Operations.NonFiscal.GetOverallTotals
{
    [Description("Запрос необнуляемых итогов")]
    public class GetOverallTotalsOperation: Operation<GetOverallTotalsResult>
    {
        /// <summary>
        /// Запрос необнуляемых итогов
        /// </summary>
        public GetOverallTotalsOperation(): base("getOverallTotals") { }
    }
}