using System.ComponentModel;

namespace KKTServiceLib.Atol.Types.Operations.Fiscal.Ism.ClearMarkingCodeValidationResult
{
    [Description("Очистка таблицы проверенных КМ ФН-М")]
    public class ClearMarkingCodeValidationResultOperation : Operation<bool>
    {
        /// <summary>
        /// Очистка таблицы проверенных КМ ФН-М
        /// </summary>
        public ClearMarkingCodeValidationResultOperation() : base("clearMarkingCodeValidationResult") { }
    }
}