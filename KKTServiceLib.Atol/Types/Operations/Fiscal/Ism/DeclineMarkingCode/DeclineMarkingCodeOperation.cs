using System.ComponentModel;

namespace KKTServiceLib.Atol.Types.Operations.Fiscal.Ism.DeclineMarkingCode
{
    [Description("Отказ от операции с КМ")]
    public class DeclineMarkingCodeOperation : Operation<bool>
    {
        /// <summary>
        /// Отказ от операции с КМ
        /// </summary>
        public DeclineMarkingCodeOperation() : base("declineMarkingCode") { }
    }
}