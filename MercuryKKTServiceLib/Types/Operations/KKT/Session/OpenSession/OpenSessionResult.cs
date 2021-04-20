using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace MercuryKKTServiceLib.Types.Operations.KKT.Session.OpenSession
{
    [Description("Результат открытия сессии")]
    public class OpenSessionResult : OperationResult
    {
        /// <summary>
        /// Сессионный ключ
        /// </summary>
        [Display(Name = "Сессионный ключ")]
        public string SessionKey { get; set; }

        /// <summary>
        /// Версия протокола взаимодействия с драйвером
        /// </summary>
        [Display(Name = "Версия протокола взаимодействия с драйвером")]
        public string ProtocolVer { get; set; }
    }
}