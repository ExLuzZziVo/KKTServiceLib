#region

using System.ComponentModel;

#endregion

namespace KKTServiceLib.Atol.Types.Operations.Fiscal.Shift.GetShiftTotals
{
    [Description("Запрос сменных итогов")]
    public class GetShiftTotalsOperation : Operation<GetShiftTotalsResult>
    {
        /// <summary>
        /// Запрос сменных итогов
        /// </summary>
        public GetShiftTotalsOperation() : base("getShiftTotals") { }
    }
}