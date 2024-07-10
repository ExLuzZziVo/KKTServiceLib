#region

using System.ComponentModel;

#endregion

namespace KKTServiceLib.Mercury.Types.Operations.Fiscal.Ism.AcceptMarkingCode
{
    [Description("Подтверждение операции с КМ")]
    public class AcceptMarkingCodeOperation: Operation<AcceptMarkingCodeResult>
    {
        /// <summary>
        /// Подтверждение операции с КМ
        /// </summary>
        public AcceptMarkingCodeOperation(): base("AcceptMarkingCode") { }
    }
}