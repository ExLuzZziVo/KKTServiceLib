#region

using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using KKTServiceLib.Atol.Types.Common.MarkingCodes;

#endregion

namespace KKTServiceLib.Atol.Types.Operations.Fiscal.Ism.ForceAddMarkingCodesToBuffer
{
    [Description("Результат принудительного добавления массива КМ в таблицу проверенных КМ")]
    public class ForceAddMarkingCodesToBufferResult
    {
        /// <summary>
        /// Ошибка драйвера
        /// </summary>
        [Display(Name = "Ошибка драйвера")]
        public MarkingCodeCheckDriverError DriverError { get; set; }

        /// <summary>
        /// Локальная проверка
        /// </summary>
        [Display(Name = "Локальная проверка")]
        public MarkingCodeCheckOfflineValidationResult OfflineValidation { get; set; }

        /// <summary>
        /// Результат сохранения КМ в таблице ФН-М в случае успешной проверки
        /// </summary>
        [Display(Name = "Результат сохранения КМ в таблице ФН-М в случае успешной проверки")]
        public ItemInfoCheckResult ItemInfoCheckResult { get; set; }
    }
}