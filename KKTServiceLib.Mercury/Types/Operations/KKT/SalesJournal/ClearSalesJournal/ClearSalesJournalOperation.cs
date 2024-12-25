#region

using System.ComponentModel;

#endregion

namespace KKTServiceLib.Mercury.Types.Operations.KKT.SalesJournal.ClearSalesJournal
{
    [Description("Очистка кэша журнала продаж")]
    public class ClearSalesJournalOperation: Operation<ClearSalesJournalResult>
    {
        /// <summary>
        /// Очистка кэша журнала продаж
        /// </summary>
        public ClearSalesJournalOperation(): base("ClearSales") { }
    }
}