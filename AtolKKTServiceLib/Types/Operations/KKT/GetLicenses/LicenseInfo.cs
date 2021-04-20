#region

using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

#endregion

namespace AtolKKTServiceLib.Types.Operations.KKT.GetLicenses
{
    [Description("Информация о лицензии/коде защиты")]
    public class LicenseInfo
    {
        /// <summary>
        /// Номер лицензии/кода защиты
        /// </summary>
        [Display(Name = "Номер лицензии/кода защиты")]
        public string Id { get; set; }

        /// <summary>
        /// Наименование лицензии/кода защиты
        /// </summary>
        [Display(Name = "Наименование лицензии/кода защиты")]
        public string Name { get; set; }
    }
}