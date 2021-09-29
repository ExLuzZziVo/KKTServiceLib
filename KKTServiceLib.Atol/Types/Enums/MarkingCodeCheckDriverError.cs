using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Serialization;

namespace KKTServiceLib.Atol.Types.Enums
{
    /// <summary>
    /// Ошибка драйвера при проверки КМ в ИСМ
    /// </summary>
    [JsonConverter(typeof(StringEnumConverter), typeof(CamelCaseNamingStrategy))]
    public enum MarkingCodeCheckDriverError : byte
    {
        /// <summary>
        /// Процедура проверки уже запущена
        /// </summary>
        [Display(Name = "Процедура проверки уже запущена")]
        ImcCheckIsRun,

        /// <summary>
        /// Ошибка связи, истек таймаут на открытие соединения
        /// </summary>
        [Display(Name = "Ошибка связи, истек таймаут на открытие соединения")]
        ServerNoConnect,

        /// <summary>
        /// Процедура проверки прервана
        /// </summary>
        [Display(Name = "Процедура проверки прервана")]
        ImcCheckBreak,

        /// <summary>
        /// Неверное состояние процесса проверки КМ, проверьте последовательность команд
        /// </summary>
        [Display(Name = "Неверное состояние процесса проверки КМ, проверьте последовательность команд")]
        ImcCheckWrongState,

        /// <summary>
        /// Истек таймаут при ожидании ответа на запрос о КМ от сервера
        /// </summary>
        [Display(Name = "Истек таймаут при ожидании ответа на запрос о КМ от сервера")]
        ResponseTimeout
    }
}