using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using KKTServiceLib.Mercury.Types.Common;
using KKTServiceLib.Mercury.Types.Enums;
using KKTServiceLib.Shared.Resources;
using KKTServiceLib.Shared.Types.ValidationAttributes;
using Newtonsoft.Json;

namespace KKTServiceLib.Mercury.Types.Operations.KKT.KKTDatabase.ConvertKKTDatabaseToBin
{
    [Description("Конвертация базы товаров во внутренний формат ККТ")]
    public class ConvertKKTDatabaseToBinOperation : Operation<ConvertKKTDatabaseToBinResult>
    {
        /// <summary>
        /// Конвертация базы товаров во внутренний формат ККТ
        /// </summary>
        /// <param name="kktDatabaseVersion">Версия внутренней базы товаров ККТ</param>
        public ConvertKKTDatabaseToBinOperation(KKTDatabaseVersion kktDatabaseVersion) : base("ConvertBaseToBin")
        {
            BaseVer = kktDatabaseVersion;
        }

        /// <summary>
        /// Сессионный ключ
        /// </summary>
        [JsonIgnore]
        [Display(Name = "Сессионный ключ")]
        public new string SessionKey { get; } = null;

        /// <summary>
        /// Версия внутренней базы товаров ККТ
        /// </summary>
        /// <list type="bullet">
        /// <item>Обязательное поле</item>
        /// </list>
        [Required(ErrorMessageResourceType = typeof(ErrorStrings), ErrorMessageResourceName = "RequiredError")]
        [Display(Name = "Версия внутренней базы товаров ККТ")]
        public KKTDatabaseVersion BaseVer { get; }

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