#region

using System.ComponentModel;

#endregion

namespace AtolKKTServiceLib.Types.Operations.KKT.PrintLastReceiptCopy
{
    [Description("Печать копии последнего чека")]
    public class PrintLastReceiptCopyOperation : Operation<bool>
    {
        /// <summary>
        /// Печать копии последнего чека
        /// </summary>
        public PrintLastReceiptCopyOperation() : base("printLastReceiptCopy")
        {
        }
    }
}