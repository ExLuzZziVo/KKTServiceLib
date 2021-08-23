using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using KKTServiceLib.Shared.Helpers;
using KKTServiceLib.Shared.Resources;
using Newtonsoft.Json;

namespace KKTServiceLib.Mercury.Types.Operations.KKT.KKTDatabase.ConvertKKTDatabaseFromBin
{
    [Description("Конвертация базы товаров из внутреннего формата ККТ")]
    public class ConvertKKTDatabaseFromBinOperation : Operation<ConvertKKTDatabaseFromBinResult>
    {
        /// <summary>
        /// Конвертация базы товаров из внутреннего формата ККТ
        /// </summary>
        /// <param name="base64Content">База товаров ККТ в base64</param>
        public ConvertKKTDatabaseFromBinOperation(string base64Content) : base("ConvertBaseFromBin")
        {
            if (base64Content.IsNullOrEmptyOrWhiteSpace())
            {
                throw new ArgumentException(
                    string.Format(
                        ErrorStrings.ResourceManager.GetString("StringFormatError"),
                        this.GetType().GetProperty(nameof(Base)).GetDisplayName()),
                    nameof(base64Content));
            }

            Base = base64Content;
        }

        /// <summary>
        /// Сессионный ключ
        /// </summary>
        [JsonIgnore]
        [Display(Name = "Сессионный ключ")]
        public new string SessionKey { get; } = null;

        /// <summary>
        /// База товаров ККТ в base64
        /// </summary>
        /// <list type="bullet">
        /// <item>Обязательное поле</item>
        /// </list>
        [Required(ErrorMessageResourceType = typeof(ErrorStrings), ErrorMessageResourceName = "RequiredError")]
        [Display(Name = "База товаров ККТ в base64")]
        public string Base { get; }
    }
}