#region

using System.ComponentModel;

#endregion

namespace KKTServiceLib.Atol.Types.Operations.Fiscal.Ism.CheckMarkingCodeValidationsReady
{
    [Description("Проверка состояния фоновой проверки")]
    public class CheckMarkingCodeValidationsReadyOperation: Operation<CheckMarkingCodeValidationsReadyResult>
    {
        /// <summary>
        /// Проверка состояния фоновой проверки
        /// </summary>
        public CheckMarkingCodeValidationsReadyOperation(): base("checkMarkingCodeValidationsReady") { }
    }
}