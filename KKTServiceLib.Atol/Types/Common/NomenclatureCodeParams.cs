#region

using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;
using CoreLib.CORE.Helpers.ObjectHelpers;
using CoreLib.CORE.Helpers.StringHelpers;
using CoreLib.CORE.Helpers.ValidationHelpers.Attributes;
using CoreLib.CORE.Resources;
using KKTServiceLib.Atol.Types.Enums;

#endregion

namespace KKTServiceLib.Atol.Types.Common
{
    [Description("Код товара")]
    public class NomenclatureCodeParams
    {
        /// <summary>
        /// Код товара
        /// </summary>
        /// <param name="type">Тип маркировки</param>
        /// <param name="gtin">GTIN</param>
        /// <param name="serial">Код</param>
        public NomenclatureCodeParams(NomenclatureCodeType type, string gtin, string serial)
        {
            if (gtin.IsNullOrEmptyOrWhiteSpace() || !Regex.IsMatch(gtin, RegexExtensions.GTINPattern))
            {
                throw new ArgumentException(
                    string.Format(ValidationStrings.ResourceManager.GetString("StringFormatError"),
                        GetType().GetProperty(nameof(Gtin)).GetPropertyDisplayName()),
                    nameof(gtin));
            }

            if (serial.IsNullOrEmptyOrWhiteSpace() || (type == NomenclatureCodeType.Furs &&
                                                       !Regex.IsMatch(serial, RegexExtensions_Ru.BarcodeFurPattern)))
            {
                throw new ArgumentException(
                    string.Format(ValidationStrings.ResourceManager.GetString("StringFormatError"),
                        GetType().GetProperty(nameof(Serial)).GetPropertyDisplayName()),
                    nameof(serial));
            }

            Type = type;
            Gtin = gtin;
            Serial = serial;
        }

        /// <summary>
        /// Код товара мехового изделия
        /// </summary>
        /// <param name="serial">Код</param>
        public NomenclatureCodeParams(string serial)
        {
            if (serial.IsNullOrEmptyOrWhiteSpace() || !Regex.IsMatch(serial, RegexExtensions_Ru.BarcodeFurPattern))
            {
                throw new ArgumentException(
                    string.Format(ValidationStrings.ResourceManager.GetString("StringFormatError"),
                        GetType().GetProperty(nameof(Serial)).GetPropertyDisplayName()),
                    nameof(serial));
            }

            Type = NomenclatureCodeType.Furs;
            Serial = serial;
        }

        /// <summary>
        /// Тип маркировки
        /// </summary>
        /// <list type="bullet">
        /// <item>Обязательное поле</item>
        /// </list>
        [Required(ErrorMessageResourceType = typeof(ValidationStrings), ErrorMessageResourceName = "RequiredError")]
        [Display(Name = "Тип маркировки")]
        public NomenclatureCodeType Type { get; }

        /// <summary>
        /// Идентификатор продукта GTIN
        /// </summary>
        /// <list type="bullet">
        /// <item>Обязательное поле, если не <see cref="NomenclatureCodeType.Furs"/></item>
        /// <item>Должно соответствовать регулярному выражению <see cref="RegexExtensions.GTINPattern"/></item>
        /// </list>
        [RegularExpression(RegexExtensions.GTINPattern,
            ErrorMessageResourceType = typeof(ValidationStrings), ErrorMessageResourceName = "StringFormatError")]
        [RequiredIf(nameof(Type), NomenclatureCodeType.Furs, ComparisonType.NotEqual,
            ErrorMessageResourceType = typeof(ValidationStrings), ErrorMessageResourceName = "RequiredError")]
        [Display(Name = "Идентификатор продукта GTIN")]
        public string Gtin { get; }

        /// <summary>
        /// Код
        /// </summary>
        /// <list type="bullet">
        /// <item>Обязательное поле</item>
        /// <item>Для <see cref="NomenclatureCodeType.Furs"/> должно соответствовать регулярному выражению <see cref="RegexExtensions_Ru.BarcodeFurPattern"/></item>
        /// </list>
        [Required(ErrorMessageResourceType = typeof(ValidationStrings), ErrorMessageResourceName = "RequiredError")]
        [Display(Name = "Код")]
        public string Serial { get; }
    }
}