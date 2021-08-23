#region

using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

#endregion

namespace KKTServiceLib.Atol.Types.Operations.KKT.GetKKTStatus
{
    [Description("Результат запроса состояния ККТ")]
    public class GetKKTStatusResult
    {
        /// <summary>
        /// Состояние ККТ
        /// </summary>
        [Display(Name = "Состояние ККТ")]
        public KKTStatus DeviceStatus { get; set; }
    }
}