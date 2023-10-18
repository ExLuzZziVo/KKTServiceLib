#region

using System.ComponentModel.DataAnnotations;

#endregion

namespace KKTServiceLib.Mercury.Types.Enums
{
    /// <summary>
    /// Система налогообложения
    /// </summary>
    public enum TaxationType : byte
    {
        /// <summary>
        /// Общая
        /// </summary>
        [Display(Name = "Общая")] Osn = 0,

        /// <summary>
        /// Упрощенная (Доход)
        /// </summary>
        [Display(Name = "Упрощенная (Доход)")] UsnIncome = 1,

        /// <summary>
        /// Упрощенная (Доход минус Расход)
        /// </summary>
        [Display(Name = "Упрощенная (Доход минус Расход)")]
        UsnIncomeOutcome = 2,

        /// <summary>
        /// ЕНВД
        /// </summary>
        [Display(Name = "ЕНВД")] Envd = 3,

        /// <summary>
        /// Единый сельскохозяйственный налог
        /// </summary>
        [Display(Name = "Единый сельскохозяйственный налог")]
        Esn = 4,

        /// <summary>
        /// Патентная
        /// </summary>
        [Display(Name = "Патентная")] Patent = 5
    }
}