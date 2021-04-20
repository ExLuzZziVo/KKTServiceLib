using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Serialization;

namespace MercuryKKTServiceLib.Types.Enums
{
    /// <summary>
    /// Тип операции с наличными
    /// </summary>
    [JsonConverter(typeof(StringEnumConverter), typeof(CamelCaseNamingStrategy))]
    public enum CashManipulationType : byte
    {
        /// <summary>
        /// Внесение наличных
        /// </summary>
        [Display(Name = "Внесение наличных")] BringMoney,

        /// <summary>
        /// Выплата наличных
        /// </summary>
        [Display(Name = "Выплата наличных")] WithdrawMoney
    }
}