#region

using System.ComponentModel;

#endregion

namespace AtolKKTServiceLib.Types.Operations.KKT.ContinuePrint
{
    [Description("Допечатать документ")]
    public class ContinuePrintOperation : Operation<bool>
    {
        /// <summary>
        /// Допечатать документ
        /// </summary>
        public ContinuePrintOperation() : base("continuePrint")
        {
        }
    }
}