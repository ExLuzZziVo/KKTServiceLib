#region

using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using KKTServiceLib.Atol.Types.Common;
using KKTServiceLib.Atol.Types.Common.KKT;

#endregion

namespace KKTServiceLib.Atol.Types.Operations.Fiscal.KKTRegistration.GetKKTRegistrationInfo
{
    [Description("Результат запроса параметров регистрации ККТ")]
    public class GetKKTRegistrationInfoResult
    {
        /// <summary>
        /// Информация об организации
        /// </summary>
        [Display(Name = "Информация об организации")]
        public OrganizationParams Organization { get; set; }

        /// <summary>
        /// Параметры ККТ
        /// </summary>
        [Display(Name = "Параметры ККТ")]
        public KKTParams Device { get; set; }

        /// <summary>
        /// Параметры ОФД
        /// </summary>
        [Display(Name = "Параметры ОФД")]
        public OfdParams Ofd { get; set; }
    }
}