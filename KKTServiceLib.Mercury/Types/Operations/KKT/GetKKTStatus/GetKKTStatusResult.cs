#region

using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using CoreLib.CORE.Helpers.Converters;
using KKTServiceLib.Mercury.Types.Common;

#endregion

namespace KKTServiceLib.Mercury.Types.Operations.KKT.GetKKTStatus
{
    [Description("Результат запроса состояния ККТ")]
    public class GetKKTStatusResult: OperationResult
    {
        /// <summary>
        /// Текущие дата и время ККТ
        /// </summary>
        [Display(Name = "Текущие дата и время ККТ")]
        [CustomDateTimeConverter("yyyy-MM-ddTHH:mm:ss")]
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