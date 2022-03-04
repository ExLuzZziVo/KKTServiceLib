using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Serialization;

namespace KKTServiceLib.Atol.Types.Enums
{
    /// <summary>
    /// Тип проверки КМ в ККТ
    /// </summary>
    [JsonConverter(typeof(StringEnumConverter), typeof(CamelCaseNamingStrategy))]
    public enum MarkingCodeKKTCheckType : byte
    {
        /// <summary>
        /// Автономный режим
        /// </summary>
        [Display(Name = "Автономный режим")] ModeStandAlone,

        /// <summary>
        /// Проверка с ожиданием ответа
        /// </summary>
        [Display(Name = "Проверка с ожиданием ответа")]
        WaitForResult,

        /// <summary>
        /// Проверка без ожидания ответа
        /// </summary>
        [Display(Name = "Проверка без ожидания ответа")]
        NotWaitForResult,

        /// <summary>
        /// Проверка без отправления на сервер
        /// </summary>
        [Display(Name = "Проверка без отправления на сервер")]
        NotSendToServer
    }
}