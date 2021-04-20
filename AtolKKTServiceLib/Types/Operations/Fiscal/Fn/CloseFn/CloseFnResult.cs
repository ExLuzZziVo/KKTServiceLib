#region

using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using AtolKKTServiceLib.Types.Common.FiscalDocuments;
using AtolKKTServiceLib.Types.Common.Warnings;

#endregion

namespace AtolKKTServiceLib.Types.Operations.Fiscal.Fn.CloseFn
{
    [Description("Результат закрытия ФН")]
    public class CloseFnResult
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