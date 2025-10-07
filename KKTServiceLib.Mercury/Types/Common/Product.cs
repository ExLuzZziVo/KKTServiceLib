#region

using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using CoreLib.CORE.Helpers.ValidationHelpers.Attributes;
using CoreLib.CORE.Resources;
using KKTServiceLib.Mercury.Types.Converters;
using KKTServiceLib.Mercury.Types.Enums;
using KKTServiceLib.Shared.Helpers;

#endregion

namespace KKTServiceLib.Mercury.Types.Common
{
    [Description("Товар")]
    public class Product
    {
        private bool? _alcohol = false;
        private bool? _jewelry = false;
        private PaymentObjectType? _typeCode = PaymentObjectType.Commodity;

        /// <summary>
        /// Товар
        /// </summary>
        /// <param name="code">Код товара</param>
        public Product(uint code)
        {
            Code = code;
        }

        [JsonConstructor]
        private Product() { }

        /// <summary>
        /// Код товара
        /// </summary>
        /// <list type="bullet">
        /// <item>Обязательное поле</item>
        /// </list>
        [Required(ErrorMessageResourceType = typeof(ValidationStrings), ErrorMessageResourceName = "RequiredError")]
        [Display(Name = "Код товара")]
        public uint Code { get; }

        /// <summary>
        /// Штриховой код товара
        /// </summary>
        /// <list type="bullet">
        /// <item>Должно соответствовать регулярному выражению <see cref="RegexHelper.BarcodePattern"/></item>
        /// </list>
        [RegularExpression(RegexHelper.BarcodePattern,
            ErrorMessageResourceType = typeof(ValidationStrings), ErrorMessageResourceName = "StringFormatError")]
        [Display(Name = "Штриховой код товара")]
        [JsonConverter(typeof(BarcodeValueConverter))]
        public string Barcode { get; set; }

        /// <summary>
        /// Наименование товара
        /// </summary>
        /// <list type="bullet">
        /// <item>Максимальная длина: 56</item>
        /// </list>
        [MaxLength(56, ErrorMessageResourceType = typeof(ValidationStrings),
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
        [Range(0, 21474836, ErrorMessageResourceType = typeof(ValidationStrings),
            ErrorMessageResourceName = "DigitRangeValuesError")]
        public decimal? Price { get; set; }

        /// <summary>
        /// Сумма акциза, включенная в стоимость предмета расчета
        /// </summary>
        /// <remarks>
        /// Версия базы ККТ: <b>0.3</b>
        /// </remarks>
        /// <list type="bullet">
        /// <item>Должно лежать в диапазоне: 0.01-21474836</item>
        /// </list>
        [Display(Name = "Сумма акциза, включенная в стоимость предмета расчета")]
        [JsonConverter(typeof(MoneyConverter))]
        [Range(0.01, 21474836, ErrorMessageResourceType = typeof(ValidationStrings),
            ErrorMessageResourceName = "DigitRangeValuesError")]
        public decimal? ExciseAmount { get; set; }

        /// <summary>
        /// Код страны происхождения
        /// </summary>
        /// <remarks>
        /// Версия базы ККТ: <b>0.3</b>
        /// </remarks>
        /// <list type="bullet">
        /// <item>Должно соответствовать регулярному выражению <see cref="RegexHelper.CountryOfOriginCodePattern"/></item>
        /// </list>
        [RegularExpression(RegexHelper.CountryOfOriginCodePattern, ErrorMessageResourceType = typeof(ValidationStrings),
            ErrorMessageResourceName = "StringFormatError")]
        [Display(Name = "Код страны происхождения")]
        public string CountryOfOrigin { get; set; }

        /// <summary>
        /// Регистрационный номер таможенной декларации
        /// </summary>
        /// <remarks>
        /// Версия базы ККТ: <b>0.3</b>
        /// </remarks>
        /// <list type="bullet">
        /// <item>Максимальная длина: 32</item>
        /// </list>
        [MaxLength(32, ErrorMessageResourceType = typeof(ValidationStrings),
            ErrorMessageResourceName = "StringMaxLengthError")]
        [Display(Name = "Регистрационный номер таможенной декларации")]
        public string CustomsDeclaration { get; set; }

        /// <summary>
        /// Маркированный товар
        /// </summary>
        /// <remarks>
        /// Значение по умолчанию: false
        /// Версия базы ККТ: <b>0.2</b>
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
        [Range(1, 16, ErrorMessageResourceType = typeof(ValidationStrings),
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
        public PaymentObjectType? TypeCode
        {
            get => _typeCode;
            set
            {
                _typeCode = value;

                if (_typeCode != PaymentObjectType.Excise && _alcohol == true)
                {
                    _alcohol = false;
                }
            }
        }

        /// <summary>
        /// Штучный товар
        /// </summary>
        /// <remarks>
        /// Значение по умолчанию: true
        /// </remarks>
        [Display(Name = "Штучный товар")]
        public bool? Undivided { get; set; } = true;

        /// <summary>
        /// Мера количества товара
        /// </summary>
        /// <remarks>
        /// Версия базы ККТ: <b>0.4</b>
        /// </remarks>
        [Display(Name = "Мера количества товара")]
        public ItemUnitType? MeasureUnit { get; set; }

        /// <summary>
        /// Количество частей в маркированном товаре
        /// </summary>
        /// <remarks>
        /// Версия базы ККТ: <b>0.4</b>
        /// </remarks>
        [Display(Name = "Количество частей в маркированном товаре")]
        public int? PartsCount { get; set; }

        /// <summary>
        /// Цена за одну часть маркированного товара (указывается при частичной продаже маркированного товара)
        /// </summary>
        /// <remarks>
        /// Версия базы ККТ: <b>0.4</b>
        /// </remarks>
        /// <list type="bullet">
        /// <item>Должно лежать в диапазоне: 0-21474836</item>
        /// </list>
        [Display(Name = "Цена за одну часть маркированного товара")]
        [JsonConverter(typeof(MoneyConverter))]
        [Range(0.01, 21474836, ErrorMessageResourceType = typeof(ValidationStrings),
            ErrorMessageResourceName = "DigitRangeValuesError")]
        public decimal? PartPrice { get; set; }

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
        [Display(Name = "Налоговая ставка")]
        public WatType? TaxCode { get; set; } = WatType.None;

        /// <summary>
        /// Платёжный агент
        /// </summary>
        [Display(Name = "Платёжный агент")]
        public AgentType? Agent { get; set; }

        /// <summary>
        /// Признак блокировки товара для продажи
        /// </summary>
        /// <remarks>
        /// Значение по умолчанию: false<br/>
        /// Версия базы ККТ: <b>0.4</b>
        /// </remarks>
        [Display(Name = "Признак блокировки товара для продажи")]
        public bool? Blocked { get; set; } = false;

        /// <summary>
        /// Признак алкогольной продукции, маркированной федеральными специальными марками
        /// </summary>
        /// <remarks>
        /// Значение по умолчанию: false<br/>
        /// Версия базы ККТ: <b>0.5</b><br/>
        /// Если значение поля устанавливается в true, то код признака предмета расчёта будет иметь значение <see cref="PaymentObjectType.Excise"/>
        /// </remarks>
        [Display(Name = "Признак алкогольной продукции, маркированной федеральными специальными марками")]
        public bool? Alcohol
        {
            get => _alcohol;
            set
            {
                _alcohol = value;

                if (_alcohol == true)
                {
                    _jewelry = false;

                    _typeCode = PaymentObjectType.Excise;
                }
            }
        }

        /// <summary>
        /// Объём потребительской упаковки алкогольной продукции в миллилитрах
        /// </summary>
        /// <list type="bullet">
        /// <item>Обязательное поле, если <see cref="Alcohol"/> имеет значение true</item>
        /// <item>Должно лежать в диапазоне: 1-<see cref="int.MaxValue"/></item>
        /// </list>
        /// <remarks>
        /// Версия базы ККТ: <b>0.5</b><br/>
        /// </remarks>
        [Display(Name = "Объём потребительской упаковки алкогольной продукции в миллилитрах")]
        [RequiredIf(nameof(Alcohol), true,
            ErrorMessageResourceType = typeof(ValidationStrings), ErrorMessageResourceName = "RequiredError")]
        [Range(1, int.MaxValue, ErrorMessageResourceType = typeof(ValidationStrings),
            ErrorMessageResourceName = "DigitRangeValuesError")]
        public int? Volume { get; set; }

        /// <summary>
        /// Признак маркированной ювелирной продукции
        /// </summary>
        /// <remarks>
        /// Значение по умолчанию: false<br/>
        /// Версия базы ККТ: <b>0.6</b>
        /// </remarks>
        [Display(Name = "Признак маркированной ювелирной продукции")]
        public bool? Jewelry
        {
            get => _jewelry;
            set
            {
                _jewelry = value;

                if (_jewelry == true)
                {
                    _alcohol = false;
                    Volume = null;
                }
            }
        }
    }
}
