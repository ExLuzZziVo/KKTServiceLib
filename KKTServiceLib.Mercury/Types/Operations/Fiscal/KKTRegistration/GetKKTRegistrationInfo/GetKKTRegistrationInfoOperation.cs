#region

using System.ComponentModel;

#endregion

namespace KKTServiceLib.Mercury.Types.Operations.Fiscal.KKTRegistration.GetKKTRegistrationInfo
{
    [Description("Запрос параметров регистрации ККТ")]
    public class GetKKTRegistrationInfoOperation : Operation<GetKKTRegistrationInfoResult>
    {
        /// <summary>
        /// Запрос параметров регистрации ККТ
        /// </summary>
        public GetKKTRegistrationInfoOperation() : base("GetRegistrationInfo") { }
    }
}