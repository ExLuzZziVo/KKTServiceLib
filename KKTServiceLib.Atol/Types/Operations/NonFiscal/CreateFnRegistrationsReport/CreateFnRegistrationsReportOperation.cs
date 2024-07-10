#region

using System.ComponentModel;

#endregion

namespace KKTServiceLib.Atol.Types.Operations.NonFiscal.CreateFnRegistrationsReport
{
    [Description("Создание отчета итогов регистраций/перерегистраций")]
    public class CreateFnRegistrationsReportOperation: Operation<bool>
    {
        /// <summary>
        /// Создание отчета итогов регистраций/перерегистраций
        /// </summary>
        public CreateFnRegistrationsReportOperation(): base("reportFnRegistrations") { }
    }
}