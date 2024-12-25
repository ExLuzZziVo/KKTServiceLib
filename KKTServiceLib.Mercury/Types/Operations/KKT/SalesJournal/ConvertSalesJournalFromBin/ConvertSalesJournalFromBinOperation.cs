#region

using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using CoreLib.CORE.Helpers.ObjectHelpers;
using CoreLib.CORE.Helpers.StringHelpers;
using CoreLib.CORE.Resources;

#endregion

namespace KKTServiceLib.Mercury.Types.Operations.KKT.SalesJournal.ConvertSalesJournalFromBin
{
    [Description("Конвертация журнала продаж из внутреннего формата ККТ")]
    public class ConvertSalesJournalFromBinOperation: Operation<ConvertSalesJournalFromBinResult>
    {
        /// <summary>
        /// Конвертация журнала продаж из внутреннего формата ККТ
        /// </summary>
        /// <param name="base64Content">Журнал продаж ККТ в base64</param>
        public ConvertSalesJournalFromBinOperation(string base64Content): base("ConvertSalesFromBin")
        {
            if (base64Content.IsNullOrEmptyOrWhiteSpace())
            {
                throw new ArgumentException(
                    string.Format(
                        ValidationStrings.ResourceManager.GetString("StringFormatError"),
                        GetType().GetProperty(nameof(Base)).GetPropertyDisplayName()),
                    nameof(base64Content));
            }

            Base = base64Content;
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
        /// Журнал продаж ККТ в base64
        /// </summary>
        /// <list type="bullet">
        /// <item>Обязательное поле</item>
        /// </list>
        [Required(ErrorMessageResourceType = typeof(ValidationStrings), ErrorMessageResourceName = "RequiredError")]
        [Display(Name = "Журнал продаж ККТ в base64")]
        public string Base { get; }
    }
}