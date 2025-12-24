#region

using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using CoreLib.CORE.Helpers.ValidationHelpers.Attributes;
using CoreLib.CORE.Resources;
using TimeZone = KKTServiceLib.Atol.Types.Enums.TimeZone;

#endregion

namespace KKTServiceLib.Atol.Types.Common
{
    [Description("Данные уведомления")]
    public class NotificationData
    {
        /// <summary>
        /// Часовая зона
        /// </summary>
        [Display(Name = "Часовая зона")]
        public TimeZone? TimeZone { get; set; }

        /// <summary>
        /// Дополнительный реквизит пользователя
        /// </summary>
        [ComplexObjectValidation(ErrorMessageResourceType = typeof(ValidationStrings),
            ErrorMessageResourceName = "ComplexObjectValidationError")]
        [Display(Name = "Дополнительный реквизит пользователя")]
        public AdditionalAttributeUserParams UserAttribute { get; set; }
    }
}
