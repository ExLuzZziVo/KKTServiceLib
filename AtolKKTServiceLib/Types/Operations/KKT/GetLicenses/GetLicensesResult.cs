#region

using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

#endregion

namespace AtolKKTServiceLib.Types.Operations.KKT.GetLicenses
{
    [Description("Результат запроса введенных в ККТ лицензий/кодов защиты")]
    public class GetLicensesResult
    {
        /// <summary>
        /// Лицензии/коды защиты
        /// </summary>
        [Display(Name = "Лицензии/коды защиты")]
        public LicenseInfo[] Licenses { get; set; }
    }
}