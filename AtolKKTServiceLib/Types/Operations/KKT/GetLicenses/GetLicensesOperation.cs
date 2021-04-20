#region

using System.ComponentModel;

#endregion

namespace AtolKKTServiceLib.Types.Operations.KKT.GetLicenses
{
    [Description("Запрос введенных в ККТ лицензий/кодов защиты")]
    public class GetLicensesOperation : Operation<GetLicensesResult>
    {
        /// <summary>
        /// Запрос введенных в ККТ лицензий/кодов защиты
        /// </summary>
        public GetLicensesOperation() : base("getLicenses")
        {
        }
    }
}