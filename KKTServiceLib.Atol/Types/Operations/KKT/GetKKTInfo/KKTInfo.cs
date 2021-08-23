#region

using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

#endregion

namespace KKTServiceLib.Atol.Types.Operations.KKT.GetKKTInfo
{
    [Description("Информация о ККТ")]
    public class KKTInfo
    {
        /// <summary>
        /// Код модели ККТ
        /// </summary>
        [Display(Name = "Код модели ККТ")]
        public uint Model { get; set; }

        /// <summary>
        /// Название модели ККТ
        /// </summary>
        [Display(Name = "Название модели ККТ")]
        public string ModelName { get; set; }

        /// <summary>
        /// Заводской номер ККТ
        /// </summary>
        [Display(Name = "Заводской номер ККТ")]
        public string Serial { get; set; }

        /// <summary>
        /// Версия прошивки ККТ
        /// </summary>
        [Display(Name = "Версия прошивки ККТ")]
        public string FirmwareVersion { get; set; }

        /// <summary>
        /// Версия конфигурации
        /// </summary>
        [Display(Name = "Версия конфигурации")]
        public string ConfigurationVersion { get; set; }

        /// <summary>
        /// Ширина чековой ленты в символах
        /// </summary>
        [Display(Name = "Ширина чековой ленты в символах")]
        public uint ReceiptLineLength { get; set; }

        /// <summary>
        /// Ширина чековой ленты в пикселях
        /// </summary>
        [Display(Name = "Ширина чековой ленты в пикселях")]
        public uint ReceiptLineLengthPix { get; set; }

        /// <summary>
        /// Версия ФФД ККТ
        /// </summary>
        [Display(Name = "Версия ФФД ККТ")]
        public string FfdVersion { get; set; }

        /// <summary>
        /// Версия ФФД ФН
        /// </summary>
        [Display(Name = "Версия ФФД ФН")]
        public string FnFfdVersion { get; set; }
    }
}