#region

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using System.Text.RegularExpressions;
using CoreLib.CORE.Helpers.ObjectHelpers;
using CoreLib.CORE.Helpers.StringHelpers;
using CoreLib.CORE.Resources;

#endregion

namespace KKTServiceLib.Mercury.Types.Operations.Fiscal.TSPIOT.SetDKMsg
{
    [Description(
        "Подготовка ТС ПИоТ защищённой части сообщения перед отправкой запроса ГИС МТ в режиме защищённого обмена сообщениями")]
    public class SetDecryptedMessageOperation: Operation<SetDecryptedMessageResult>
    {
        /// <summary>
        /// Подготовка ТС ПИоТ защищённой части сообщения перед отправкой запроса ГИС МТ в режиме защищённого обмена сообщениями
        /// </summary>
        /// <param name="message">Массив из 269 байтов, представленный в кодировке Base64</param>
        /// <param name="hash">Хэш, рассчитанный по алгоритму SHA-256 от полного сообщения «dk_msg» и представленный в кодировке Base64</param>
        public SetDecryptedMessageOperation(string message, string hash): base("TSPIOTSetDKMsg")
        {
            if (message.IsNullOrEmptyOrWhiteSpace() || !Regex.IsMatch(message, RegexExtensions.Base64Pattern) ||
                Convert.FromBase64String(message).Length != 269)
            {
                throw new ArgumentException(
                    string.Format(
                        ValidationStrings.ResourceManager.GetString("StringFormatError"),
                        GetType().GetProperty(nameof(Message)).GetPropertyDisplayName()),
                    nameof(Message));
            }

            if (hash.IsNullOrEmptyOrWhiteSpace() || !Regex.IsMatch(hash, RegexExtensions.Base64Pattern) ||
                hash.Length != 44)
            {
                throw new ArgumentException(
                    string.Format(
                        ValidationStrings.ResourceManager.GetString("StringFormatError"),
                        GetType().GetProperty(nameof(Hash)).GetPropertyDisplayName()),
                    nameof(Hash));
            }

            Message = message;
            Hash = hash;
        }

        /// <summary>
        /// Массив из 269 байтов, представленный в кодировке Base64
        /// </summary>
        /// <remarks>
        /// Если длина сообщения меньше 269 байтов, то массив должен быть дополнен нулями до указанной длины
        /// </remarks>
        /// <list type="bullet">
        /// <item>Обязательное поле</item>
        /// <item>Должно иметь размер 269 байтов</item>
        /// <item>Должно соответствовать регулярному выражению <see cref="RegexExtensions.Base64Pattern"/></item>
        /// </list>
        [Display(Name = "Массив из 269 байтов, представленный в кодировке Base64")]
        [JsonPropertyName("dk_msg1")]
        [Required(ErrorMessageResourceType = typeof(ValidationStrings), ErrorMessageResourceName = "RequiredError")]
        [RegularExpression(RegexExtensions.Base64Pattern, ErrorMessageResourceType = typeof(ValidationStrings),
            ErrorMessageResourceName = "StringFormatError")]
        public string Message { get; }

        /// <summary>
        /// Хэш, рассчитанный по алгоритму SHA-256 от полного сообщения «dk_msg» и представленный в кодировке Base64
        /// </summary>
        /// <list type="bullet">
        /// <item>Обязательное поле</item>
        /// <item>Должно иметь длину: 44</item>
        /// <item>Должно соответствовать регулярному выражению <see cref="RegexExtensions.Base64Pattern"/></item>
        /// </list>
        [Display(Name =
            "Хэш, рассчитанный по алгоритму SHA-256 от полного сообщения «dk_msg» и представленный в кодировке Base64")]
        [Required(ErrorMessageResourceType = typeof(ValidationStrings), ErrorMessageResourceName = "RequiredError")]
        [StringLength(44, MinimumLength = 44, ErrorMessageResourceType = typeof(ValidationStrings),
            ErrorMessageResourceName = "StringLengthError")]
        [RegularExpression(RegexExtensions.Base64Pattern, ErrorMessageResourceType = typeof(ValidationStrings),
            ErrorMessageResourceName = "StringFormatError")]
        public string Hash { get; }

        public override IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (!Message.IsNullOrEmptyOrWhiteSpace())
            {
                if (Convert.FromBase64String(Message).Length != 269)
                {
                    yield return new ValidationResult(string.Format(
                            ValidationStrings.ResourceManager.GetString("StringSizeError"),
                            GetType().GetProperty(nameof(Message)).GetPropertyDisplayName()),
                        new[] { nameof(Message) });
                }
            }
        }
    }
}
