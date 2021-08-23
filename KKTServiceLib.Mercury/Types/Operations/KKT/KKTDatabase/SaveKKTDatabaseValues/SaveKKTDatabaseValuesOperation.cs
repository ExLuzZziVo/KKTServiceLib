using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using KKTServiceLib.Mercury.Types.Common;
using KKTServiceLib.Shared.Resources;
using KKTServiceLib.Shared.Types.ValidationAttributes;

namespace KKTServiceLib.Mercury.Types.Operations.KKT.KKTDatabase.SaveKKTDatabaseValues
{
    [Description("Запись товаров в базу данных ККТ")]
    public class SaveKKTDatabaseValuesOperation : Operation<SaveKKTDatabaseValuesResult>
    {
        /// <summary>
        /// Запись товаров в базу данных ККТ
        /// </summary>
        public SaveKKTDatabaseValuesOperation() : base("WriteGoodsBase")
        {
        }

        /// <summary>
        /// Товары
        /// </summary>
        /// <list type="bullet">
        /// <item>Обязательное поле</item>
        /// <item>Минимальное кол-во элементов: 1</item>
        /// </list>
        [Display(Name = "Товары")]
        [Required(ErrorMessageResourceType = typeof(ErrorStrings), ErrorMessageResourceName = "RequiredError")]
        [ComplexObjectCollectionValidation(AllowNullItems = false, ErrorMessageResourceType = typeof(ErrorStrings),
            ErrorMessageResourceName = "ComplexObjectCollectionValidationError")]
        [MinLength(1, ErrorMessageResourceType = typeof(ErrorStrings), ErrorMessageResourceName = "MinLengthError")]
        public ICollection<Product> Base { get; } = new List<Product>();
    }
}