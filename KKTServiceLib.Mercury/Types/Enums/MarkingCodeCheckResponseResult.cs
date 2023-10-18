#region

using System.ComponentModel.DataAnnotations;

#endregion

namespace KKTServiceLib.Mercury.Types.Enums
{
    /// <summary>
    /// Код обработки запроса
    /// </summary>
    public enum MarkingCodeCheckResponseResult : byte
    {
        /// <summary>
        /// Запрос имеет корректный формат, в том числе корректный формат кода маркировки
        /// </summary>
        [Display(Name = "Запрос имеет корректный формат, в том числе корректный формат кода маркировки")]
        Correct = 0,

        /// <summary>
        /// Запрос имеет некорректный формат
        /// </summary>
        [Display(Name = "Запрос имеет некорректный формат")]
        Incorrect = 1,

        /// <summary>
        /// Указанный в запросе код маркировки имеет некорректный формат (не распознан)
        /// </summary>
        [Display(Name = "Указанный в запросе код маркировки имеет некорректный формат (не распознан)")]
        Unrecognized = 2
    }
}