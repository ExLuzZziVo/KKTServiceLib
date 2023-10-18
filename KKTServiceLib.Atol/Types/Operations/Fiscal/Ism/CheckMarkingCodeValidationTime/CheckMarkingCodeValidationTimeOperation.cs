#region

using System.ComponentModel;

#endregion

namespace KKTServiceLib.Atol.Types.Operations.Fiscal.Ism.CheckMarkingCodeValidationTime
{
    [Description("Запрос времени проверки КМ")]
    public class CheckMarkingCodeValidationTimeOperation : Operation<CheckMarkingCodeValidationTimeResult>
    {
        /// <summary>
        /// Запрос времени проверки КМ
        /// </summary>
        public CheckMarkingCodeValidationTimeOperation() : base("checkImcTime") { }
    }
}