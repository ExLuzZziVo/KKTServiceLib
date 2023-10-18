#region

using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

#endregion

namespace KKTServiceLib.Atol.Types.Common.MarkingCodes
{
    [Description("Ошибка драйвера")]
    public class MarkingCodeCheckDriverError
    {
        /// <summary>
        /// Стандартный код ошибки драйвера
        /// </summary>
        [Display(Name = "Стандартный код ошибки драйвера")]
        public int Code { get; set; }

        /// <summary>
        /// Краткое название ошибки
        /// </summary>
        [Display(Name = "Краткое название ошибки")]
        public Enums.MarkingCodeCheckDriverError? Error { get; set; }

        /// <summary>
        /// Описание ошибки драйвера
        /// </summary>
        [Display(Name = "Описание ошибки драйвера")]
        public string Description { get; set; }
    }
}