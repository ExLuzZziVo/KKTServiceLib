using System.ComponentModel;

namespace KKTServiceLib.Atol.Types.Operations.Fiscal.Ism.AcceptMarkingCode
{
    [Description("Подтверждение реализации КМ")]
    public class AcceptMarkingCodeOperation : Operation<AcceptMarkingCodeResult>
    {
        /// <summary>
        /// Подтверждение реализации КМ
        /// </summary>
        public AcceptMarkingCodeOperation() : base("acceptMarkingCode") { }
    }
}