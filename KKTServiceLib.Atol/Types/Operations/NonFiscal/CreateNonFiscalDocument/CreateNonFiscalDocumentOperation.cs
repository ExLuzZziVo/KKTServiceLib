#region

using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using KKTServiceLib.Atol.Types.Interfaces;
using KKTServiceLib.Shared.Helpers;
using KKTServiceLib.Shared.Resources;
using KKTServiceLib.Shared.Types.ValidationAttributes;

#endregion

namespace KKTServiceLib.Atol.Types.Operations.NonFiscal.CreateNonFiscalDocument
{
    [Description("Создание нефискального документа")]
    public class CreateNonFiscalDocumentOperation : Operation<bool>
    {
        /// <summary>
        /// Создание нефискального документа
        /// </summary>
        /// <param name="items">Элементы документа</param>
        public CreateNonFiscalDocumentOperation(ICommonDocumentElement[] items) : base("nonFiscal")
        {
            if (items?.Any() != true)
            {
                throw new ArgumentException(
                    string.Format(
                        ErrorStrings.ResourceManager.GetString("MinLengthError"),
                        GetType().GetProperty(nameof(Items)).GetDisplayName(), 1),
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
        [ComplexObjectCollectionValidation(AllowNullItems = false, ErrorMessageResourceType = typeof(ErrorStrings),
            ErrorMessageResourceName = "ComplexObjectCollectionValidationError")]
        [MinLength(1, ErrorMessageResourceType = typeof(ErrorStrings), ErrorMessageResourceName = "MinLengthError")]
        [Display(Name = "Элементы документа")]
        [Required(ErrorMessageResourceType = typeof(ErrorStrings), ErrorMessageResourceName = "RequiredError")]
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