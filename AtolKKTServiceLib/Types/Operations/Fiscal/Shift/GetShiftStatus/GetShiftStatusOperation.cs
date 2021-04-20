#region

using System.ComponentModel;

#endregion

namespace AtolKKTServiceLib.Types.Operations.Fiscal.Shift.GetShiftStatus
{
    [Description("Запрос состояния смены")]
    public class GetShiftStatusOperation : Operation<GetShiftStatusResult>
    {
        /// <summary>
        /// Запрос состояния смены
        /// </summary>
        public GetShiftStatusOperation() : base("getShiftStatus")
        {
        }
    }
}