#region

using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

#endregion

namespace AtolKKTServiceLib.Types.Operations.Fiscal.Shift.GetShiftTotals
{
    [Description("Детальные итоги по чекам")]
    public class PaymentsDetailsShiftTotals
    {
        /// <summary>
        /// Сумма оплат наличными
        /// </summary>
        [Display(Name = "Сумма оплат наличными")]
        public decimal Cash { get; set; }

        /// <summary>
        /// Сумма оплат безналичными
        /// </summary>
        [Display(Name = "Сумма оплат безналичными")]
        public decimal Electronically { get; set; }

        /// <summary>
        /// Сумма кредитов
        /// </summary>
        [Display(Name = "Сумма кредитов")]
        public decimal Credit { get; set; }

        /// <summary>
        /// Сумма предоплат
        /// </summary>
        [Display(Name = "Сумма предоплат")]
        public decimal Prepaid { get; set; }

        /// <summary>
        /// Сумма оплат встречным предоставлением
        /// </summary>
        [Display(Name = "Сумма оплат встречным предоставлением")]
        public decimal Other { get; set; }

        /// <summary>
        /// Сумма оплат пользовательским типом оплаты с номером 1
        /// </summary>
        [Display(Name = "Сумма оплат пользовательским типом оплаты с номером 1")]
        public decimal UserPaymentType1 { get; set; }

        /// <summary>
        /// Сумма оплат пользовательским типом оплаты с номером 2
        /// </summary>
        [Display(Name = "Сумма оплат пользовательским типом оплаты с номером 2")]
        public decimal UserPaymentType2 { get; set; }

        /// <summary>
        /// Сумма оплат пользовательским типом оплаты с номером 3
        /// </summary>
        [Display(Name = "Сумма оплат пользовательским типом оплаты с номером 3")]
        public decimal UserPaymentType3 { get; set; }

        /// <summary>
        /// Сумма оплат пользовательским типом оплаты с номером 4
        /// </summary>
        [Display(Name = "Сумма оплат пользовательским типом оплаты с номером 4")]
        public decimal UserPaymentType4 { get; set; }

        /// <summary>
        /// Сумма оплат пользовательским типом оплаты с номером 5
        /// </summary>
        [Display(Name = "Сумма оплат пользовательским типом оплаты с номером 5")]
        public decimal UserPaymentType5 { get; set; }
    }
}