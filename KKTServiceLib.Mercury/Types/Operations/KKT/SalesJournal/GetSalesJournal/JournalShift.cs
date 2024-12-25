#region

using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

#endregion

namespace KKTServiceLib.Mercury.Types.Operations.KKT.SalesJournal.GetSalesJournal
{
    [Description("Информация о смене")]
    public class JournalShift
    {
        /// <summary>
        /// Заводской номер ФН
        /// </summary>
        [Display(Name = "Заводской номер ФН")]
        public string FnNum { get; set; }

        /// <summary>
        /// Номер смены
        /// </summary>
        [Display(Name = "Номер смены")]
        public uint Num { get; set; }

        /// <summary>
        /// Информация об открытии смены
        /// </summary>
        [Display(Name = "Информация об открытии смены")]
        public JournalShiftOpenInfo Open { get; set; }

        /// <summary>
        /// Информация о закрытии смены
        /// </summary>
        [Display(Name = "Информация о закрытии смены")]
        public JournalShiftCloseInfo Close { get; set; }

        /// <summary>
        /// Кассовые чеки
        /// </summary>
        [Display(Name = "Кассовые чеки")]
        public JournalReceipt[] Checks { get; set; }
    }
}