using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text;
using KKTServiceLib.Shared.Resources;
using KKTServiceLib.Shared.Types.Converters;
using Newtonsoft.Json;

namespace MercuryKKTServiceLib.Types.Operations.KKT.SetDateTime
{
    [Description("Установка даты и времени ККТ")]
    public class SetDateTimeOperation: Operation<SetDateTimeResult>
    {
        /// <summary>
        /// Установка даты и времени
        /// </summary>
        /// <param name="dateTime">Текущие дата и время</param>
        public SetDateTimeOperation(DateTime dateTime) : base("SetDateTime")
        {
            DateTime = dateTime;
        }

        /// <summary>
        /// Дата и время
        /// </summary>
        /// <list type="bullet">
        /// <item>Обязательное поле</item>
        /// </list>
        [Required(ErrorMessageResourceType = typeof(ErrorStrings), ErrorMessageResourceName = "RequiredError")]
        [Display(Name = "Дата и время")]
        [JsonConverter(typeof(CustomDateTimeConverter), "yyyy-MM-ddTHH:mm:ss")]
        public DateTime DateTime { get; }
    }
}
