using System.ComponentModel;

namespace KKTServiceLib.Atol.Types.Operations.Fiscal.Ism.DeclineMarkingCode
{
    [Description("Отказ от реализации КМ")]
    public class DeclineMarkingCodeOperation : Operation<bool>
    {
        /// <summary>
        /// Отказ от реализации КМ
        /// </summary>
        public DeclineMarkingCodeOperation() : base("declineMarkingCode") { }
    }
}