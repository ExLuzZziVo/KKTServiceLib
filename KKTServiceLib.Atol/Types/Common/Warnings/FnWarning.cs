#region

using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

#endregion

namespace KKTServiceLib.Atol.Types.Common.Warnings
{
    [Description("Предупреждения ФН")]
    public class FnWarning
    {
        /// <summary>
        /// Память ФН переполнена
        /// </summary>
        [Display(Name = "Память ФН переполнена")]
        public bool MemoryOverflow { get; set; }

        /// <summary>
        /// Требуется срочная замена ФН
        /// </summary>
        [Display(Name = "Требуется срочная замена ФН")]
        public bool NeedReplacement { get; set; }

        /// <summary>
        /// Превышено время ожидания ответа от ОФД
        /// </summary>
        [Display(Name = "Превышено время ожидания ответа от ОФД")]
        public bool OfdTimeout { get; set; }

        /// <summary>
        /// Исчерпан ресурс ФН
        /// </summary>
        [Display(Name = "Исчерпан ресурс ФН")]
        public bool ResourceExhausted { get; set; }

        /// <summary>
        /// Критическая ошибка ФН
        /// </summary>
        [Display(Name = "Критическая ошибка ФН")]
        public bool CriticalError { get; set; }
    }
}