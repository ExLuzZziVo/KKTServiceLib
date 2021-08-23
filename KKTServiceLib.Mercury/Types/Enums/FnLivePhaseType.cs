using System.ComponentModel.DataAnnotations;

namespace KKTServiceLib.Mercury.Types.Enums
{
    /// <summary>
    /// Фаза жизни ФН
    /// </summary>
    public enum FnLivePhaseType : byte
    {
        /// <summary>
        /// Готов к фискализации
        /// </summary>
        [Display(Name = "Готов к фискализации")]
        Configured = 0,

        /// <summary>
        /// Фискальный режим
        /// </summary>
        [Display(Name = "Фискальный режим")] FiscalMode = 1,

        /// <summary>
        /// Постфискальный режим (идет передача ФД в ОФД)
        /// </summary>
        [Display(Name = "Постфискальный режим (идет передача ФД в ОФД)")]
        PostFiscalMode = 2,

        /// <summary>
        /// Закрыт (доступен только в режиме чтения данных из архива)
        /// </summary>
        [Display(Name = "Закрыт (доступен только в режиме чтения данных из архива)")]
        AccessArchive = 3
    }
}