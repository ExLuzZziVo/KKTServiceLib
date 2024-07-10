#region

using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using CoreLib.CORE.Helpers.Converters;

#endregion

namespace KKTServiceLib.Atol.Types.Enums
{
    /// <summary>
    /// Результат проверки КМ
    /// </summary>
    [JsonConverter(typeof(JsonCamelCaseStringEnumConverter))]
    public enum MarkingCodeCheckResult: byte
    {
        /// <summary>
        /// КМ успешно проверен
        /// </summary>
        [Display(Name = "КМ успешно проверен")]
        Checked,

        /// <summary>
        /// КМ данного типа не подлежит проверке в ФН
        /// </summary>
        [Display(Name = "КМ данного типа не подлежит проверке в ФН")]
        TypeIncorrect,

        /// <summary>
        /// ФН не содержит ключи проверки кода проверки этого КМ
        /// </summary>
        [Display(Name = "ФН не содержит ключи проверки кода проверки этого КМ")]
        NoKeys,

        /// <summary>
        /// Проверка невозможна, так как отсутствуют идентификаторы применения GS1 91 и/или 92 или их формат неверный
        /// </summary>
        [Display(Name =
            "Проверка невозможна, так как отсутствуют идентификаторы применения GS1 91 и/или 92 или их формат неверный")]
        NoGS1,

        /// <summary>
        /// Проверка невозможна по иной причине
        /// </summary>
        [Display(Name = "Проверка невозможна по иной причине")]
        Other
    }
}