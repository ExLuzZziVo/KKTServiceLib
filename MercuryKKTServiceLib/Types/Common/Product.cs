using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using KKTServiceLib.Shared.Helpers;
using KKTServiceLib.Shared.Resources;
using MercuryKKTServiceLib.Types.Converters;
using MercuryKKTServiceLib.Types.Enums;
using Newtonsoft.Json;

namespace MercuryKKTServiceLib.Types.Common
{
    [Description("Товар")]
    public class Product
    {
        /// <summary>
        /// Товар
        /// </summary>
        /// <param name="code">Код товара</param>
        public Product(uint code)
        {
            Code = code;
        }

        [JsonConstructor]
        private Product()
        {
        }

        /// <summary>
        /// Код товара
        /// </summary>
        /// <list type="bullet">
        /// <item>Обязательное поле</item>
        /// </list>
        [Required(ErrorMessageResourceType = typeof(ErrorStrings), ErrorMessageResourceName = "RequiredError")]
        [Display(Name = "Код товара")]
        public uint Code { get; }

        /// <summary>
        /// Штриховой код товара
        /// </summary>
        /// <list type="bullet">
        /// <item>Должно соответствовать регулярному выражению <see cref="RegexHelper.BarcodePattern"/></item>
        /// </list>
        [RegularExpression(RegexHelper.BarcodePattern,
            ErrorMessageResourceType = typeof(ErrorStrings), ErrorMessageResourceName = "StringFormatError")]
        [Display(Name = "Штриховой код товара")]
        [JsonConverter(typeof(BarcodeValueConverter))]
        public string Barcode { get; set; }

        /// <summary>
        /// Наименование товара
        /// </summary>
        /// <list type="bullet">
        /// <item>Максимальная длина: 56</item>
        /// </list>
        [MaxLength(56, ErrorMessageResourceType = typeof(ErrorStrings),
            ErrorMessageResourceName = "StringMaxLengthError")]
        [Display(Name = "Наименование товара")]
        public string Name { get; set; }

        /// <summary>
        /// Цена товара
        /// </summary>
        /// <list type="bullet">
        /// <item>Должно лежать в диапазоне: 0-21474836</item>
        /// </list>
        [Display(Name = "Цена товара")]
        [JsonConverter(typeof(MoneyConverter))]
        [Range(0, 21474836, ErrorMessageResourceType = typeof(ErrorStrings),
            ErrorMessageResourceName = "DigitRangeValuesError")]
        public decimal? Price { get; set; }

        /// <summary>
        /// Маркированный товар
        /// </summary>
        /// <remarks>
        /// Значение по умолчанию: false
        /// </remarks>
        [Display(Name = "Маркированный товар")]
        public bool? Marked { get; set; } = false;

        /// <summary>
        /// Номер отдела (секции)
        /// </summary>
        /// <list type="bullet">
        /// <item>Должно лежать в диапазоне: 1-16</item>
        /// </list>
        /// <remarks>
        /// Значение по умолчанию: 1
        /// </remarks>
        [Range(1, 16, ErrorMessageResourceType = typeof(ErrorStrings),
            ErrorMessageResourceName = "DigitRangeValuesError")]
        [Display(Name = "Номер отдела (секции)")]
        public ushort? Section { get; set; } = 1;

        /// <summary>
        /// Признак предмета расчета
        /// </summary>
        /// <remarks>
        /// Значение по умолчанию: <see cref="PaymentObjectType.Commodity"/>
        /// </remarks>
        [Display(Name = "Признак предмета расчета")]
        public PaymentObjectType? TypeCode { get; set; } = PaymentObjectType.Commodity;

        /// <summary>
        /// Штучный товар
        /// </summary>
        /// <remarks>
        /// Значение по умолчанию: true
        /// </remarks>
        [Display(Name = "Штучный товар")] public bool? Undivided { get; set; } = true;

        /// <summary>
        /// Система налогообложения
        /// </summary>
        [Display(Name = "Система налогообложения")]
        public TaxationType? TaxSystem { get; set; }

        /// <summary>
        /// Налоговая ставка
        /// </summary>
        /// <remarks>
        /// Значение по умолчанию: <see cref="WatType.None"/>
        /// </remarks>
        [Display(Name = "Налоговая ставка")] public WatType? TaxCode { get; set; } = WatType.None;

        /// <summary>
        /// Платёжный агент
        /// </summary>
        [Display(Name = "Платёжный агент")] public AgentType? Agent { get; set; }
    }
}