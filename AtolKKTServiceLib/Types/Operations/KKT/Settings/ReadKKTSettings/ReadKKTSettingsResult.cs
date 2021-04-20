#region

using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using AtolKKTServiceLib.Types.Common.KKT;

#endregion

namespace AtolKKTServiceLib.Types.Operations.KKT.Settings.ReadKKTSettings
{
    [Description("Результат чтения настроек ККТ")]
    public class ReadKKTSettingsResult
    {
        /// <summary>
        /// Настройки ККТ
        /// </summary>
        [Display(Name = "Настройки ККТ")]
        public KKTSettingsResultParam[] DeviceParameters { get; set; }
    }
}