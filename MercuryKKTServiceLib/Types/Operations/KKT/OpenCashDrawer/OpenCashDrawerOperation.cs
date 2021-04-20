using System.ComponentModel;

namespace MercuryKKTServiceLib.Types.Operations.KKT.OpenCashDrawer
{
    [Description("Открыть денежный ящик")]
    public class OpenCashDrawerOperation : Operation<OpenCashDrawerResult>
    {
        /// <summary>
        /// Открыть денежный ящик
        /// </summary>
        public OpenCashDrawerOperation() : base("OpenBox")
        {
        }
    }
}