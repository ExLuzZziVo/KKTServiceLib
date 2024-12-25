#region

using System.ComponentModel;

#endregion

namespace KKTServiceLib.Mercury.Types.Operations.KKT.SalesJournal.ReadSalesJournal
{
    [Description("Начать чтение журналов продаж")]
    public class ReadSalesJournalOperation: Operation<ReadSalesJournalResult>
    {
        /// <summary>
        /// Чтение журналов продаж
        /// </summary>
        public ReadSalesJournalOperation(): base("ReadSales") { }
    }
}