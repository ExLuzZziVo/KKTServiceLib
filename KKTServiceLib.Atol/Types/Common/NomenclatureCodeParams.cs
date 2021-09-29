#region

using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;
using KKTServiceLib.Atol.Types.Enums;
using KKTServiceLib.Shared.Helpers;
using KKTServiceLib.Shared.Resources;
using KKTServiceLib.Shared.Types.ValidationAttributes;

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
            if (gtin.IsNullOrEmptyOrWhiteSpace() || !Regex.IsMatch(gtin, RegexHelper.GTINPattern))
            {
                throw new ArgumentException(
                    string.Format(ErrorStrings.ResourceManager.GetString("StringFormatError"),
                        GetType().GetProperty(nameof(Gtin)).GetDisplayName()),
                    nameof(gtin));
            }

            if (serial.IsNullOrEmptyOrWhiteSpace() || type == NomenclatureCodeType.Furs &&
                !Regex.IsMatch(serial, RegexHelper.BarcodeFurPattern))
            {
                throw new ArgumentException(
                    string.Format(ErrorStrings.ResourceManager.GetString("StringFormatError"),
                        GetType().GetProperty(nameof(Serial)).GetDisplayName()),
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
            if (serial.IsNullOrEmptyOrWhiteSpace() || !Regex.IsMatch(serial, RegexHelper.BarcodeFurPattern))
            {
                throw new ArgumentException(
                    string.Format(ErrorStrings.ResourceManager.GetString("StringFormatError"),
                        GetType().GetProperty(nameof(Serial)).GetDisplayName()),
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
        [Required(ErrorMessageResourceType = typeof(ErrorStrings), ErrorMessageResourceName = "RequiredError")]
        [Display(Name = "Тип маркировки")]
        public NomenclatureCodeType Type { get; }

        /// <summary>
        /// Идентификатор продукта GTIN
        /// </summary>
        /// <list type="bullet">
        /// <item>Обязательное поле, если не <see cref="NomenclatureCodeType.Furs"/></item>
        /// <item>Должно соответствовать регулярному выражению <see cref="RegexHelper.GTINPattern"/></item>
        /// </list>
        [RegularExpression(RegexHelper.GTINPattern,
            ErrorMessageResourceType = typeof(ErrorStrings), ErrorMessageResourceName = "StringFormatError")]
        [RequiredIfValidation(nameof(Type), NomenclatureCodeType.Furs, true,
            ErrorMessageResourceType = typeof(ErrorStrings), ErrorMessageResourceName = "RequiredError")]
        [Display(Name = "Идентификатор продукта GTIN")]
        public string Gtin { get; }

        /// <summary>
        /// Код
        /// </summary>
        /// <list type="bullet">
        /// <item>Обязательное поле</item>
        /// <item>Для <see cref="NomenclatureCodeType.Furs"/> должно соответствовать регулярному выражению <see cref="RegexHelper.BarcodeFurPattern"/></item>
        /// </list>
        [Required(ErrorMessageResourceType = typeof(ErrorStrings), ErrorMessageResourceName = "RequiredError")]
        [Display(Name = "Код")]
        public string Serial { get; }
    }
}