#region

using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using CoreLib.CORE.Helpers.Converters;

#endregion

namespace KKTServiceLib.Atol.Types.Enums
{
    /// <summary>
    /// Состояние проверки КМ в ККТ
    /// </summary>
    [JsonConverter(typeof(JsonCamelCaseStringEnumConverter))]
    public enum MarkingCodeKKTCheckStatus : byte
    {
        /// <summary>
        /// Проверка КМ в ККТ не выполняется
        /// </summary>
        [Display(Name = "Проверка КМ в ККТ не выполняется")]
        NotExecuted,

        /// <summary>
        /// Проверка КМ в ККТ выполняется
        /// </summary>
        [Display(Name = "Проверка КМ в ККТ выполняется")]
        Executed,

        /// <summary>
        /// Проверка КМ в ККТ завершена
        /// </summary>
        [Display(Name = "Проверка КМ в ККТ завершена")]
        Completed,

        /// <summary>
        /// Результат проверки КМ в ККТ получен
        /// </summary>
        [Display(Name = "Результат проверки КМ в ККТ получен")]
        ReceivedResult
    }
}