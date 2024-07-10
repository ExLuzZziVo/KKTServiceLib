#region

using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

#endregion

namespace KKTServiceLib.Mercury.Types.Operations.KKT.Service.GetDriverInfo
{
    [Description("Результат получения информации о драйвере ККТ")]
    public class GetDriverInfoResult: OperationResult
    {
        /// <summary>
        /// Версия драйвера
        /// </summary>
        [Display(Name = "Версия драйвера")]
        public string DriverVer { get; set; }

        /// <summary>
        /// Версия протокола взаимодействия с драйвером
        /// </summary>
        [Display(Name = "Версия протокола взаимодействия с драйвером")]
        public string ProtocolVer { get; set; }

        /// <summary>
        /// Максимальная версия базы товаров ККТ
        /// </summary>
        [Display(Name = "Максимальная версия базы товаров ККТ")]
        public string DriverBaseVer { get; set; }
    }
}