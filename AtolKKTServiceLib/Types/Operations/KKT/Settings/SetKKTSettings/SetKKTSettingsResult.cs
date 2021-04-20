#region

using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using AtolKKTServiceLib.Types.Common.KKT;

#endregion

namespace AtolKKTServiceLib.Types.Operations.KKT.Settings.SetKKTSettings
{
    [Description("Результат записи настроек ККТ")]
    public class SetKKTSettingsResult
    {
        /// <summary>
        /// Настройки ККТ
        /// </summary>
        [Display(Name = "Настройки ККТ")]
        public KKTSettingsResultParam[] DeviceParameters { get; set; }
    }
}