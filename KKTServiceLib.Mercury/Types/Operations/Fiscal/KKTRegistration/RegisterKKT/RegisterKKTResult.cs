#region

using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

#endregion

namespace KKTServiceLib.Mercury.Types.Operations.Fiscal.KKTRegistration.RegisterKKT
{
    [Description("Результат регистрации/перерегистрации ККТ")]
    public class RegisterKKTResult : FiscalOperationResult
    {
        /// <summary>
        /// Номер фискального накопителя
        /// </summary>
        [Display(Name = "Номер фискального накопителя")]
        public string FnNum { get; set; }
    }
}