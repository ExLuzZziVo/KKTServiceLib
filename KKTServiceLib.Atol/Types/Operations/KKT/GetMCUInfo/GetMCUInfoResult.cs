#region

using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

#endregion

namespace KKTServiceLib.Atol.Types.Operations.KKT.GetMCUInfo
{
    [Description("Результат запроса информации о микроконтроллере")]
    public class GetMCUInfoResult
    {
        /// <summary>
        /// Номер модели микроконтроллера
        /// </summary>
        [Display(Name = "Номер модели микроконтроллера")]
        public string PartId { get; set; }

        /// <summary>
        /// Название модели микроконтроллера
        /// </summary>
        [Display(Name = "Название модели микроконтроллера")]
        public string PartName { get; set; }

        /// <summary>
        /// Уникальный номер микроконтроллера
        /// </summary>
        [Display(Name = "Уникальный номер микроконтроллера")]
        public string Sn { get; set; }
    }
}