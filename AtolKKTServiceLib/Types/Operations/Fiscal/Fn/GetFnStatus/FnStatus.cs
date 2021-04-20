#region

using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using AtolKKTServiceLib.Types.Common.Warnings;

#endregion

namespace AtolKKTServiceLib.Types.Operations.Fiscal.Fn.GetFnStatus
{
    [Description("Информация о состоянии ФН")]
    public class FnStatus
    {
        /// <summary>
        /// Номер последнего ФД
        /// </summary>
        [Display(Name = "Номер последнего ФД")]
        public uint FiscalDocumentNumber { get; set; }

        /// <summary>
        /// Количество чеков за смену
        /// </summary>
        [Display(Name = "Количество чеков за смену")]
        public uint FiscalReceiptNumber { get; set; }

        /// <summary>
        /// Предупреждения ФН
        /// </summary>
        [Display(Name = "Предупреждения ФН")]
        public FnWarning Warnings { get; set; }
    }
}