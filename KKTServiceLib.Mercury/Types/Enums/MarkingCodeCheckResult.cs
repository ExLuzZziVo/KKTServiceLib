using System.ComponentModel.DataAnnotations;

namespace KKTServiceLib.Mercury.Types.Enums
{
    /// <summary>
    /// Результат проверки КМ
    /// </summary>
    public enum MarkingCodeCheckResult : byte
    {
        /// <summary>
        /// КМ успешно проверен
        /// </summary>
        [Display(Name = "КМ успешно проверен")]
        Checked = 0,

        /// <summary>
        /// КМ данного типа не подлежит проверке в ФН
        /// </summary>
        [Display(Name = "КМ данного типа не подлежит проверке в ФН")]
        TypeIncorrect = 1,

        /// <summary>
        /// ФН не содержит ключи проверки кода проверки этого КМ
        /// </summary>
        [Display(Name = "ФН не содержит ключи проверки кода проверки этого КМ")]
        NoKeys = 2,

        /// <summary>
        /// Проверка невозможна, так как отсутствуют идентификаторы применения GS1 91 и/или 92 или их формат неверный
        /// </summary>
        [Display(Name =
            "Проверка невозможна, так как отсутствуют идентификаторы применения GS1 91 и/или 92 или их формат неверный")]
        NoGS1 = 3,

        /// <summary>
        /// Проверка невозможна по иной причине
        /// </summary>
        [Display(Name = "Проверка невозможна по иной причине")]
        Other = 4
    }
}