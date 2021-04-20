using System.ComponentModel;

namespace MercuryKKTServiceLib.Types.Operations.Fiscal.Receipt.ResetCheck
{
    [Description("Аннулирование (сброс) текущего чека")]
    public class ResetCheckOperation : Operation<ResetCheckResult>
    {
        /// <summary>
        /// Аннулирование (сброс) текущего чека
        /// </summary>
        public ResetCheckOperation() : base("ResetCheck")
        {
        }
    }
}