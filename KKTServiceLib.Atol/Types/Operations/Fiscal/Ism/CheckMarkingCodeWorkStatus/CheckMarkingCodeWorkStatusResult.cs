using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using KKTServiceLib.Atol.Types.Enums;

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