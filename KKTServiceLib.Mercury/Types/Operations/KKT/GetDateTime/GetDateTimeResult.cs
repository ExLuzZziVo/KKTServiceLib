using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace KKTServiceLib.Mercury.Types.Operations.KKT.GetDateTime
{
    [Description("Результат запроса даты и времени ККТ")]
    public class GetDateTimeResult : OperationResult
    {
        /// <summary>
        /// Дата и время ККТ
        /// </summary>
        [Display(Name = "Дата и время ККТ")]
        [JsonConverter(typeof(IsoDateTimeConverter))]
        public DateTime? DateTime { get; set; }
    }
}