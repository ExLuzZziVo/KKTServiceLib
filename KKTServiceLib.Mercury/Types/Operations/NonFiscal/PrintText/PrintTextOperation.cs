#region

using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using CoreLib.CORE.Helpers.ObjectHelpers;
using CoreLib.CORE.Helpers.StringHelpers;
using CoreLib.CORE.Resources;

#endregion

namespace KKTServiceLib.Mercury.Types.Operations.NonFiscal.PrintText
{
    [Description("Печать текста")]
    public class PrintTextOperation : Operation<PrintTextResult>
    {
        /// <summary>
        /// Печать текста
        /// </summary>
        /// <param name="text"></param>
        public PrintTextOperation(string text) : base("PrintText")
        {
            if (text.IsNullOrEmptyOrWhiteSpace())
            {
                throw new ArgumentException(
                    string.Format(
                        ValidationStrings.ResourceManager.GetString("StringFormatError"),
                        GetType().GetProperty(nameof(Text)).GetPropertyDisplayName()),
                    nameof(text));
            }

            Text = text;
        }

        /// <summary>
        /// Строка для печати
        /// </summary>
        /// <list type="bullet">
        /// <item>Обязательное поле</item>
        /// <item>Максимальная длина: 1024</item>
        /// </list>
        [Required(ErrorMessageResourceType = typeof(ValidationStrings), ErrorMessageResourceName = "RequiredError")]
        [MaxLength(1024, ErrorMessageResourceType = typeof(ValidationStrings),
            ErrorMessageResourceName = "StringMaxLengthError")]
        [Display(Name = "Строка для печати")]
        public string Text { get; }

        /// <summary>
        /// Принудительная печать
        /// </summary>
        /// <remarks>
        /// Значение по умолчанию: true
        /// </remarks>
        [Display(Name = "Принудительная печать")]
        public bool? ForcePrint { get; set; } = true;
    }
}