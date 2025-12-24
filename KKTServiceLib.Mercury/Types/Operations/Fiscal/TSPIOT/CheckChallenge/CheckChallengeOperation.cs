#region

using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using CoreLib.CORE.Helpers.ObjectHelpers;
using CoreLib.CORE.Helpers.StringHelpers;
using CoreLib.CORE.Resources;

#endregion

namespace KKTServiceLib.Mercury.Types.Operations.Fiscal.TSPIOT.CheckChallenge
{
    [Description("Извлечение токена аутентификации")]
    public class CheckChallengeOperation: Operation<CheckChallengeResult>
    {
        /// <summary>
        /// Извлечение токена аутентификации
        /// </summary>
        /// <param name="value">Значение ключа «val», полученное ТС ПИоТ от ГИС МТ в ответе на запрос «req_chk_chlg»</param>
        public CheckChallengeOperation(string value): base("TSPIOTCheckChallenge")
        {
            if (value.IsNullOrEmptyOrWhiteSpace())
            {
                throw new ArgumentException(
                    string.Format(
                        ValidationStrings.ResourceManager.GetString("StringFormatError"),
                        GetType().GetProperty(nameof(Value)).GetPropertyDisplayName()),
                    nameof(value));
            }

            Value = value;
        }

        /// <summary>
        /// Значение ключа «val», полученное ТС ПИоТ от ГИС МТ в ответе на запрос «req_chk_chlg»
        /// </summary>
        /// <remarks>
        /// Полученное от сервера ГИС МТ значение передается в команду без каких-либо изменений
        /// </remarks>
        /// <list type="bullet">
        /// <item>Обязательное поле</item>
        /// </list>
        [Display(Name = "Значение ключа «val», полученное ТС ПИоТ от ГИС МТ в ответе на запрос «req_chk_chlg»")]
        [JsonPropertyName("rsp_chk_chlg_val")]
        [Required(ErrorMessageResourceType = typeof(ValidationStrings), ErrorMessageResourceName = "RequiredError")]
        public string Value { get; }
    }
}
