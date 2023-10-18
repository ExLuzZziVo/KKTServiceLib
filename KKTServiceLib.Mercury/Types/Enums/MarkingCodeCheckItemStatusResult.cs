#region

using System.ComponentModel.DataAnnotations;

#endregion

namespace KKTServiceLib.Mercury.Types.Enums
{
    /// <summary>
    /// Сведения о статусе товара
    /// </summary>
    public enum MarkingCodeCheckItemStatusResult : byte
    {
        /// <summary>
        /// Планируемый статус товара корректен
        /// </summary>
        [Display(Name = "Планируемый статус товара корректен")]
        ItemEstimatedStatusCorrect = 1,

        /// <summary>
        /// Планируемый статус товара некорректен
        /// </summary>
        [Display(Name = "Планируемый статус товара некорректен")]
        ItemEstimatedStatusIncorrect = 2,

        /// <summary>
        /// Оборот товара приостановлен
        /// </summary>
        [Display(Name = "Оборот товара приостановлен")]
        ItemSaleStopped = 3
    }
}