#region

using System.ComponentModel;

#endregion

namespace KKTServiceLib.Atol.Types.Operations.Fiscal.Ism.GetMarkingCodeValidationStatus
{
    [Description("Получение результата проверки КМ")]
    public class GetMarkingCodeValidationStatusOperation: Operation<GetMarkingCodeValidationStatusResult>
    {
        /// <summary>
        /// Получение результата проверки КМ
        /// </summary>
        public GetMarkingCodeValidationStatusOperation(): base("getMarkingCodeValidationStatus") { }
    }
}