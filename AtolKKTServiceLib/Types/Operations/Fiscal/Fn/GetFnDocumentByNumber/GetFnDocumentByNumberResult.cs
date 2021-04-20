#region

using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using AtolKKTServiceLib.Types.Converters;
using AtolKKTServiceLib.Types.Enums;
using Newtonsoft.Json;

#endregion

namespace AtolKKTServiceLib.Types.Operations.Fiscal.Fn.GetFnDocumentByNumber
{
    [Description("Результат чтения документа из ФН")]
    [JsonConverter(typeof(FnDocumentConverter))]
    public class GetFnDocumentByNumberResult
    {
        /// <summary>
        /// Тип документа
        /// </summary>
        [Display(Name = "Тип документа")]
        public FiscalDocumentType FiscalDocumentType { get; set; }

        /// <summary>
        /// Документ считан из архива неполностью
        /// </summary>
        [Display(Name = "Документ считан из архива неполностью")]
        public bool Short { get; set; }

        /// <summary>
        /// Состав документа в тегах
        /// </summary>
        [Display(Name = "Состав документа в тегах")]
        public string DocumentTLV { get; set; }

        /// <summary>
        /// 'Сырые' данные документа в TLV, закодированные в base64
        /// </summary>
        [Display(Name = "'Сырые' данные документа в TLV, закодированные в base64")]
        public string RawData { get; set; }
    }
}