using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using KKTServiceLib.Shared.Helpers;
using KKTServiceLib.Shared.Resources;
using Newtonsoft.Json;

namespace KKTServiceLib.Mercury.Types.Common
{
    [Description("Отраслевой реквизит чека")]
    public class IndustryRequisiteReceiptParams : IndustryRequisiteParams
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
                        ErrorStrings.ResourceManager.GetString("StringFormatError"),
                        GetType().GetProperty(nameof(Value)).GetDisplayName()),
                    nameof(value));
            }

            Value = value;
        }

        /// <summary>
        /// Значение отраслевого реквизита
        /// </summary>
        /// <list type="bullet">
        /// <item>Обязательное поле</item>
        /// </list>
        [Display(Name = "Значение отраслевого реквизита")]
        [JsonProperty("attrValue")]
        [Required(ErrorMessageResourceType = typeof(ErrorStrings), ErrorMessageResourceName = "RequiredError")]
        public sealed override string Value { get; set; }
    }
}