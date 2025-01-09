#region

using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using CoreLib.CORE.Helpers.ObjectHelpers;
using CoreLib.CORE.Helpers.StringHelpers;
using CoreLib.CORE.Resources;

#endregion

namespace KKTServiceLib.Mercury.Types.Common
{
    [Description("Отраслевой реквизит чека")]
    public class IndustryRequisiteReceiptParams: IndustryRequisiteParams
    {
        /// <summary>
        /// Отраслевой реквизит чека
        /// </summary>
        /// <param name="value">Значение отраслевого реквизита</param>
        public IndustryRequisiteReceiptParams(string value)
        {
            if (value.IsNullOrEmptyOrWhiteSpace())
            {
                throw new ArgumentException(
                    string.Format(
                        ValidationStrings.ResourceManager.GetString("StringFormatError"),
                        GetType().GetProperty(nameof(Value)).GetPropertyDisplayName()),
                    nameof(value));
            }

            Value = value;
        }

        [JsonConstructor]
        private IndustryRequisiteReceiptParams() { }

        /// <summary>
        /// Значение отраслевого реквизита
        /// </summary>
        /// <list type="bullet">
        /// <item>Обязательное поле</item>
        /// </list>
        [Display(Name = "Значение отраслевого реквизита")]
        [JsonPropertyName("attrValue")]
        [Required(ErrorMessageResourceType = typeof(ValidationStrings), ErrorMessageResourceName = "RequiredError")]
        public sealed override string Value { get; set; }
    }
}
