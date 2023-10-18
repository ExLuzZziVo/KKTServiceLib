#region

using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

#endregion

namespace KKTServiceLib.Atol.Types.Operations.Fiscal.Ism.CheckIsmConnection
{
    [Description("Результат проверки связи с сервером ИСМ")]
    public class CheckIsmConnectionResult
    {
        /// <summary>
        /// Признак готовности проверки связи с ИСМ
        /// </summary>
        [Display(Name = "Признак готовности проверки связи с ИСМ")]
        public bool Ready { get; set; }

        /// <summary>
        /// Время ответа от сервера, мс
        /// </summary>
        [Display(Name = "Время ответа от сервера, мс")]
        public long Time { get; set; }
    }
}