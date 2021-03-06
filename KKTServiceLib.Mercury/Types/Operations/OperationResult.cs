using System.ComponentModel.DataAnnotations;
using KKTServiceLib.Shared.Resources;

namespace KKTServiceLib.Mercury.Types.Operations
{
    /// <summary>
    /// Результат выполнения операции
    /// </summary>
    public abstract class OperationResult
    {
        /// <summary>
        /// Код завершения операции
        /// </summary>
        /// <list type="bullet">
        /// <item>Обязательное поле</item>
        /// </list>
        [Required(ErrorMessageResourceType = typeof(ErrorStrings), ErrorMessageResourceName = "RequiredError")]
        [Display(Name = "Код завершения операции")]
        public int Result { get; set; }

        /// <summary>
        /// Текст описания ошибки
        /// </summary>
        [Display(Name = "Текст описания ошибки")]
        public string Description { get; set; }
    }
}