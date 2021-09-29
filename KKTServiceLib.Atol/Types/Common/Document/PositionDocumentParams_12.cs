using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using KKTServiceLib.Atol.Types.Common.MarkingCodes;
using KKTServiceLib.Atol.Types.Enums;
using KKTServiceLib.Shared.Resources;
using KKTServiceLib.Shared.Types.ValidationAttributes;
using Newtonsoft.Json;

namespace KKTServiceLib.Atol.Types.Common.Document
{
    [Description("Предмет расчета (ФФД ≥ 1.2)")]
    public class PositionDocumentParams_12 : PositionDocumentParams
    {
        private MarkingCodeParams_12 _imcParams;

        /// <summary>
        /// Предмет расчета (ФФД ≥ 1.2)
        /// </summary>
        /// <param name="name">Наименование</param>
        /// <param name="price">Цена единицы</param>
        /// <param name="quantity">Количество</param>
        /// <param name="itemUnitType">Единицы измерения кол-ва товара</param>
        /// <param name="tax">Налог</param>
        /// <param name="paymentMethodType">Способ расчета</param>
        /// <param name="paymentObjectType">Тип предмета расчета</param>
        public PositionDocumentParams_12(string name, decimal price, double quantity, ItemUnitType itemUnitType,
            TaxParams tax, PaymentMethodType paymentMethodType, PaymentObjectType paymentObjectType) : base(name, price,
            quantity, tax, paymentMethodType, paymentObjectType)
        {
            MeasurementUnit = itemUnitType;
        }

        /// <summary>
        /// Единицы измерения кол-ва товара
        /// </summary>
        /// <list type="bullet">
        /// <item>Обязательное поле</item>
        /// </list>
        [Display(Name = "Единицы измерения кол-ва товара")]
        public new ItemUnitType MeasurementUnit { get; }

        /// <summary>
        /// Код маркировки
        /// </summary>
        /// <remarks>
        /// В ФФД 1.2 не используется
        /// </remarks>
        [Display(Name = "Код маркировки")]
        [JsonIgnore]
        public new MarkingCodeParams MarkingCode => null;

        /// <summary>
        /// Код товара (маркировка)
        /// </summary>
        /// <remarks>
        /// При установке значения параметр <see cref="ImcParams"/> становится равным null
        /// </remarks>
        [Display(Name = "Код товара (маркировка)")]
        [ComplexObjectValidation(ErrorMessageResourceType = typeof(ErrorStrings),
            ErrorMessageResourceName = "ComplexObjectValidationError")]
        public new object NomenclatureCode
        {
            get => _nomenclatureCode;
            set
            {
                _nomenclatureCode = value;
                _imcParams = null;
            }
        }

        /// <summary>
        /// Код маркировки
        /// </summary>
        /// <remarks>
        /// При установке значения параметр <see cref="NomenclatureCode"/> становится равным null
        /// </remarks>
        [Display(Name = "Код маркировки")]
        [ComplexObjectValidation(ErrorMessageResourceType = typeof(ErrorStrings),
            ErrorMessageResourceName = "ComplexObjectValidationError")]
        public MarkingCodeParams_12 ImcParams
        {
            get => _imcParams;
            set
            {
                _imcParams = value;
                _nomenclatureCode = null;
            }
        }

        /// <summary>
        /// Отраслевой реквизит
        /// </summary>
        [Display(Name = "Отраслевой реквизит")]
        [ComplexObjectCollectionValidation(AllowNullItems = false, ErrorMessageResourceType = typeof(ErrorStrings),
            ErrorMessageResourceName = "ComplexObjectCollectionValidationError")]
        public IndustryRequisiteParams[] IndustryInfo { get; set; }

        /// <summary>
        /// Коды товара
        /// </summary>
        [Display(Name = "Коды товара")]
        [ComplexObjectValidation(ErrorMessageResourceType = typeof(ErrorStrings),
            ErrorMessageResourceName = "ComplexObjectValidationError")]
        public PositionCodesParams ProductCodes { get; set; }
    }
}