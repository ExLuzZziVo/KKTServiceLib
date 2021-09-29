using System.ComponentModel;

namespace KKTServiceLib.Atol.Types.Operations.Fiscal.Ism.CancelMarkingCodeValidation
{
    [Description("Прерывание проверки КМ")]
    public class CancelMarkingCodeValidationOperation : Operation<bool>
    {
        /// <summary>
        /// Прерывание проверки КМ
        /// </summary>
        public CancelMarkingCodeValidationOperation() : base("cancelMarkingCodeValidation") { }
    }
}