#region

using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using CoreLib.CORE.Helpers.Converters;

#endregion

namespace KKTServiceLib.Mercury.Types.Operations.KKT.SalesJournal.GetSalesJournal
{
    [Description("Результат получения журналов продаж в результате чтения базы данных ККТ")]
    public class GetSalesJournalResult: OperationResult
    {
        /// <summary>
        /// Регистрационный номер ККТ
        /// </summary>
        [Display(Name = "Регистрационный номер ККТ")]
        public string KktRegNum { get; set; }

        /// <summary>
        /// Заводской номер ККТ
        /// </summary>
        [Display(Name = "Заводской номер ККТ")]
        public string KktNum { get; set; }

        /// <summary>
        /// ИНН организации-пользователя (владельца) ККТ
        /// </summary>
        [Display(Name = "ИНН организации-пользователя (владельца) ККТ")]
        public string OwnerInn { get; set; }

        /// <summary>
        /// Версия ФФД
        /// </summary>
        [Display(Name = "Версия ФФД")]
        public string FfdVer { get; set; }

        /// <summary>
        /// Версия формата журнала продаж ККТ
        /// </summary>
        [Display(Name = "Версия формата журнала продаж ККТ")]
        public string SalesVer { get; set; }

        /// <summary>
        /// Дата выпуска прошивки ККТ
        /// </summary>
        [Display(Name = "Дата выпуска прошивки ККТ")]
        [CustomDateTimeConverter("yyyy-MM-dd")]
        public DateTime ProgramDate { get; set; }

        /// <summary>
        /// Кассовые смены
        /// </summary>
        [Display(Name = "Кассовые смены")]
        public JournalShift Shifts { get; set; }
    }
}