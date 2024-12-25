#region

using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using KKTServiceLib.Mercury.Types.Common;
using KKTServiceLib.Mercury.Types.Converters;
using KKTServiceLib.Mercury.Types.Enums;

#endregion

namespace KKTServiceLib.Mercury.Types.Operations.KKT.SalesJournal.GetSalesJournal
{
    [Description("Информация о предмете расчета")]
    public class JournalReceiptPosition
    {
        [Display(Name = "Код товара")] public uint? Code { get; set; }

        /// <summary>
        /// Наименование предмета расчета
        /// </summary>
        [Display(Name = "Наименование предмета расчета")]
        public string ProductName { get; set; }

        /// <summary>
        /// Количество предмета расчета
        /// </summary>
        [Display(Name = "Количество предмета расчета")]
        [JsonConverter(typeof(QuantityConverter))]
        public double Qty { get; set; }

        /// <summary>
        /// Мера количества товара
        /// </summary>
        [Display(Name = "Мера количества товара")]
        public ItemUnitType? MeasureUnit { get; set; }

        /// <summary>
        /// Номер отдела (секции)
        /// </summary>
        [Display(Name = "Номер отдела (секции)")]
        public ushort Section { get; set; }

        /// <summary>
        /// Налоговая ставка
        /// </summary>
        [Display(Name = "Налоговая ставка")]
        public WatType TaxCode { get; set; }

        /// <summary>
        /// Цена единицы предмета расчета
        /// </summary>
        [Display(Name = "Цена единицы предмета расчета")]
        [JsonConverter(typeof(MoneyConverter))]
        public decimal Price { get; set; }

        /// <summary>
        /// Признак предмета расчета
        /// </summary>
        [Display(Name = "Признак предмета расчета")]
        public PaymentObjectType TypeCode { get; set; }

        /// <summary>
        /// Способ расчета
        /// </summary>
        [Display(Name = "Способ расчета")]
        public PaymentMethodType PaymentFormCode { get; set; }

        /// <summary>
        /// Сумма налога
        /// </summary>
        [Display(Name = "Сумма налога")]
        [JsonConverter(typeof(MoneyConverter))]
        public decimal? TaxSum { get; set; }

        /// <summary>
        /// Стоимость предмета расчета
        /// </summary>
        [Display(Name = "Стоимость предмета расчета")]
        [JsonConverter(typeof(MoneyConverter))]
        public decimal Sum { get; set; }

        /// <summary>
        /// Сумма акциза, включенная в стоимость предмета расчета
        /// </summary>
        [Display(Name = "Сумма акциза, включенная в стоимость предмета расчета")]
        [JsonConverter(typeof(MoneyConverter))]
        public decimal? ExciseAmount { get; set; }

        /// <summary>
        /// Регистрационный номер таможенной декларации
        /// </summary>
        [Display(Name = "Регистрационный номер таможенной декларации")]
        public string CustomsDeclaration { get; set; }

        /// <summary>
        /// Код страны происхождения
        /// </summary>
        [Display(Name = "Код страны происхождения")]
        public string CountryOfOrigin { get; set; }

        /// <summary>
        /// Отраслевой реквизит
        /// </summary>
        [Display(Name = "Отраслевой реквизит")]
        public IndustryRequisiteParams[] IndustryAttribute { get; set; }

        /// <summary>
        /// Информация о маркированном товаре
        /// </summary>
        [Display(Name = "Информация о маркированном товаре")]
        public JournalMarkingCodeInfo McInfo { get; set; }
    }
}