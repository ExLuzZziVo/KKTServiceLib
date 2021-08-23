using System.ComponentModel;

namespace KKTServiceLib.Mercury.Types.Operations.KKT.Session.CloseSession
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