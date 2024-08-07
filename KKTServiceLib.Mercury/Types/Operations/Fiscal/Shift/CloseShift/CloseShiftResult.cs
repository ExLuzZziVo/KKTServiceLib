﻿#region

using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

#endregion

namespace KKTServiceLib.Mercury.Types.Operations.Fiscal.Shift.CloseShift
{
    [Description("Результат закрытия смены")]
    public class CloseShiftResult: FiscalOperationResult
    {
        /// <summary>
        /// Номер закрытой смены
        /// </summary>
        [Display(Name = "Номер закрытой смены")]
        public int ShiftNum { get; set; }
    }
}