#region

using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using AtolKKTServiceLib.Types.Enums;

#endregion

namespace AtolKKTServiceLib.Types.Operations.KKT.GetKKTStatus
{
    [Description("Состояние ККТ")]
    public class KKTStatus
    {
        /// <summary>
        /// Текущие дата и время ККТ
        /// </summary>
        [Display(Name = "Текущие дата и время ККТ")]
        public DateTime CurrentDateTime { get; set; }

        /// <summary>
        /// Состояние смены
        /// </summary>
        [Display(Name = "Состояние смены")]
        public ShiftStatus Shift { get; set; }

        /// <summary>
        /// ККТ заблокирована
        /// </summary>
        [Display(Name = "ККТ заблокирована")]
        public bool Blocked { get; set; }

        /// <summary>
        /// Крышка открыта
        /// </summary>
        [Display(Name = "Крышка открыта")]
        public bool CoverOpened { get; set; }

        /// <summary>
        /// Наличие чековой ленты
        /// </summary>
        [Display(Name = "Наличие чековой ленты")]
        public bool PaperPresent { get; set; }

        /// <summary>
        /// ККТ зарегистрирована
        /// </summary>
        [Display(Name = "ККТ зарегистрирована")]
        public bool Fiscal { get; set; }

        /// <summary>
        /// ФН фискализирован
        /// </summary>
        [Display(Name = "ФН фискализирован")]
        public bool FnFiscal { get; set; }

        /// <summary>
        /// ФН обнаружен
        /// </summary>
        [Display(Name = "ФН обнаружен")]
        public bool FnPresent { get; set; }

        /// <summary>
        /// Денежный ящик открыт
        /// </summary>
        [Display(Name = "Денежный ящик открыт")]
        public bool CashDrawerOpened { get; set; }
    }
}