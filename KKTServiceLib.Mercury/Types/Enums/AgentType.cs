#region

using System.ComponentModel.DataAnnotations;

#endregion

namespace KKTServiceLib.Mercury.Types.Enums
{
    /// <summary>
    /// Тип агента
    /// </summary>
    public enum AgentType : byte
    {
        /// <summary>
        /// Банковский платежный агент
        /// </summary>
        [Display(Name = "Банковский платежный агент")]
        BankPayingAgent = 0,

        /// <summary>
        /// Банковский платежный субагент
        /// </summary>
        [Display(Name = "Банковский платежный субагент")]
        BankPayingSubagent = 1,

        /// <summary>
        /// Платежный агент
        /// </summary>
        [Display(Name = "Платежный агент")] PayingAgent = 2,

        /// <summary>
        /// Платежный субагент
        /// </summary>
        [Display(Name = "Платежный субагент")] PayingSubagent = 3,

        /// <summary>
        /// Поверенный
        /// </summary>
        [Display(Name = "Поверенный")] Attorney = 4,

        /// <summary>
        /// Комиссионер
        /// </summary>
        [Display(Name = "Комиссионер")] CommissionAgent = 5,

        /// <summary>
        /// Другой тип агента
        /// </summary>
        [Display(Name = "Другой тип агента")] Another = 6
    }
}