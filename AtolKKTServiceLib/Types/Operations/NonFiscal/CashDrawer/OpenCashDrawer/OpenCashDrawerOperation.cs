#region

using System.ComponentModel;

#endregion

namespace AtolKKTServiceLib.Types.Operations.NonFiscal.CashDrawer.OpenCashDrawer
{
    [Description("Открыть денежный ящик")]
    public class OpenCashDrawerOperation : Operation<bool>
    {
        /// <summary>
        /// Открыть денежный ящик
        /// </summary>
        public OpenCashDrawerOperation() : base("openCashDrawer")
        {
        }
    }
}