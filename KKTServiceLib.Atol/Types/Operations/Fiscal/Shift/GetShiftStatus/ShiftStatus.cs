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
        /// Количество ФД за смену
        /// </summary>
        /// <remarks>
        /// Параметр возвращается только при закрытой смене. Параметр недоступен для ККТ 5.0 с ПО ниже 5.7.20
        /// </remarks>
        [Display(Name = "Количество ФД за смену")]
        public uint? DocumentsCount { get; set; }

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