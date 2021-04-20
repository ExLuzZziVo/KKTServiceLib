using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace MercuryKKTServiceLib.Types.Operations.Fiscal.KKTRegistration.GetKKTRegistrationInfo
{
    [Description("Результат запроса параметров регистрации ККТ")]
    public class GetKKTRegistrationInfoResult : OperationResult
    {
        /// <summary>
        /// ККТ зарегистрирована
        /// </summary>
        [Display(Name = "ККТ зарегистрирована")]
        public bool IsRegistered { get; set; }

        /// <summary>
        /// Информация о регистрации ККТ
        /// </summary>
        [Display(Name = "Информация о регистрации ККТ")]
        public KKTRegistrationInfo RegistrationInfo { get; set; }
    }
}