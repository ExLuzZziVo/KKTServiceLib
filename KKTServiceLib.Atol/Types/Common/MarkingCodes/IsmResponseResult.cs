using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace KKTServiceLib.Atol.Types.Common.MarkingCodes
{
    [Description("Результат обработки запроса о КМ ИСМ")]
    public class IsmResponseResult
    {
        /// <summary>
        /// Результат проверки КП КМ
        /// </summary>
        [Display(Name = "Результат проверки КП КМ")]
        public bool ResponseStatus { get; set; }

        /// <summary>
        /// Статус товара корректен
        /// </summary>
        [Display(Name = "Статус товара корректен")]
        public bool ItemStatusCheck { get; set; }
    }
}