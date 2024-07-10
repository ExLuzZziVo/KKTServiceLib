#region

using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using CoreLib.CORE.Helpers.Converters;

#endregion

namespace KKTServiceLib.Atol.Types.Enums
{
    /// <summary>
    /// Тип проверки КМ в ККТ
    /// </summary>
    [JsonConverter(typeof(JsonCamelCaseStringEnumConverter))]
    public enum MarkingCodeKKTCheckType: byte
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
        NotSendToServer,

        /// <summary>
        /// Проверка без формирования запроса в ФН
        /// </summary>
        [Display(Name = "Проверка без формирования запроса в ФН")]
        NotFormRequest
    }
}