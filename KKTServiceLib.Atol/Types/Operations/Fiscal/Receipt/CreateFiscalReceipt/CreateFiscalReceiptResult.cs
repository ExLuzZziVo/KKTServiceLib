#region

using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using KKTServiceLib.Atol.Types.Common.FiscalDocuments;
using KKTServiceLib.Atol.Types.Common.Warnings;

#endregion

namespace KKTServiceLib.Atol.Types.Operations.Fiscal.Receipt.CreateFiscalReceipt
{
    [Description("Результат создания фискального чека")]
    public class CreateFiscalReceiptResult
    {
        /// <summary>
        /// Фискальные параметры чека
        /// </summary>
        [Display(Name = "Фискальные параметры чека")]
        public ReceiptFiscalDocumentParams FiscalParams { get; set; }

        /// <summary>
        /// Флаги предупреждений
        /// </summary>
        [Display(Name = "Флаги предупреждений")]
        public WarningFlags Warnings { get; set; }

        /// <summary>
        /// Приблизительный размера чека в байтах
        /// </summary>
        /// <remarks>
        /// Значение присваивается только при выполнении предварительной проверки размера чека
        /// </remarks>
        [Display(Name = "Приблизительный размера чека в байтах")]
        public ushort? ReceiptSize { get; set; }

        /// <summary>
        /// Приблизительный размера чека в процентах от максимально возможного
        /// </summary>
        /// <remarks>
        /// Значение присваивается только при выполнении предварительной проверки размера чека
        /// </remarks>
        [Display(Name = "Приблизительный размера чека в процентах от максимально возможного")]
        public byte? ReceiptPercentageSize { get; set; }
    }
}
