#region

using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using KKTServiceLib.Atol.Types.Enums;

#endregion

namespace KKTServiceLib.Atol.Types.Operations.Fiscal.Ism.CheckMarkingCodeWorkStatus
{
    [Description("Состояние работы ККТ с КМ")]
    public class KKTMarkingCodeWorkStatus
    {
        [Display(Name = "Состояние проверки КМ")]
        public MarkingCodeKKTCheckStatus Status { get; set; }

        [Display(Name = "Тип проверки КМ")] public MarkingCodeKKTCheckType Type { get; set; }

        [Display(Name = "Этап проверки КМ")] public MarkingCodeKKTCheckStage Stage { get; set; }
    }
}