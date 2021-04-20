using System;
using System.ComponentModel;
using KKTServiceLib.Shared.Helpers;
using KKTServiceLib.Shared.Resources;

namespace MercuryKKTServiceLib.Types.Operations.KKT.Session.CloseSession
{
    [Description("Закрытие сессии")]
    public class CloseSessionOperation : Operation<CloseSessionResult>
    {
        /// <summary>
        /// Закрытие сессии
        /// </summary>
        /// <param name="sessionKey">Сессионный ключ</param>
        public CloseSessionOperation(string sessionKey) : base("CloseSession")
        {
            if (sessionKey.IsNullOrEmptyOrWhiteSpace())
            {
                throw new ArgumentException(
                    string.Format(
                        ErrorStrings.ResourceManager.GetString("StringFormatError"),
                        this.GetType().GetProperty(nameof(SessionKey)).GetDisplayName()),
                    nameof(sessionKey));
            }
            
            SessionKey = sessionKey;
        }
    }
}