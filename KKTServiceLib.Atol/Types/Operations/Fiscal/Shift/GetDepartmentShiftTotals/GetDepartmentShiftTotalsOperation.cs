#region

using System.ComponentModel;

#endregion

namespace KKTServiceLib.Atol.Types.Operations.Fiscal.Shift.GetDepartmentShiftTotals
{
    [Description("Запрос сменных итогов по секциям")]
    public class GetDepartmentShiftTotalsOperation : Operation<GetDepartmentShiftTotalsResult>
    {
        /// <summary>
        /// Запрос сменных итогов по секциям
        /// </summary>
        /// <remarks>
        /// Поддерживается только для ККТ версий 5.X
        /// </remarks>
        public GetDepartmentShiftTotalsOperation() : base("getDepartmentSum") { }
    }
}