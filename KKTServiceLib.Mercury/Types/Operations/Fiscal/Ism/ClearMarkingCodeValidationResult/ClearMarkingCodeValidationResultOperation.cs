using System.ComponentModel;

namespace KKTServiceLib.Mercury.Types.Operations.Fiscal.Ism.ClearMarkingCodeValidationResult
{
    [Description("Очистка таблицы проверенных КМ ФН-М")]
    public class ClearMarkingCodeValidationResultOperation : Operation<ClearMarkingCodeValidationResultResult>
    {
        /// <summary>
        /// Очистка таблицы проверенных КМ ФН-М
        /// </summary>
        public ClearMarkingCodeValidationResultOperation() : base("ClearMarkingCodeValidationTable") { }
    }
}