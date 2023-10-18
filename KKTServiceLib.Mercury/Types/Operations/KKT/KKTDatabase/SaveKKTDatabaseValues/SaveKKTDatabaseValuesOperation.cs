#region

using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using CoreLib.CORE.Helpers.ValidationHelpers.Attributes;
using CoreLib.CORE.Resources;
using KKTServiceLib.Mercury.Types.Common;

#endregion

namespace KKTServiceLib.Mercury.Types.Operations.KKT.KKTDatabase.SaveKKTDatabaseValues
{
    [Description("Запись товаров в базу данных ККТ")]
    public class SaveKKTDatabaseValuesOperation : Operation<SaveKKTDatabaseValuesResult>
    {
        /// <summary>
        /// Запись товаров в базу данных ККТ
        /// </summary>
        public SaveKKTDatabaseValuesOperation() : base("WriteGoodsBase") { }

        /// <summary>
        /// Товары
        /// </summary>
        /// <list type="bullet">
        /// <item>Обязательное поле</item>
        /// <item>Минимальное кол-во элементов: 1</item>
        /// </list>
        [Display(Name = "Товары")]
        [Required(ErrorMessageResourceType = typeof(ValidationStrings), ErrorMessageResourceName = "RequiredError")]
        [ComplexObjectCollectionValidation(AllowNullItems = false, ErrorMessageResourceType = typeof(ValidationStrings),
            ErrorMessageResourceName = "ComplexObjectCollectionValidationError")]
        [MinLength(1, ErrorMessageResourceType = typeof(ValidationStrings),
            ErrorMessageResourceName = "CollectionMinLengthError")]
        public ICollection<Product> Base { get; } = new List<Product>();
    }
}