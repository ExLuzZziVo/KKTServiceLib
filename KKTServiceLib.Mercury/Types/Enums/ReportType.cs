#region

using System.ComponentModel.DataAnnotations;

#endregion

namespace KKTServiceLib.Mercury.Types.Enums
{
    /// <summary>
    /// Тип отчета
    /// </summary>
    public enum ReportType : byte
    {
        /// <summary>
        /// Полный отчёт за смену из ФН
        /// </summary>
        [Display(Name = "Полный отчёт за смену из ФН")]
        XReport = 1,

        /// <summary>
        /// Отчёт за смену по кассирам из ФН
        /// </summary>
        [Display(Name = "Отчёт за смену по кассирам из ФН")]
        ByOperators = 2,

        /// <summary>
        /// Отчёт за смену по товарам из ФН
        /// </summary>
        [Display(Name = "Отчёт за смену по товарам из ФН")]
        ByGoods = 3,

        /// <summary>
        /// Отчёт за смену по товарам и кассирам из ФН
        /// </summary>
        [Display(Name = "Отчёт за смену по товарам и кассирам из ФН")]
        ByGoodsAndOperators = 4,

        /// <summary>
        /// Полный отчёт за смену из ККТ
        /// </summary>
        [Display(Name = "Полный отчёт за смену из ККТ")]
        ByShift = 5
    }
}