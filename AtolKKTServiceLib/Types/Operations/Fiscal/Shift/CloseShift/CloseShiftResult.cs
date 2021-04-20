#region

using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using AtolKKTServiceLib.Types.Common.FiscalDocuments;
using AtolKKTServiceLib.Types.Common.Warnings;

#endregion

namespace AtolKKTServiceLib.Types.Operations.Fiscal.Shift.CloseShift
{
    [Description("Результат закрытия смены")]
    public class CloseShiftResult
    {
        /// <summary>
        /// Номер ФД отчета
        /// </summary>
        [Display(Name = "Номер ФД отчета")]
        public CloseShiftFiscalDocumentParams FiscalParams { get; set; }

        /// <summary>
        /// Флаги предупреждений
        /// </summary>
        [Display(Name = "Флаги предупреждений")]
        public WarningFlags Warnings { get; set; }
    }
}