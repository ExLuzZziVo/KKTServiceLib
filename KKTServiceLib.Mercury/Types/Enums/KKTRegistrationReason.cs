#region

using System.ComponentModel.DataAnnotations;

#endregion

namespace KKTServiceLib.Mercury.Types.Enums
{
    /// <summary>
    /// Причина перерегистрации ККТ
    /// </summary>
    public enum KKTRegistrationReason : byte
    {
        /// <summary>
        /// Замена ФН
        /// </summary>
        [Display(Name = "Замена ФН")] FnChange = 1,

        /// <summary>
        /// Смена ОФД
        /// </summary>
        [Display(Name = "Смена ОФД")] OfdChange = 2,

        /// <summary>
        /// Изменение реквизитов
        /// </summary>
        [Display(Name = "Изменение реквизитов")]
        AttributesChange = 3
    }
}