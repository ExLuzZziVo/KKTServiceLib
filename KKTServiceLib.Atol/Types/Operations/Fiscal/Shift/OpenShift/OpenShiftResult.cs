#region

using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using KKTServiceLib.Atol.Types.Common.FiscalDocuments;
using KKTServiceLib.Atol.Types.Common.Warnings;

#endregion

namespace KKTServiceLib.Atol.Types.Operations.Fiscal.Shift.OpenShift
{
    [Description("Результат открытия смены")]
    public class OpenShiftResult
    {
        /// <summary>
        /// Фискальные параметры отчета
        /// </summary>
        [Display(Name = "Фискальные параметры отчета")]
        public FiscalDocumentParams FiscalParams { get; set; }

        /// <summary>
        /// Флаги предупреждений
        /// </summary>
        [Display(Name = "Флаги предупреждений")]
        public WarningFlags Warnings { get; set; }
    }
}