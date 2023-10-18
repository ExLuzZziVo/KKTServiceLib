#region

using System.ComponentModel;

#endregion

namespace KKTServiceLib.Atol.Types.Operations.Fiscal.Ism.CheckMarkingCodeWorkStatus
{
    [Description("Результат запроса состояния работы с КМ")]
    public class CheckMarkingCodeWorkStatusResult
    {
        /// <summary>
        /// Состояние работы ФН с КМ
        /// </summary>
        public FnMarkingCodeWorkStatus Fm { get; set; }

        /// <summary>
        /// Состояние работы ККТ с КМ
        /// </summary>
        public KKTMarkingCodeWorkStatus Ecr { get; set; }
    }
}