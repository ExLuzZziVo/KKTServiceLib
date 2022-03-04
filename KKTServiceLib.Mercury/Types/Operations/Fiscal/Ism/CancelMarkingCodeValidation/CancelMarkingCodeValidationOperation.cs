using System.ComponentModel;

namespace KKTServiceLib.Mercury.Types.Operations.Fiscal.Ism.CancelMarkingCodeValidation
{
    [Description("Прерывание проверки КМ")]
    public class CancelMarkingCodeValidationOperation : Operation<CancelMarkingCodeValidationResult>
    {
        /// <summary>
        /// Прерывание проверки КМ
        /// </summary>
        public CancelMarkingCodeValidationOperation() : base("AbortMarkingCodeChecking") { }
    }
}