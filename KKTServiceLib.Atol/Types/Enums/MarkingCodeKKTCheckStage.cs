#region

using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using CoreLib.CORE.Helpers.Converters;

#endregion

namespace KKTServiceLib.Atol.Types.Enums
{
    /// <summary>
    /// Этап проверки КМ в ККТ
    /// </summary>
    [JsonConverter(typeof(JsonCamelCaseStringEnumConverter))]
    public enum MarkingCodeKKTCheckStage : byte
    {
        /// <summary>
        /// Ожидание задания
        /// </summary>
        [Display(Name = "Ожидание задания")] WaitForTask,

        /// <summary>
        /// Открытие соединения
        /// </summary>
        [Display(Name = "Открытие соединения")]
        OpenConnection,

        /// <summary>
        /// Отправка
        /// </summary>
        [Display(Name = "Отправка")] Send,

        /// <summary>
        /// Ожидание ответа
        /// </summary>
        [Display(Name = "Ожидание ответа")] WaitForResult,

        /// <summary>
        /// Получение ответа
        /// </summary>
        [Display(Name = "Получение ответа")] GetResult,

        /// <summary>
        /// Декодирование ответа
        /// </summary>
        [Display(Name = "Декодирование ответа")]
        DecodeResult,

        /// <summary>
        /// Задание завершено
        /// </summary>
        [Display(Name = "Задание завершено")] Completed,

        /// <summary>
        /// Ожидание повтора
        /// </summary>
        [Display(Name = "Ожидание повтора")] WaitForRepeat
    }
}