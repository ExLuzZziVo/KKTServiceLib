#region

using System.ComponentModel;

#endregion

namespace KKTServiceLib.Atol.Types.Operations.KKT.GetLicenses
{
    [Description("Запрос введенных в ККТ лицензий")]
    public class GetLicensesOperation: Operation<GetLicensesResult>
    {
        /// <summary>
        /// Запрос введенных в ККТ лицензий
        /// </summary>
        public GetLicensesOperation(): base("getLicenses") { }
    }
}
