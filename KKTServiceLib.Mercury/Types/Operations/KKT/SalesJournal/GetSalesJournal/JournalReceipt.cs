#region

using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using CoreLib.CORE.Helpers.Converters;
using KKTServiceLib.Mercury.Types.Common;
using KKTServiceLib.Mercury.Types.Common.FiscalDocuments;
using KKTServiceLib.Mercury.Types.Converters;
using KKTServiceLib.Mercury.Types.Enums;

#endregion

namespace KKTServiceLib.Mercury.Types.Operations.KKT.SalesJournal.GetSalesJournal
{
    [Description("Информация о кассовом чеке")]
    public class JournalReceipt
    {
        /// <summary>
        /// Признак того, что чек был аннулирован (сброшен) на ККТ
        /// </summary>
        [Display(Name = "Признак того, что чек был аннулирован (сброшен) на ККТ")]
        public bool? Annulled { get; set; }

        /// <summary>
        /// Номер фискального документа
        /// </summary>
        [Display(Name = "Номер фискального документа")]
        public uint FiscalDocNum { get; set; }

        /// <summary>
        /// Фискальный признак документа
        /// </summary>
        [Display(Name = "Фискальный признак документа")]
        public string FiscalSign { get; set; }

        /// <summary>
        /// Дата и время регистрации документа в ФН
        /// </summary>
        [Display(Name = "Дата и время регистрации документа в ФН")]
        [CustomDateTimeConverter("yyyy-MM-ddTHH:mm:ss")]
        public DateTime DateTime { get; set; }

        /// <summary>
        /// Номер чека внутри смены
        /// </summary>
        [Display(Name = "Номер чека внутри смены")]
        public int? Num { get; set; }

        /// <summary>
        /// Тип чека
        /// </summary>
        [Display(Name = "Тип чека")]
        public FiscalReceiptType CheckType { get; set; }

        /// <summary>
        /// Система налогообложения
        /// </summary>
        [Display(Name = "Система налогообложения")]
        public TaxationType TaxSystem { get; set; }

        /// <summary>
        /// Дополнительный реквизит чека (БСО)
        /// </summary>
        [Display(Name = "Дополнительный реквизит чека (БСО)")]
        public string AdditionalProps { get; set; }

        /// <summary>
        /// E-mail или номер телефона покупателя
        /// </summary>
        [Display(Name = "E-mail или номер телефона покупателя")]
        public string SendCheckTo { get; set; }

        /// <summary>
        /// Данные покупателя
        /// </summary>
        [Display(Name = "Данные покупателя")]
        public BuyerParams BuyerInfo { get; set; }

        /// <summary>
        /// Информация о чеке коррекции
        /// </summary>
        [Display(Name = "Информация о чеке коррекции")]
        public CorrectionReceiptFiscalDocumentParams CorrectionInfo { get; set; }

        /// <summary>
        /// Итоговая сумма чека
        /// </summary>
        [Display(Name = "Итоговая сумма чека")]
        [JsonConverter(typeof(MoneyConverter))]
        public decimal Total { get; set; }

        /// <summary>
        /// Суммы оплат по чеку
        /// </summary>
        [Display(Name = "Суммы оплат по чеку")]
        public PaymentParams Payment { get; set; }

        /// <summary>
        /// Предметы расчета
        /// </summary>
        [Display(Name = "Предметы расчета")]
        public JournalReceiptPosition[] Goods { get; set; }
    }
}