#region

using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

#endregion

namespace KKTServiceLib.Mercury.Types.Operations.KKT.Service.CloseInactivePorts
{
    [Description("Закрытие неактивных портов")]
    public class CloseInactivePortsOperation: Operation<CloseInactivePortsResult>
    {
        /// <summary>
        /// Закрытие неактивных портов
        /// </summary>
        public CloseInactivePortsOperation(): base("ClosePorts")
        {
            IsSessionKeyRequired = false;
        }

        /// <summary>
        /// Сессионный ключ
        /// </summary>
        [JsonIgnore]
        [Display(Name = "Сессионный ключ")]
        [Required(AllowEmptyStrings = true)]
        public override string SessionKey { get; protected set; } = string.Empty;
    }
}