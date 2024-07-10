#region

using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

#endregion

namespace KKTServiceLib.Atol.Types.Operations.KKT.GetMCUInfo
{
    [Description("Информация о FRAM/EEPROM")]
    public class EEPROMInfo
    {
        /// <summary>
        /// Название модели
        /// </summary>
        [Display(Name = "Название модели")]
        public string Name { get; set; }

        /// <summary>
        /// Размер МК в байтах
        /// </summary>
        [Display(Name = "Размер МК в байтах")]
        public uint Size { get; set; }
    }
}