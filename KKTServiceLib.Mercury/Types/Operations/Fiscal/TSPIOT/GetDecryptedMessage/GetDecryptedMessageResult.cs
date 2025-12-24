#region

using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

#endregion

namespace KKTServiceLib.Mercury.Types.Operations.Fiscal.TSPIOT.GetDecryptedMessage
{
    [Description(
        "Результат расшифровки защищённой части сообщения, полученного от ГИС МТ в ответ на запрос ТС ПИоТ в режиме защищённого обмена сообщениями")]
    public class GetDecryptedMessageResult: OperationResult
    {
        /// <summary>
        /// Извлечённое значение защищенной части сообщения «dk_msg1», представленное в кодировке Base64
        /// </summary>
        [Display(Name =
            "Извлечённое значение защищенной части сообщения «dk_msg1», представленное в кодировке Base64")]
        [JsonPropertyName("dk_msg1")]
        public string Message { get; set; }

        /// <summary>
        /// Извлечённое значение криптографической соли (массива случайных байтов), использованной при вычислении хэша полного сообщения «dk_msg», представленное в кодировке Base64
        /// </summary>
        [Display(Name =
            "Извлечённое значение криптографической соли (массива случайных байтов), использованной при вычислении хэша полного сообщения «dk_msg», представленное в кодировке Base64")]
        [JsonPropertyName("rand_ar")]
        public string Salt { get; set; }

        /// <summary>
        /// Извлечённый хэш, рассчитанный по алгоритму SHA-256 от полного сообщения «dk_msg» с использованием соли «rand_ar» и представленный в кодировке Base64
        /// </summary>
        [Display(Name =
            "Извлечённый хэш, рассчитанный по алгоритму SHA-256 от полного сообщения «dk_msg» с использованием соли «rand_ar» и представленный в кодировке Base64")]
        [JsonPropertyName("hash")]
        public string Hash { get; set; }
    }
}
