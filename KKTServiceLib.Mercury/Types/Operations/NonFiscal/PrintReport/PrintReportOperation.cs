﻿#region

using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using CoreLib.CORE.Resources;
using KKTServiceLib.Mercury.Types.Enums;

#endregion

namespace KKTServiceLib.Mercury.Types.Operations.NonFiscal.PrintReport
{
    [Description("Печать отчета")]
    public class PrintReportOperation: Operation<PrintReportResult>
    {
        /// <summary>
        /// Печать отчета
        /// </summary>
        /// <param name="reportType">Тип отчета</param>
        public PrintReportOperation(ReportType reportType): base("PrintReport")
        {
            ReportCode = reportType;
        }

        /// <summary>
        /// Тип отчета
        /// </summary>
        /// <list type="bullet">
        /// <item>Обязательное поле</item>
        /// </list>
        [Required(ErrorMessageResourceType = typeof(ValidationStrings), ErrorMessageResourceName = "RequiredError")]
        [Display(Name = "Тип отчета")]
        public ReportType ReportCode { get; }
    }
}