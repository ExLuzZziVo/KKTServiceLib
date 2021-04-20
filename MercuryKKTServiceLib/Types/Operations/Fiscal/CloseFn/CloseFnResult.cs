using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace MercuryKKTServiceLib.Types.Operations.Fiscal.CloseFn
{
    [Description("Результат закрытия ФН")]
    public class CloseFnResult : FiscalOperationResult
    {
        /// <summary>
        /// Номер фискального накопителя
        /// </summary>
        [Display(Name = "Номер фискального накопителя")]
        public string FnNum { get; set; }
    }
}