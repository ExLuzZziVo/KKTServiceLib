#region

using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using KKTServiceLib.Atol.Types.Enums;

#endregion

namespace KKTServiceLib.Atol.Types.Operations.KKT.PrintDocumentsFromDatabase
{
    [Description("Печать документов из БД документов")]
    public class PrintDocumentsFromDatabaseOperation: Operation<bool>
    {
        /// <summary>
        /// Печать документов из БД документов
        /// </summary>
        /// <param name="filter">Фильтр документов</param>
        /// <param name="from">Начало диапазона выгрузки</param>
        /// <param name="to">Конец диапазона выгрузки</param>
        public PrintDocumentsFromDatabaseOperation(DatabaseDocumentFilter filter, uint from, uint to): base(
            "printDocumentsFromJournal")
        {
            Filter = filter;

            if (from > to)
            {
                From = to;
                To = from;
            }
            else
            {
                From = from;
                To = to;
            }
        }

        /// <summary>
        /// Фильтр документов
        /// </summary>
        /// <list type="bullet">
        /// <item>Обязательное поле</item>
        /// </list>
        [Display(Name = "Фильтр документов")]
        public DatabaseDocumentFilter Filter { get; }

        /// <summary>
        /// Начало диапазона выгрузки
        /// </summary>
        /// <list type="bullet">
        /// <item>Обязательное поле</item>
        /// </list>
        [Display(Name = "Начало диапазона выгрузки")]
        public uint From { get; }

        /// <summary>
        /// Конец диапазона выгрузки
        /// </summary>
        /// <list type="bullet">
        /// <item>Обязательное поле</item>
        /// </list>
        [Display(Name = "Конец диапазона выгрузки")]
        public uint To { get; }
    }
}