#region

using System.ComponentModel;

#endregion

namespace KKTServiceLib.Mercury.Types.Operations.KKT.SalesJournal.GetSalesJournal
{
    [Description("Получение журналов продаж в результате чтения базы данных ККТ")]
    public class GetSalesJournalOperation: Operation<GetSalesJournalResult>
    {
        /// <summary>
        /// Получение журналов продаж в результате чтения базы данных ККТ
        /// </summary>
        public GetSalesJournalOperation(): base("GetSales") { }
    }
}