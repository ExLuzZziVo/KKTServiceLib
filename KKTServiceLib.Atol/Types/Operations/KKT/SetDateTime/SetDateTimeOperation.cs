#region

using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using KKTServiceLib.Shared.Resources;
using KKTServiceLib.Shared.Types.Converters;
using Newtonsoft.Json;

#endregion

namespace KKTServiceLib.Atol.Types.Operations.KKT.SetDateTime
{
    [Description("Установка даты и времени")]
    public class SetDateTimeOperation : Operation<bool>
    {
        /// <summary>
        /// Установка даты и времени
        /// </summary>
        /// <param name="dateTime">Текущие дата и время</param>
        public SetDateTimeOperation(DateTime dateTime) : base("setDateTime")
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
        [JsonConverter(typeof(CustomDateTimeConverter), "yyyy.MM.dd HH:mm:ss")]
        public DateTime DateTime { get; }
    }
}