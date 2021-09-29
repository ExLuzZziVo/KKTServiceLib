using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using KKTServiceLib.Atol.Types.Enums;

namespace KKTServiceLib.Atol.Types.Operations.Fiscal.Ism.CheckMarkingCodeWorkStatus
{
    [Description("Результат запроса состояния работы с КМ")]
    public class CheckMarkingCodeWorkStatusResult
    {
        /// <summary>
        /// Состояние проверки КМ
        /// </summary>
        [Display(Name = "Состояние проверки КМ")]
        public MarkingCodeCheckCurrentStatus Status { get; set; }

        /// <summary>
        /// Количество проверок КМ
        /// </summary>
        [Display(Name = "Количество проверок КМ")]
        public uint CheckingCount { get; set; }

        /// <summary>
        /// Количество реализованных КМ
        /// </summary>
        [Display(Name = "Количество реализованных КМ")]
        public uint SoldImcCount { get; set; }

        /// <summary>
        /// Начато формирование уведомления
        /// </summary>
        [Display(Name = "Начато формирование уведомления")]
        public bool NoticeIsBegin { get; set; }

        /// <summary>
        /// Ресурс области уведомлений
        /// </summary>
        [Display(Name = "Ресурс области уведомлений")]
        public MarkingCodeCheckMemoryStatus NoticeFreeMemory { get; set; }

        /// <summary>
        /// Количество неотправленных уведомлений
        /// </summary>
        [Display(Name = "Количество неотправленных уведомлений")]
        public uint NoticeCount { get; set; }
    }
}