#region

using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using CoreLib.CORE.Helpers.ValidationHelpers.Attributes;
using CoreLib.CORE.Resources;
using KKTServiceLib.Mercury.Types.Common;
using KKTServiceLib.Mercury.Types.Enums;

#endregion

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
            IsSessionKeyRequired = false;
        }

        /// <summary>
        /// Сессионный ключ
        /// </summary>
        [JsonIgnore]
        [Display(Name = "Сессионный ключ")]
        [Required(AllowEmptyStrings = true)]
        public override string SessionKey { get; protected set; } = string.Empty;

        /// <summary>
        /// Версия внутренней базы товаров ККТ
        /// </summary>
        /// <list type="bullet">
        /// <item>Обязательное поле</item>
        /// </list>
        [Required(ErrorMessageResourceType = typeof(ValidationStrings), ErrorMessageResourceName = "RequiredError")]
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
        [Required(ErrorMessageResourceType = typeof(ValidationStrings), ErrorMessageResourceName = "RequiredError")]
        [ComplexObjectCollectionValidation(AllowNullItems = false, ErrorMessageResourceType = typeof(ValidationStrings),
            ErrorMessageResourceName = "ComplexObjectCollectionValidationError")]
        [MinLength(1, ErrorMessageResourceType = typeof(ValidationStrings),
            ErrorMessageResourceName = "CollectionMinLengthError")]
        public ICollection<Product> Base { get; } = new List<Product>();
    }
}