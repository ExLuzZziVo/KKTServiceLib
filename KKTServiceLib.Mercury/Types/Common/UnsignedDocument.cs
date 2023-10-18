#region

using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using CoreLib.CORE.Helpers.Converters;

#endregion

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
        [CustomDateTimeConverter("yyyy-MM-ddTHH:mm:ss")]
        public DateTime? FirstDateTime { get; set; }
    }
}