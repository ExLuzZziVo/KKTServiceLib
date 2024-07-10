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
        /// Информация о DataFlash
        /// </summary>
        [Display(Name = "Информация о DataFlash")]
        public DataFlashInfo DataFlash { get; set; }

        /// <summary>
        /// Информация о FRAM/EEPROM
        /// </summary>
        [Display(Name = "Информация о FRAM/EEPROM")]
        public EEPROMInfo FramEeprom { get; set; }

        /// <summary>
        /// Информация о микроконтроллере
        /// </summary>
        [Display(Name = "Информация о микроконтроллере")]
        public MCUInfo Mcu { get; set; }
    }
}