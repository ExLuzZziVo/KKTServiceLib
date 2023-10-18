#region

using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

#endregion

namespace KKTServiceLib.Atol.Types.Operations.Fiscal.CreateExchangeStatusReport
{
    [Description("Итоги по оплатам")]
    public class PaymentsStat
    {
        /// <summary>
        /// Сумма оплат встречным предоставлением
        /// </summary>
        [Display(Name = "Сумма оплат встречным предоставлением")]
        public decimal BarterSum { get; set; }

        /// <summary>
        /// Сумма наличных оплат
        /// </summary>
        [Display(Name = "Сумма наличных оплат")]
        public decimal CashSum { get; set; }

        /// <summary>
        /// Количество коррекций
        /// </summary>
        [Display(Name = "Количество коррекций")]
        public int Corrections { get; set; }

        /// <summary>
        /// Сумма коррекций
        /// </summary>
        [Display(Name = "Сумма коррекций")]
        public decimal CorrectionsSum { get; set; }

        /// <summary>
        /// Сумма оплат кредитом
        /// </summary>
        [Display(Name = "Сумма оплат кредитом")]
        public decimal CreditSum { get; set; }

        /// <summary>
        /// Сумма безналичных оплат
        /// </summary>
        [Display(Name = "Сумма безналичных оплат")]
        public decimal NoncashSum { get; set; }

        /// <summary>
        /// Сумма оплат авансом
        /// </summary>
        [Display(Name = "Сумма оплат авансом")]
        public decimal PrepaidSum { get; set; }

        /// <summary>
        /// Общее количество чеков (включая коррекции)
        /// </summary>
        [Display(Name = "Общее количество чеков (включая коррекции)")]
        public int Receipts { get; set; }

        /// <summary>
        /// Итоговая сумма чеков (включая коррекции)
        /// </summary>
        [Display(Name = "Итоговая сумма чеков (включая коррекции)")]
        public decimal ReceiptsSum { get; set; }

        /// <summary>
        /// Сумма НДС 0%
        /// </summary>
        [Display(Name = "Сумма НДС 0%")]
        public decimal Vat0Sum { get; set; }

        /// <summary>
        /// Сумма НДС 10%
        /// </summary>
        [Display(Name = "Сумма НДС 10%")]
        public decimal Vat10Sum { get; set; }

        /// <summary>
        /// Сумма НДС 10/110
        /// </summary>
        [Display(Name = "Сумма НДС 10/110")]
        public decimal Vat110Sum { get; set; }

        /// <summary>
        /// Сумма НДС 20/120
        /// </summary>
        [Display(Name = "Сумма НДС 20/120")]
        public decimal Vat120Sum { get; set; }

        /// <summary>
        /// Сумма НДС 20%
        /// </summary>
        [Display(Name = "Сумма НДС 20%")]
        public decimal Vat20Sum { get; set; }

        /// <summary>
        /// Сумма без НДС
        /// </summary>
        [Display(Name = "Сумма без НДС")]
        public decimal VatNoSum { get; set; }
    }
}