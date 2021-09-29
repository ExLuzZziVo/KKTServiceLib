#region

using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

#endregion

namespace KKTServiceLib.Atol.Types.Common.Exchange
{
    [Description("Ошибки обмена ФД")]
    public class ExchangeErrorStatus
    {
        /// <summary>
        /// Команда ФН, на которой произошла ошибка
        /// </summary>
        [Display(Name = "Команда ФН, на которой произошла ошибка")]
        public uint FnCommandCode { get; set; }

        /// <summary>
        /// Номер ФД, на котором произошла ошибка
        /// </summary>
        [Display(Name = "Номер ФД, на котором произошла ошибка")]
        public uint DocumentNumber { get; set; }

        /// <summary>
        /// Дата и время последнего успешного соединения с ОФД
        /// </summary>
        [Display(Name = "Дата и время последнего успешного соединения с ОФД")]
        public DateTime LastSuccessConnectionDateTime { get; set; }

        /// <summary>
        /// Ошибка сети
        /// </summary>
        [Display(Name = "Ошибка сети")]
        public ExchangeError Network { get; set; }

        /// <summary>
        /// Ошибка ОФД
        /// </summary>
        [Display(Name = "Ошибка ОФД")]
        public ExchangeError Ofd { get; set; }

        /// <summary>
        /// Ошибка ФН
        /// </summary>
        [Display(Name = "Ошибка ФН")]
        public ExchangeError Fn { get; set; }
    }
}