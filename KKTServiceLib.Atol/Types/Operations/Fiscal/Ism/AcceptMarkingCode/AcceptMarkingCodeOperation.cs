using System.ComponentModel;

namespace KKTServiceLib.Atol.Types.Operations.Fiscal.Ism.AcceptMarkingCode
{
    [Description("Подтверждение операции с КМ")]
    public class AcceptMarkingCodeOperation : Operation<AcceptMarkingCodeResult>
    {
        /// <summary>
        /// Подтверждение операции с КМ
        /// </summary>
        public AcceptMarkingCodeOperation() : base("acceptMarkingCode") { }
    }
}