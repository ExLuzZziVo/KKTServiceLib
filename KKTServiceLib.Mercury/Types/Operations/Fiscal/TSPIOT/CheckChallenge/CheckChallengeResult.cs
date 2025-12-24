#region

using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

#endregion

namespace KKTServiceLib.Mercury.Types.Operations.Fiscal.TSPIOT.CheckChallenge
{
    [Description("Результат извлечения токена аутентификации")]
    public class CheckChallengeResult: OperationResult
    {
        /// <summary>
        /// ASCII строка, содержащая аутентификационный токен, который должен передаваться в заголовке «X-FN-SID» каждого HTTP-запроса, отправляемого ТС ПИоТ серверу ГИС МТ
        /// </summary>
        [Display(Name =
            "ASCII строка, содержащая аутентификационный токен, который должен передаваться в заголовке «X-FN-SID» каждого HTTP-запроса, отправляемого ТС ПИоТ серверу ГИС МТ")]
        [JsonPropertyName("x_fn_sid")]
        public string Token { get; set; }
    }
}
