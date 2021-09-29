using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace KKTServiceLib.Mercury.Types.Operations.KKT.Service.GetDriverInfo
{
    [Description("Получение информации о драйвере ККТ")]
    public class GetDriverInfoOperation : Operation<GetDriverInfoResult>
    {
        public GetDriverInfoOperation() : base("GetDriverInfo") { }

        /// <summary>
        /// Сессионный ключ
        /// </summary>
        [JsonIgnore]
        [Display(Name = "Сессионный ключ")]
        public new string SessionKey { get; } = null;
    }
}