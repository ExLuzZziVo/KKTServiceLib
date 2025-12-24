#region

using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using System.Text.RegularExpressions;
using CoreLib.CORE.Helpers.ObjectHelpers;
using CoreLib.CORE.Helpers.StringHelpers;
using CoreLib.CORE.Resources;

#endregion

namespace KKTServiceLib.Mercury.Types.Operations.Fiscal.TSPIOT.GetDecryptedMessage
{
    [Description(
        "Расшифровка защищённой части сообщения, полученного от ГИС МТ в ответ на запрос ТС ПИоТ в режиме защищённого обмена сообщениями")]
    public class GetDecryptedMessageOperation: Operation<GetDecryptedMessageResult>
    {
        /// <summary>
        /// Расшифровка защищённой части сообщения, полученного от ГИС МТ в ответ на запрос ТС ПИоТ в режиме защищённого обмена сообщениями
        /// </summary>
        /// <param name="value">Контейнер, содержащий защищённую часть сообщения, полученный ТС ПИоТ от сервера ГИС МТ в ответе на запрос «req_dks»</param>
        public GetDecryptedMessageOperation(string value): base("TSPIOTGetDKMsg")
        {
            if (value.IsNullOrEmptyOrWhiteSpace() || !Regex.IsMatch(value, RegexExtensions.Base64Pattern))
            {
                throw new ArgumentException(
                    string.Format(
                        ValidationStrings.ResourceManager.GetString("StringFormatError"),
                        GetType().GetProperty(nameof(Value)).GetPropertyDisplayName()),
                    nameof(Value));
            }

            Value = value;
        }

        /// <summary>
        /// Контейнер, содержащий защищённую часть сообщения, полученный ТС ПИоТ от сервера ГИС МТ в ответе на запрос «req_dks»
        /// </summary>
        /// <remarks>
        /// Полученное от сервера ГИС МТ значение передается в команду без каких-либо изменений
        /// </remarks>
        /// <list type="bullet">
        /// <item>Обязательное поле</item>
        /// <item>Должно соответствовать регулярному выражению <see cref="RegexExtensions.Base64Pattern"/></item>
        /// </list>
        [Display(Name = "Значение ключа «val», полученное ТС ПИоТ от ГИС МТ в ответе на запрос «req_chk_chlg»")]
        [JsonPropertyName("dk_ctrl")]
        [Required(ErrorMessageResourceType = typeof(ValidationStrings), ErrorMessageResourceName = "RequiredError")]
        [RegularExpression(RegexExtensions.Base64Pattern, ErrorMessageResourceType = typeof(ValidationStrings),
            ErrorMessageResourceName = "StringFormatError")]
        public string Value { get; }
    }
}