using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using KKTServiceLib.Mercury.Types.Common;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace KKTServiceLib.Mercury.Types.Operations.KKT.GetKKTStatus
{
    [Description("Результат запроса состояния ККТ")]
    public class GetKKTStatusResult : OperationResult
    {
        /// <summary>
        /// Текущие дата и время ККТ
        /// </summary>
        [Display(Name = "Текущие дата и время ККТ")]
        [JsonConverter(typeof(IsoDateTimeConverter))]
        public DateTime? DateTime { get; set; }

        /// <summary>
        /// Наличие чековой ленты
        /// </summary>
        [Display(Name = "Наличие чековой ленты")]
        public bool? PaperPresence { get; set; }

        /// <summary>
        /// Состояние смены
        /// </summary>
        [Display(Name = "Состояние смены")]
        public ShiftInfo ShiftInfo { get; set; }

        /// <summary>
        /// Текущее состояние чека
        /// </summary>
        [Display(Name = "Текущее состояние чека")]
        public ReceiptInfo CheckInfo { get; set; }

        /// <summary>
        /// Состояние ФН
        /// </summary>
        [Display(Name = "Состояние ФН")]
        public FnInfo FnInfo { get; set; }
    }
}