#region

using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using KKTServiceLib.Atol.Types.Enums;
using KKTServiceLib.Shared.Helpers;
using KKTServiceLib.Shared.Resources;

#endregion

namespace KKTServiceLib.Atol.Types.Common
{
    [Description("Код маркировки (ФФД < 1.2)")]
    public class MarkingCodeParams
    {
        /// <summary>
        /// Код маркировки (ФФД < 1.2)
        /// </summary>
        /// <param name="mark">Base64-представление значения кода маркировки</param>
        public MarkingCodeParams(string mark)
        {
            if (mark.IsNullOrEmptyOrWhiteSpace())
            {
                throw new ArgumentException(
                    string.Format(ErrorStrings.ResourceManager.GetString("StringFormatError"),
                        GetType().GetProperty(nameof(Mark)).GetDisplayName()), nameof(mark));
            }

            Mark = mark;
        }

        /// <summary>
        /// Тип маркировки
        /// </summary>
        /// <list type="bullet">
        /// <item>Обязательное поле</item>
        /// </list>
        [Required(ErrorMessageResourceType = typeof(ErrorStrings), ErrorMessageResourceName = "RequiredError")]
        [Display(Name = "Тип маркировки")]
        public MarkingCodeType Type { get; set; } = MarkingCodeType.Other;

        /// <summary>
        /// Base64-представление значения кода маркировки
        /// </summary>
        /// <list type="bullet">
        /// <item>Обязательное поле</item>
        /// </list>
        [Required(ErrorMessageResourceType = typeof(ErrorStrings), ErrorMessageResourceName = "RequiredError")]
        [Display(Name = "Base64-представление значения кода маркировки")]
        public string Mark { get; }
    }
}