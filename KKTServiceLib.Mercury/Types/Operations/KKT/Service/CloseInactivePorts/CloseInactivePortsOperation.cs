using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace KKTServiceLib.Mercury.Types.Operations.KKT.Service.CloseInactivePorts
{
    [Description("Закрытие неактивных портов")]
    public class CloseInactivePortsOperation : Operation<CloseInactivePortsResult>
    {
        /// <summary>
        /// Закрытие неактивных портов
        /// </summary>
        public CloseInactivePortsOperation() : base("ClosePorts") { }

        /// <summary>
        /// Сессионный ключ
        /// </summary>
        [JsonIgnore]
        [Display(Name = "Сессионный ключ")]
        public new string SessionKey { get; } = null;
    }
}