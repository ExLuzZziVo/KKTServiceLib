#region

using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

#endregion

namespace AtolKKTServiceLib.Types.Operations.KKT.GetKKTInfo
{
    [Description("Результат запроса информации о ККТ")]
    public class GetKKTInfoResult
    {
        /// <summary>
        /// Информация о ККТ
        /// </summary>
        [Display(Name = "Информация о ККТ")]
        public KKTInfo DeviceInfo { get; set; }
    }
}