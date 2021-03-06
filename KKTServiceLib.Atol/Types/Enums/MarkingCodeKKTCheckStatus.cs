using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Serialization;

namespace KKTServiceLib.Atol.Types.Enums
{
    /// <summary>
    /// Состояние проверки КМ в ККТ
    /// </summary>
    [JsonConverter(typeof(StringEnumConverter), typeof(CamelCaseNamingStrategy))]
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
        RecievedResult
    }
}