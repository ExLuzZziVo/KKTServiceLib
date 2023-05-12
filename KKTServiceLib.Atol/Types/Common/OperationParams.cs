using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using KKTServiceLib.Shared.Types.Converters;
using Newtonsoft.Json;

namespace KKTServiceLib.Atol.Types.Common
{
    [Description("Операционный реквизит чека")]
    public class OperationParams
    {
        /// <summary>
        /// Идентификатор операции
        /// </summary>
        [Display(Name = "Идентификатор операции")]
        public byte Id { get; set; }

        /// <summary>
        /// Дата, время операции
        /// </summary>
        [Display(Name = "Дата, время операции")]
        [JsonConverter(typeof(CustomDateTimeConverter), "yyyy.MM.dd HH:mm:ss")]
        public DateTime? DateTime { get; set; }

        /// <summary>
        /// Данные операции
        /// </summary>
        [Display(Name = "Данные операции")]
        public string Data { get; set; }
    }
}