#region

using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using CoreLib.CORE.Helpers.Converters;
using KKTServiceLib.Mercury.Types.Converters;

#endregion

namespace KKTServiceLib.Mercury.Types.Common
{
    [Description("Состояние смены")]
    public class ShiftInfo
    {
        /// <summary>
        /// Смена открыта
        /// </summary>
        [Display(Name = "Смена открыта")]
        public bool IsOpen { get; set; }

        /// <summary>
        /// Признак того, что с момента открытия смены истёк 24-х часовой интервал
        /// </summary>
        [Display(Name = "Признак того, что с момента открытия смены истёк 24-х часовой интервал")]
        public bool Is24Expired { get; set; }

        /// <summary>
        /// Номер последней открытой смены
        /// </summary>
        [Display(Name = "Номер последней открытой смены")]
        public uint Num { get; set; }

        /// <summary>
        /// Дата и время последнего открытия смены
        /// </summary>
        [Display(Name = "Дата и время последнего открытия смены")]
        [CustomDateTimeConverter("yyyy-MM-ddTHH:mm:ss")]
        public DateTime? LastOpen { get; set; }

        /// <summary>
        /// Сумма наличных в денежном ящике
        /// </summary>
        [Display(Name = "Сумма наличных в денежном ящике")]
        [JsonConverter(typeof(MoneyConverter))]
        public decimal? Cash { get; set; }
    }
}