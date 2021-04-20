using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using KKTServiceLib.Shared.Resources;
using KKTServiceLib.Shared.Types.Converters;
using MercuryKKTServiceLib.Types.Enums;
using Newtonsoft.Json;

namespace MercuryKKTServiceLib.Types.Common.FiscalDocuments
{
    [Description("Фискальный документ чека коррекции")]
    public class CorrectionReceiptFiscalDocumentParams
    {
        /// <summary>
        /// Фискальный документ чека коррекции
        /// </summary>
        /// <param name="correctionType">Тип коррекции</param>
        /// <param name="receiptToCorrectDate">Дата совершения корректируемого расчета</param>
        public CorrectionReceiptFiscalDocumentParams(CorrectionReceiptCorrectionType correctionType,
            DateTime receiptToCorrectDate)
        {
            CorrectionType = correctionType;
            CauseDocDate = receiptToCorrectDate;
        }

        /// <summary>
        /// Тип коррекции
        /// </summary>
        /// <list type="bullet">
        /// <item>Обязательное поле</item>
        /// </list>
        [Required(ErrorMessageResourceType = typeof(ErrorStrings), ErrorMessageResourceName = "RequiredError")]
        [Display(Name = "Тип коррекции")]
        public CorrectionReceiptCorrectionType CorrectionType { get; }

        /// <summary>
        /// Описание коррекции
        /// </summary>
        [Display(Name = "Описание коррекции")]
        public string CauseName { get; set; }

        /// <summary>
        /// Дата совершения корректируемого расчета
        /// </summary>
        /// <list type="bullet">
        /// <item>Обязательное поле</item>
        /// </list>
        [Required(ErrorMessageResourceType = typeof(ErrorStrings), ErrorMessageResourceName = "RequiredError")]
        [JsonConverter(typeof(CustomDateTimeConverter), "yyyy-MM-dd")]
        [Display(Name = "Дата совершения корректируемого расчета")]
        public DateTime CauseDocDate { get; }

        /// <summary>
        /// Номер предписания налогового органа
        /// </summary>
        /// <list type="bullet">
        /// <item>Обязательное поле, если тип коррекции - <see cref="CorrectionReceiptCorrectionType.Instruction"/></item>
        /// </list>
        [Display(Name = "Номер предписания налогового органа")]
        public string CauseDocNum { get; set; }
    }
}