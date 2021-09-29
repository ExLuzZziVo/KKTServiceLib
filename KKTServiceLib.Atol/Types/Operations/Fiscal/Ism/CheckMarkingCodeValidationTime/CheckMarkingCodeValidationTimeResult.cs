using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace KKTServiceLib.Atol.Types.Operations.Fiscal.Ism.CheckMarkingCodeValidationTime
{
    [Description("Результат запроса времени проверки КМ")]
    public class CheckMarkingCodeValidationTimeResult
    {
        /// <summary>
        /// Время проверки в ФН, мс
        /// </summary>
        [Display(Name = "Время проверки в ФН, мс")]
        public long FmCheckTime { get; set; }

        /// <summary>
        /// Время отправки, мс
        /// </summary>
        [Display(Name = "Время отправки, мс")]
        public long SendingTime { get; set; }

        /// <summary>
        /// Время обмена с сервером, мс
        /// </summary>
        [Display(Name = "Время обмена с сервером, мс")]
        public long ServerExchangeTime { get; set; }

        /// <summary>
        /// Полное время проверки, мс
        /// </summary>
        [Display(Name = "Полное время проверки, мс")]
        public long FullTime { get; set; }
    }
}