#region

using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using CoreLib.CORE.Helpers.ValidationHelpers.Attributes;
using CoreLib.CORE.Resources;
using KKTServiceLib.Mercury.Types.Common.KKT;

#endregion

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
        [Required(ErrorMessageResourceType = typeof(ValidationStrings), ErrorMessageResourceName = "RequiredError")]
        [Display(Name = "Параметры работы ККТ")]
        [ComplexObjectValidation(ErrorMessageResourceType = typeof(ValidationStrings),
            ErrorMessageResourceName = "ComplexObjectValidationError")]
        public new KKTWorkParamsInfo Mode { get; }
    }
}