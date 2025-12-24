#region

using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

#endregion

namespace KKTServiceLib.Atol.Types.Operations.KKT.GetLicenses
{
    [Description("Результат запроса введенных в ККТ лицензий")]
    public class GetLicensesResult
    {
        /// <summary>
        /// Лицензии
        /// </summary>
        [Display(Name = "Лицензии")]
        public LicenseInfo[] Licenses { get; set; }
    }
}
