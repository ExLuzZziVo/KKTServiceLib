#region

using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

#endregion

namespace KKTServiceLib.Atol.Types.Common.Exchange
{
    [Description("Состояние обмена ФД")]
    public class ExchangeStatus
    {
        /// <summary>
        /// Количество непереданных ФД
        /// </summary>
        [Display(Name = "Количество непереданных ФД")]
        public uint NotSentCount { get; set; }

        /// <summary>
        /// Номер первого непереданного ФД
        /// </summary>
        [Display(Name = "Номер первого непереданного ФД")]
        public uint NotSentFirstDocNumber { get; set; }

        /// <summary>
        /// Дата и время первого непереданного ФД
        /// </summary>
        [Display(Name = "Дата и время первого непереданного ФД")]
        public DateTime NotSentFirstDocDateTime { get; set; }

        /// <summary>
        /// Дата и время последнего успешного ОКП
        /// </summary>
        [Display(Name = "Дата и время последнего успешного ОКП")]
        public DateTime LastSuccessKeysUpdate { get; set; }
    }
}