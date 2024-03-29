#region

using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using KKTServiceLib.Atol.Types.Common.MarkingCodes;

#endregion

namespace KKTServiceLib.Atol.Types.Operations.Fiscal.Ism.AcceptMarkingCode
{
    [Description("Результат подтверждения операции с КМ")]
    public class AcceptMarkingCodeResult
    {
        /// <summary>
        /// Результат сохранения КМ в таблице ФН-М в случае успешной проверки
        /// </summary>
        [Display(Name = "Результат сохранения КМ в таблице ФН-М в случае успешной проверки")]
        public ItemInfoCheckResult ItemInfoCheckResult { get; set; }
    }
}