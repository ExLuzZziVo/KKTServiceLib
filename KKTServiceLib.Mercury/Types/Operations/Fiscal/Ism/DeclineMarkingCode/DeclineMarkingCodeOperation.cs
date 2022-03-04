using System.ComponentModel;

namespace KKTServiceLib.Mercury.Types.Operations.Fiscal.Ism.DeclineMarkingCode
{
    [Description("Отказ от операции с КМ")]
    public class DeclineMarkingCodeOperation : Operation<DeclineMarkingCodeResult>
    {
        /// <summary>
        /// Отказ от операции с КМ
        /// </summary>
        public DeclineMarkingCodeOperation() : base("RejectMarkingCode") { }
    }
}