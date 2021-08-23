using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace KKTServiceLib.Mercury.Types.Common.FiscalDocuments
{
    [Description("Фискальный документ")]
    public class FiscalDocument
    {
        /// <summary>
        /// Номер фискального документа
        /// </summary>
        [Display(Name = "Номер фискального документа")]
        public uint Num { get; set; }

        /// <summary>
        /// Дата и время регистрации документа в ФН
        /// </summary>
        [Display(Name = "Дата и время регистрации документа в ФН")]
        [JsonConverter(typeof(IsoDateTimeConverter))]
        public DateTime DateTime { get; set; }
    }
}