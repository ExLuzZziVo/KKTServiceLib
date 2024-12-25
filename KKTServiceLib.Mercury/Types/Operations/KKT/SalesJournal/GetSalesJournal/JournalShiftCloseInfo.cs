#region

using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

#endregion

namespace KKTServiceLib.Mercury.Types.Operations.KKT.SalesJournal.GetSalesJournal
{
    [Description("Информация о закрытии смены")]
    public class JournalShiftCloseInfo: JournalShiftOpenInfo
    {
        /// <summary>
        /// Фискальный признак документа
        /// </summary>
        [Display(Name = "Фискальный признак документа")]
        public string FiscalSign { get; set; }
    }
}