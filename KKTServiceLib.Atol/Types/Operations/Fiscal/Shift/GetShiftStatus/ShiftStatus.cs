#region

using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

#endregion

namespace KKTServiceLib.Atol.Types.Operations.Fiscal.Shift.GetShiftStatus
{
    [Description("Состояние смены")]
    public class ShiftStatus
    {
        /// <summary>
        /// Дата и время истечения смены
        /// </summary>
        [Display(Name = "Дата и время истечения смены")]
        public DateTime ExpiredTime { get; set; }

        /// <summary>
        /// Номер смены
        /// </summary>
        [Display(Name = "Номер смены")]
        public uint Number { get; set; }

        /// <summary>
        /// Состояние смены
        /// </summary>
        [Display(Name = "Состояние смены")]
        public Enums.ShiftStatus State { get; set; }
    }
}