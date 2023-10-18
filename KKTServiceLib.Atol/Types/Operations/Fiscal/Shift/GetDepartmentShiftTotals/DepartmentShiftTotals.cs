#region

using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

#endregion

namespace KKTServiceLib.Atol.Types.Operations.Fiscal.Shift.GetDepartmentShiftTotals
{
    [Description("Сменные итоги по секциям")]
    public class DepartmentShiftTotals
    {
        /// <summary>
        /// Сменные итоги по секции 1
        /// </summary>
        [Display(Name = "Сменные итоги по секции 1")]
        public DepartmentShiftTotalsSums Department1 { get; set; }

        /// <summary>
        /// Сменные итоги по секции 2
        /// </summary>
        [Display(Name = "Сменные итоги по секции 2")]
        public DepartmentShiftTotalsSums Department2 { get; set; }

        /// <summary>
        /// Сменные итоги по секции 3
        /// </summary>
        [Display(Name = "Сменные итоги по секции 3")]
        public DepartmentShiftTotalsSums Department3 { get; set; }

        /// <summary>
        /// Сменные итоги по секции 4
        /// </summary>
        [Display(Name = "Сменные итоги по секции 4")]
        public DepartmentShiftTotalsSums Department4 { get; set; }

        /// <summary>
        /// Сменные итоги по секции 5
        /// </summary>
        [Display(Name = "Сменные итоги по секции 5")]
        public DepartmentShiftTotalsSums Department5 { get; set; }
    }
}