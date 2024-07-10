#region

using System.ComponentModel;

#endregion

namespace KKTServiceLib.Atol.Types.Operations.KKT.GetKKTStatus
{
    [Description("Запрос состояния ККТ")]
    public class GetKKTStatusOperation: Operation<GetKKTStatusResult>
    {
        /// <summary>
        /// Запрос состояния ККТ
        /// </summary>
        public GetKKTStatusOperation(): base("getDeviceStatus") { }
    }
}