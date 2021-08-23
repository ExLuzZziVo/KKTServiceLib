using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace KKTServiceLib.Mercury.Types.Common
{
    [Description("Состояние обмена с ОФД")]
    public class UnsignedDocument
    {
        /// <summary>
        /// Количество непереданных документов
        /// </summary>
        [Display(Name = "Количество непереданных документов")]
        public uint Qty { get; set; }

        /// <summary>
        /// Номер первого непереданного документа
        /// </summary>
        [Display(Name = "Номер первого непереданного документа")]
        public uint? FirstNum { get; set; }

        /// <summary>
        /// Дата и время первого непереданного документа
        /// </summary>
        [Display(Name = "Дата и время первого непереданного документа")]
        [JsonConverter(typeof(IsoDateTimeConverter))]
        public DateTime? FirstDateTime { get; set; }
    }
}