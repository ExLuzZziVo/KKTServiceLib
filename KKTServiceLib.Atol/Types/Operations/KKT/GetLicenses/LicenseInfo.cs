#region

using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

#endregion

namespace KKTServiceLib.Atol.Types.Operations.KKT.GetLicenses
{
    [Description("Информация о лицензии")]
    public class LicenseInfo
    {
        /// <summary>
        /// Номер лицензии
        /// </summary>
        [Display(Name = "Номер лицензии")]
        public string Id { get; set; }

        /// <summary>
        /// Наименование лицензии
        /// </summary>
        [Display(Name = "Наименование лицензии")]
        public string Name { get; set; }

        /// <summary>
        /// Дата начала действия лицензии
        /// </summary>
        [Display(Name = "Дата начала действия лицензии")]
        public DateTime? ValidFrom { get; set; }

        /// <summary>
        /// Дата окончания действия лицензии
        /// </summary>
        [Display(Name = "Дата окончания действия лицензии")]
        public DateTime? ValidUntil { get; set; }

        /// <summary>
        /// Максимально поддерживаемая конфигурация
        /// </summary>
        /// <remarks>
        /// Только для лицензии №16
        /// </remarks>
        [Display(Name = "Максимально поддерживаемая конфигурация")]
        public string UnitVersion { get; set; }
    }
}
