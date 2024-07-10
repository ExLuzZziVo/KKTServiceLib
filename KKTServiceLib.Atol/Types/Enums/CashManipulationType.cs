#region

using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using CoreLib.CORE.Helpers.Converters;

#endregion

namespace KKTServiceLib.Atol.Types.Enums
{
    /// <summary>
    /// Тип операции с наличными
    /// </summary>
    [JsonConverter(typeof(JsonCamelCaseStringEnumConverter))]
    public enum CashManipulationType: byte
    {
        /// <summary>
        /// Внесение наличных
        /// </summary>
        [Display(Name = "Внесение наличных")] CashIn,

        /// <summary>
        /// Выплата наличных
        /// </summary>
        [Display(Name = "Выплата наличных")] CashOut
    }
}