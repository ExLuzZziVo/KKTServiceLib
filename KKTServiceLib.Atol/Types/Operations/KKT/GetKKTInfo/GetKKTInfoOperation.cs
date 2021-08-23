#region

using System.ComponentModel;

#endregion

namespace KKTServiceLib.Atol.Types.Operations.KKT.GetKKTInfo
{
    [Description("Запрос информации о ККТ")]
    public class GetKKTInfoOperation : Operation<GetKKTInfoResult>
    {
        /// <summary>
        /// Запрос информации о ККТ
        /// </summary>
        public GetKKTInfoOperation() : base("getDeviceInfo")
        {
        }
    }
}