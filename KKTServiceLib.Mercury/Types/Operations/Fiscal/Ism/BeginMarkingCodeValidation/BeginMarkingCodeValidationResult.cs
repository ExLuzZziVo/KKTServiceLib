using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using KKTServiceLib.Mercury.Types.Common.MarkingCodes;

namespace KKTServiceLib.Mercury.Types.Operations.Fiscal.Ism.BeginMarkingCodeValidation
{
    [Description("Результат проверки кода маркировки")]
    public class BeginMarkingCodeValidationResult : OperationResult
    {
        /// <summary>
        /// Результат проверки КМ в ФН
        /// </summary>
        [Display(Name = "Результат проверки КМ в ФН")]
        public MarkingCodeCheckOfflineValidationResult FnCheck { get; set; }

        /// <summary>
        /// Информация о коде маркировки, сформированная ККТ
        /// </summary>
        [Display(Name = "Информация о коде маркировки, сформированная ККТ")]
        public MarkingCodeInfo McInfo { get; set; }

        /// <summary>
        /// Проверка в <b>только</b> автономном режиме
        /// </summary>
        [Display(Name = "Проверка только в автономном режиме")]
        public bool IsOfflineMode { get; set; }
    }
}