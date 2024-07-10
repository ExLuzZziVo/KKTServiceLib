#region

using System.ComponentModel;

#endregion

namespace KKTServiceLib.Atol.Types.Operations.NonFiscal.CreateDepartmentsReport
{
    [Description("Создание отчета по секциям")]
    public class CreateDepartmentsReportOperation: Operation<bool>
    {
        /// <summary>
        /// Создание отчета по секциям
        /// </summary>
        public CreateDepartmentsReportOperation(): base("reportDepartments") { }
    }
}