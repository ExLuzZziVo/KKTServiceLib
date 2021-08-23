#region

using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using KKTServiceLib.Atol.Types.Common.KKT;

#endregion

namespace KKTServiceLib.Atol.Types.Operations.KKT.Settings.SetKKTSettings
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