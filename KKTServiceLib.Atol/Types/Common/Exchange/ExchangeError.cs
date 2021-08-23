#region

using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

#endregion

namespace KKTServiceLib.Atol.Types.Common.Exchange
{
    [Description("Ошибка обмена")]
    public class ExchangeError
    {
        /// <summary>
        /// Код ошибки
        /// </summary>
        [Display(Name = "Код ошибки")]
        public int Code { get; set; }

        /// <summary>
        /// Текст ошибки
        /// </summary>
        [Display(Name = "Текст ошибки")]
        public string Description { get; set; }
    }
}