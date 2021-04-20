#region

using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

#endregion

namespace AtolKKTServiceLib.Types.Operations.Fiscal.Shift.GetShiftStatus
{
    [Description("Результат запроса состояния смены")]
    public class GetShiftStatusResult
    {
        /// <summary>
        /// Состояние смены
        /// </summary>
        [Display(Name = "Состояние смены")]
        public ShiftStatus ShiftStatus { get; set; }
    }
}