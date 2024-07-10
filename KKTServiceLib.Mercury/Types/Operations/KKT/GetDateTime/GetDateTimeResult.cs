#region

using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using CoreLib.CORE.Helpers.Converters;

#endregion

namespace KKTServiceLib.Mercury.Types.Operations.KKT.GetDateTime
{
    [Description("Результат запроса даты и времени ККТ")]
    public class GetDateTimeResult: OperationResult
    {
        /// <summary>
        /// Дата и время ККТ
        /// </summary>
        [Display(Name = "Дата и время ККТ")]
        [CustomDateTimeConverter("yyyy-MM-ddTHH:mm:ss")]
        public DateTime? DateTime { get; set; }
    }
}