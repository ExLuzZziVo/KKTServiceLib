#region

using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

#endregion

namespace KKTServiceLib.Mercury.Types.Operations.Fiscal.TSPIOT.SetChallenge
{
    [Description("Результат подготовки данных аутентификации ТС ПИоТ")]
    public class SetChallengeResult: OperationResult
    {
        /// <summary>
        /// Полученное от ККТ значение, которое необходимо передать серверу ГИС МТ в ключе «val» при выполнении запроса «req_chk_chlg»
        /// </summary>
        /// <remarks>
        /// Сформированное значение уже представлено в кодировке Base64 и содержит данные подготовленные ФН, а также включает заголовок сеансового уровня «t_hdr» в соответствии с описанием протоколов обмена ТС ПИоТ и ГИС МТ
        /// </remarks>
        [Display(Name =
            "Полученное от ККТ значение, которое необходимо передать серверу ГИС МТ в ключе «val» при выполнении запроса «req_chk_chlg»")]
        [JsonPropertyName("req_chk_chlg_val")]
        public string Value { get; set; }
    }
}
