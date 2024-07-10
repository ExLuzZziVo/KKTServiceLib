#region

using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using CoreLib.CORE.Helpers.ObjectHelpers;
using CoreLib.CORE.Helpers.ValidationHelpers.Attributes;
using CoreLib.CORE.Resources;
using KKTServiceLib.Atol.Types.Interfaces;

#endregion

namespace KKTServiceLib.Atol.Types.Operations.NonFiscal.CreateNonFiscalDocument
{
    [Description("Создание нефискального документа")]
    public class CreateNonFiscalDocumentOperation: Operation<bool>
    {
        /// <summary>
        /// Создание нефискального документа
        /// </summary>
        /// <param name="items">Элементы документа</param>
        public CreateNonFiscalDocumentOperation(ICommonDocumentElement[] items): base("nonFiscal")
        {
            if (items?.Any() != true)
            {
                throw new ArgumentException(
                    string.Format(
                        ValidationStrings.ResourceManager.GetString("CollectionMinLengthError"),
                        GetType().GetProperty(nameof(Items)).GetPropertyDisplayName(), 1),
                    nameof(items));
            }

            Items = items;
        }

        /// <summary>
        /// Элементы документа
        /// </summary>
        /// <list type="bullet">
        /// <item>Обязательное поле</item>
        /// <item>Минимальное кол-во элементов: 1</item>
        /// </list>
        [ComplexObjectCollectionValidation(AllowNullItems = false, ErrorMessageResourceType = typeof(ValidationStrings),
            ErrorMessageResourceName = "ComplexObjectCollectionValidationError")]
        [MinLength(1, ErrorMessageResourceType = typeof(ValidationStrings),
            ErrorMessageResourceName = "CollectionMinLengthError")]
        [Display(Name = "Элементы документа")]
        [Required(ErrorMessageResourceType = typeof(ValidationStrings), ErrorMessageResourceName = "RequiredError")]
        public ICommonDocumentElement[] Items { get; }

        /// <summary>
        /// Флаг печати подвала документа
        /// </summary>
        /// <remarks>
        /// Значение по умолчанию: true
        /// </remarks>
        [Display(Name = "Флаг печати подвала документа")]
        public bool PrintFooter { get; set; } = true;
    }
}