#region

using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

#endregion

namespace KKTServiceLib.Mercury.Types.Operations.Fiscal.Shift.OpenShift
{
    [Description("Результат открытия смены")]
    public class OpenShiftResult: FiscalOperationResult
    {
        /// <summary>
        /// Номер открытой смены
        /// </summary>
        [Display(Name = "Номер открытой смены")]
        public int ShiftNum { get; set; }
    }
}