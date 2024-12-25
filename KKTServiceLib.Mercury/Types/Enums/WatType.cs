#region

using System.ComponentModel.DataAnnotations;

#endregion

namespace KKTServiceLib.Mercury.Types.Enums
{
    /// <summary>
    /// Налоговая ставка
    /// </summary>
    public enum WatType: byte
    {
        /// <summary>
        /// НДС 20%
        /// </summary>
        [Display(Name = "НДС 20%")] Vat20 = 1,

        /// <summary>
        /// НДС 10%
        /// </summary>
        [Display(Name = "НДС 10%")] Vat10 = 2,

        /// <summary>
        /// НДС 20/120
        /// </summary>
        [Display(Name = "НДС 20/120")] Vat120 = 3,

        /// <summary>
        /// НДС 10/110
        /// </summary>
        [Display(Name = "НДС 10/110")] Vat110 = 4,

        /// <summary>
        /// НДС 0%
        /// </summary>
        [Display(Name = "НДС 0%")] Vat0 = 5,

        /// <summary>
        /// НДС не облагается
        /// </summary>
        [Display(Name = "НДС не облагается")] None = 6,

        /// <summary>
        /// НДС 5%
        /// </summary>
        [Display(Name = "НДС 5%")] Vat5 = 7,

        /// <summary>
        /// НДС 7%
        /// </summary>
        [Display(Name = "НДС 7%")] Vat7 = 8,

        /// <summary>
        /// НДС 5/105
        /// </summary>
        [Display(Name = "5/105")] Vat105 = 9,

        /// <summary>
        /// НДС 7/107
        /// </summary>
        [Display(Name = "7/107")] Vat107 = 10
    }
}
