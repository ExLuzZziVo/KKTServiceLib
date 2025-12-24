#region

using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

#endregion

namespace KKTServiceLib.Mercury.Types.Operations.Fiscal.TSPIOT.SetDKMsg
{
    [Description(
        "Результат подготовки ТС ПИоТ защищённой части сообщения перед отправкой запроса ГИС МТ в режиме защищённого обмена сообщениями")]
    public class SetDecryptedMessageResult: OperationResult
    {
        /// <summary>
        /// Полученное от ККТ значение, которое необходимо передать серверу ГИС МТ в ключе «dk_ctrl» при выполнении запроса «req_dks»
        /// </summary>
        /// <remarks>
        /// Сформированное значение уже представлено в кодировке Base64 и содержит данные подготовленные ФН, а также включает заголовок сеансового уровня «t_hdr» в соответствии с описанием протоколов обмена ТС ПИоТ и ГИС МТ
        /// </remarks>
        [Display(Name =
            "Полученное от ККТ значение, которое необходимо передать серверу ГИС МТ в ключе «dk_ctrl» при выполнении запроса «req_dks»")]
        [JsonPropertyName("dk_ctrl")]
        public string Value { get; set; }
    }
}
