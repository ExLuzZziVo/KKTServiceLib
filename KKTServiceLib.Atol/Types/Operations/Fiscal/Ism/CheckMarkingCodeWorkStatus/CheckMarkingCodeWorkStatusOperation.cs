#region

using System.ComponentModel;

#endregion

namespace KKTServiceLib.Atol.Types.Operations.Fiscal.Ism.CheckMarkingCodeWorkStatus
{
    [Description("Запрос состояния работы с КМ")]
    public class CheckMarkingCodeWorkStatusOperation: Operation<CheckMarkingCodeWorkStatusResult>
    {
        /// <summary>
        /// Запрос состояния работы с КМ
        /// </summary>
        public CheckMarkingCodeWorkStatusOperation(): base("checkImcWorkState") { }
    }
}