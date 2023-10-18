#region

using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

#endregion

namespace KKTServiceLib.Atol.Types.Operations.Fiscal.CreateExchangeStatusReport
{
    [Description("Счетчик количеств операций")]
    public class FnQuantityCounter
    {
        /// <summary>
        /// Количество коррекций
        /// </summary>
        [Display(Name = "Количество коррекций")]
        public uint Corrections { get; set; }

        /// <summary>
        /// Общее количество чеков (включая коррекции)
        /// </summary>
        [Display(Name = "Общее количество чеков (включая коррекции)")]
        public uint Count { get; set; }
    }
}