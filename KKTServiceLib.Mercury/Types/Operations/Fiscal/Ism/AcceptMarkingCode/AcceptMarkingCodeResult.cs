#region

using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

#endregion

namespace KKTServiceLib.Mercury.Types.Operations.Fiscal.Ism.AcceptMarkingCode
{
    [Description("Результат подтверждения операции с КМ")]
    public class AcceptMarkingCodeResult : OperationResult
    {
        /// <summary>
        /// Итоговый результат проверки КМ
        /// </summary>
        /// <remarks>
        /// Необработанное значение тега 2106, сформированного ФН по результатам проверки КМ в ФН и ИСМ
        /// </remarks>
        [Display(Name = "Итоговый результат проверки КМ")]
        public int McCheckResultRaw { get; set; }
    }
}