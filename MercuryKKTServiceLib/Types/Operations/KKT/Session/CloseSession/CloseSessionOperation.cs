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
        public CloseSessionOperation(string sessionKey) : base("CloseSession") { }
    }
}