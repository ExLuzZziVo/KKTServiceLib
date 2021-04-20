#region

using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Serialization;

#endregion

namespace AtolKKTServiceLib.Types.Enums
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
        [Display(Name = "Внесение наличных")] CashIn,

        /// <summary>
        /// Выплата наличных
        /// </summary>
        [Display(Name = "Выплата наличных")] CashOut
    }
}