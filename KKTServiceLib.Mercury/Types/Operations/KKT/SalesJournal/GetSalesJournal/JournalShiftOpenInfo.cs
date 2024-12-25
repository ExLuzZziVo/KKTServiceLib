#region

using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using CoreLib.CORE.Helpers.Converters;
using KKTServiceLib.Mercury.Types.Common;

#endregion

namespace KKTServiceLib.Mercury.Types.Operations.KKT.SalesJournal.GetSalesJournal
{
    [Description("Информация об открытии смены")]
    [JsonDerivedType(typeof(JournalShiftCloseInfo))]
    public class JournalShiftOpenInfo
    {
        /// <summary>
        /// Номер фискального документа
        /// </summary>
        [Display(Name = "Номер фискального документа")]
        public uint FiscalDocNum { get; set; }

        /// <summary>
        /// Дата и время регистрации документа в ФН
        /// </summary>
        [Display(Name = "Дата и время регистрации документа в ФН")]
        [CustomDateTimeConverter("yyyy-MM-ddTHH:mm:ss")]
        public DateTime DateTime { get; set; }

        /// <summary>
        /// Оператор (кассир)
        /// </summary>
        [Display(Name = "Оператор (кассир)")]
        public OperatorParams CashierInfo { get; set; }
    }
}