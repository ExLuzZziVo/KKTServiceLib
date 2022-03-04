using System.ComponentModel.DataAnnotations;
using KKTServiceLib.Mercury.Types.Common.KKT;
using KKTServiceLib.Shared.Resources;
using KKTServiceLib.Shared.Types.ValidationAttributes;
using Newtonsoft.Json;

namespace KKTServiceLib.Mercury.Types.Operations.Fiscal.KKTRegistration.GetKKTRegistrationInfo
{
    public class KKTParamsInfo : KKTParams
    {
        [JsonConstructor]
        private KKTParamsInfo() { }

        /// <summary>
        /// Параметры работы ККТ
        /// </summary>
        /// <list type="bullet">
        /// <item>Обязательное поле</item>
        /// </list>
        [Required(ErrorMessageResourceType = typeof(ErrorStrings), ErrorMessageResourceName = "RequiredError")]
        [Display(Name = "Параметры работы ККТ")]
        [ComplexObjectValidation(ErrorMessageResourceType = typeof(ErrorStrings),
            ErrorMessageResourceName = "ComplexObjectValidationError")]
        public new KKTWorkParamsInfo Mode { get; }
    }
}