#region

using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using KKTServiceLib.Atol.Types.Common.Agent;
using KKTServiceLib.Atol.Types.Enums;
using KKTServiceLib.Shared.Helpers;
using KKTServiceLib.Shared.Resources;
using KKTServiceLib.Shared.Types.ValidationAttributes;

#endregion

namespace KKTServiceLib.Atol.Types.Common.Document
{
    [Description("Предмет расчета (ФФД < 1.2)")]
    public class PositionDocumentParams : DocumentParams
    {
        private MarkingCodeParams _markingCode;
        protected object _nomenclatureCode;

        /// <summary>
        /// Предмет расчета (ФФД < 1.2)
        /// </summary>
        /// <param name="name">Наименование</param>
        /// <param name="price">Цена единицы</param>
        /// <param name="quantity">Количество</param>
        /// <param name="tax">Налог</param>
        /// <param name="paymentMethodType">Способ расчета</param>
        /// <param name="paymentObjectType">Тип предмета расчета</param>
        public PositionDocumentParams(string name, decimal price, double quantity, TaxParams tax,
            PaymentMethodType paymentMethodType, PaymentObjectType paymentObjectType) : base(
            PrintDocumentType.Position)
        {
            if (name.IsNullOrEmptyOrWhiteSpace())
            {
                throw new ArgumentException(
                    string.Format(ErrorStrings.ResourceManager.GetString("StringFormatError"),
                        GetType().GetProperty(nameof(Name)).GetDisplayName()),
                    nameof(name));
            }

            if (price < 0)
            {
                throw new ArgumentException(
                    string.Format(ErrorStrings.ResourceManager.GetString("DigitRangeValuesError"),
                        GetType().GetProperty(nameof(Price)).GetDisplayName(), 0, decimal.MaxValue),
                    nameof(price));
            }

            if (quantity < 0.001)
            {
                throw new ArgumentException(
                    string.Format(ErrorStrings.ResourceManager.GetString("DigitRangeValuesError"),
                        GetType().GetProperty(nameof(Price)).GetDisplayName(), 0.001, double.MaxValue),
                    nameof(price));
            }

            Name = name;
            Price = price;
            Quantity = quantity;
            Tax = tax ?? throw new ArgumentNullException(nameof(tax));
            PaymentMethod = paymentMethodType;
            PaymentObject = paymentObjectType;
        }

        /// <summary>
        /// Наименование предмета расчета
        /// </summary>
        /// <list type="bullet">
        /// <item>Обязательное поле</item>
        /// </list>
        [Required(ErrorMessageResourceType = typeof(ErrorStrings), ErrorMessageResourceName = "RequiredError")]
        [Display(Name = "Наименование предмета расчета")]
        public string Name { get; }

        /// <summary>
        /// Цена единицы предмета расчета
        /// </summary>
        /// <list type="bullet">
        /// <item>Обязательное поле</item>
        /// <item>Должно лежать в диапазоне: 0-<see cref="decimal.MaxValue"/></item>
        /// </list>
        [Range(0, (double)decimal.MaxValue, ErrorMessageResourceType = typeof(ErrorStrings),
            ErrorMessageResourceName = "DigitRangeValuesError")]
        [Required(ErrorMessageResourceType = typeof(ErrorStrings), ErrorMessageResourceName = "RequiredError")]
        [Display(Name = "Цена единицы предмета расчета")]
        public decimal Price { get; }

        /// <summary>
        /// Количество предмета расчета
        /// </summary>
        /// <list type="bullet">
        /// <item>Обязательное поле</item>
        /// <item>Должно лежать в диапазоне: 0.001-<see cref="double.MaxValue"/></item>
        /// </list>
        [Required(ErrorMessageResourceType = typeof(ErrorStrings), ErrorMessageResourceName = "RequiredError")]
        [Display(Name = "Количество предмета расчета")]
        [Range(0.001, double.MaxValue, ErrorMessageResourceType = typeof(ErrorStrings),
            ErrorMessageResourceName = "DigitRangeValuesError")]
        public double Quantity { get; }

        /// <summary>
        /// Стоимость предмета расчета.
        /// Рассчитывается автоматически как <see cref="Price"/> * <see cref="Quantity"/>
        /// </summary>
        /// <list type="bullet">
        /// <item>Обязательное поле</item>
        /// <item>Должно лежать в диапазоне: 0-<see cref="decimal.MaxValue"/></item>
        /// </list>
        [Required(ErrorMessageResourceType = typeof(ErrorStrings), ErrorMessageResourceName = "RequiredError")]
        [Display(Name = "Стоимость предмета расчета")]
        [Range(0, (double)decimal.MaxValue, ErrorMessageResourceType = typeof(ErrorStrings),
            ErrorMessageResourceName = "DigitRangeValuesError")]
        public decimal Amount => Price * (decimal)Quantity;

        /// <summary>
        /// Информационная скидка
        /// </summary>
        /// <list type="bullet">
        /// <item>Должно лежать в диапазоне: 0-<see cref="decimal.MaxValue"/></item>
        /// </list>
        [Display(Name = "Информационная скидка")]
        [Range(0, (double)decimal.MaxValue, ErrorMessageResourceType = typeof(ErrorStrings),
            ErrorMessageResourceName = "DigitRangeValuesError")]
        public decimal? InfoDiscountAmount { get; set; }

        /// <summary>
        /// Номер отдела (секции)
        /// </summary>
        /// <remarks>
        /// Значение по умолчанию: 1
        /// </remarks>
        [Display(Name = "Номер отдела (секции)")]
        public ushort Department { get; set; } = 1;

        /// <summary>
        /// Единицы измерения кол-ва товара
        /// </summary>
        [Display(Name = "Единицы измерения кол-ва товара")]
        public string MeasurementUnit { get; set; }

        /// <summary>
        /// Штучный товар
        /// </summary>
        [Display(Name = "Штучный товар")]
        public bool Piece { get; set; }

        /// <summary>
        /// Способ расчета
        /// </summary>
        /// <list type="bullet">
        /// <item>Обязательное поле</item>
        /// </list>
        [Display(Name = "Способ расчета")]
        [Required(ErrorMessageResourceType = typeof(ErrorStrings), ErrorMessageResourceName = "RequiredError")]
        public PaymentMethodType PaymentMethod { get; }

        /// <summary>
        /// Тип предмета расчета
        /// </summary>
        /// <list type="bullet">
        /// <item>Обязательное поле</item>
        /// </list>
        [Display(Name = "Тип предмета расчета")]
        [Required(ErrorMessageResourceType = typeof(ErrorStrings), ErrorMessageResourceName = "RequiredError")]
        public PaymentObjectType PaymentObject { get; }

        /// <summary>
        /// Код товара (маркировка)
        /// </summary>
        /// <remarks>
        /// При установке значения параметр <see cref="MarkingCode"/> становится равным null
        /// </remarks>
        [ComplexObjectValidation(ErrorMessageResourceType = typeof(ErrorStrings),
            ErrorMessageResourceName = "ComplexObjectValidationError")]
        [Display(Name = "Код товара (маркировка)")]
        public object NomenclatureCode
        {
            get => _nomenclatureCode;
            set
            {
                _nomenclatureCode = value;
                _markingCode = null;
            }
        }

        /// <summary>
        /// Код маркировки
        /// </summary>
        /// <remarks>
        /// При установке значения параметр <see cref="NomenclatureCode"/> становится равным null
        /// </remarks>
        [ComplexObjectValidation(ErrorMessageResourceType = typeof(ErrorStrings),
            ErrorMessageResourceName = "ComplexObjectValidationError")]
        [Display(Name = "Код маркировки")]
        public MarkingCodeParams MarkingCode
        {
            get => _markingCode;
            set
            {
                _markingCode = value;
                _nomenclatureCode = null;
            }
        }

        /// <summary>
        /// Налог
        /// </summary>
        /// <list type="bullet">
        /// <item>Обязательное поле</item>
        /// </list>
        [ComplexObjectValidation(ErrorMessageResourceType = typeof(ErrorStrings),
            ErrorMessageResourceName = "ComplexObjectValidationError")]
        [Required(ErrorMessageResourceType = typeof(ErrorStrings), ErrorMessageResourceName = "RequiredError")]
        [Display(Name = "Налог")]
        public TaxParams Tax { get; }

        /// <summary>
        /// Данные платежного агента
        /// </summary>
        [ComplexObjectValidation(ErrorMessageResourceType = typeof(ErrorStrings),
            ErrorMessageResourceName = "ComplexObjectValidationError")]
        [Display(Name = "Данные платежного агента")]
        public AgentParams AgentInfo { get; set; }

        /// <summary>
        /// Данные поставщика
        /// </summary>
        [ComplexObjectValidation(ErrorMessageResourceType = typeof(ErrorStrings),
            ErrorMessageResourceName = "ComplexObjectValidationError")]
        [Display(Name = "Данные поставщика")]
        public SupplierParams SupplierInfo { get; set; }

        /// <summary>
        /// Дополнительный реквизит предмета расчета
        /// </summary>
        [Display(Name = "Дополнительный реквизит предмета расчета")]
        public string AdditionalAttribute { get; set; }

        /// <summary>
        /// Печать дополнительного реквизита предмета расчета
        /// </summary>
        /// <remarks>
        /// Значение по умолчанию: true
        /// </remarks>
        [Display(Name = "Печать дополнительного реквизита предмета расчета")]
        public bool AdditionalAttributePrint { get; set; } = true;

        /// <summary>
        /// Сумма акциза, включенная в стоимость предмета расчета
        /// </summary>
        /// <list type="bullet">
        /// <item>Должно лежать в диапазоне: 0.01-<see cref="decimal.MaxValue"/></item>
        /// </list>
        [Display(Name = "Сумма акциза, включенная в стоимость предмета расчета")]
        [Range(0.01, (double)decimal.MaxValue, ErrorMessageResourceType = typeof(ErrorStrings),
            ErrorMessageResourceName = "DigitRangeValuesError")]
        public decimal? ExciseSum { get; set; }

        /// <summary>
        /// Код страны происхождения
        /// </summary>
        /// <list type="bullet">
        /// <item>Должно соответствовать регулярному выражению <see cref="RegexHelper.CountryOfOriginCodePattern"/></item>
        /// </list>
        [RegularExpression(RegexHelper.CountryOfOriginCodePattern, ErrorMessageResourceType = typeof(ErrorStrings),
            ErrorMessageResourceName = "StringFormatError")]
        [Display(Name = "Код страны происхождения")]
        public string CountryCode { get; set; }

        /// <summary>
        /// Регистрационный номер таможенной декларации
        /// </summary>
        [Display(Name = "Регистрационный номер таможенной декларации")]
        public string CustomsDeclaration { get; set; }

        /// <summary>
        /// Значение пользовательского параметра 3
        /// </summary>
        [Display(Name = "Значение пользовательского параметра 3")]
        public int? UserParam3 { get; set; }

        /// <summary>
        /// Значение пользовательского параметра 4
        /// </summary>
        [Display(Name = "Значение пользовательского параметра 4")]
        public int? UserParam4 { get; set; }

        /// <summary>
        /// Значение пользовательского параметра 5
        /// </summary>
        [Display(Name = "Значение пользовательского параметра 5")]
        public int? UserParam5 { get; set; }

        /// <summary>
        /// Значение пользовательского параметра 6
        /// </summary>
        [Display(Name = "Значение пользовательского параметра 6")]
        public int? UserParam6 { get; set; }
    }
}