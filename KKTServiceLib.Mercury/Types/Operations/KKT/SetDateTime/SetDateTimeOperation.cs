#region

using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using CoreLib.CORE.Helpers.Converters;
using CoreLib.CORE.Resources;

#endregion

namespace KKTServiceLib.Mercury.Types.Operations.KKT.SetDateTime
{
    [Description("Установка даты и времени ККТ")]
    public class SetDateTimeOperation : Operation<SetDateTimeResult>
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
        [Required(ErrorMessageResourceType = typeof(ValidationStrings), ErrorMessageResourceName = "RequiredError")]
        [Display(Name = "Дата и время")]
        [CustomDateTimeConverter("yyyy-MM-ddTHH:mm:ss")]
        public DateTime DateTime { get; }
    }
}