#region

using System.ComponentModel;

#endregion

namespace KKTServiceLib.Mercury.Types.Operations.KKT.OpenCashDrawer
{
    [Description("Открыть денежный ящик")]
    public class OpenCashDrawerOperation : Operation<OpenCashDrawerResult>
    {
        /// <summary>
        /// Открыть денежный ящик
        /// </summary>
        public OpenCashDrawerOperation() : base("OpenBox") { }
    }
}