using System.ComponentModel;

namespace MercuryKKTServiceLib.Types.Operations.KKT.GetKKTInfo
{
    [Description("Запрос информации о ККТ")]
    public class GetKKTInfoOperation : Operation<GetKKTInfoOperationResult>
    {
        /// <summary>
        /// Запрос информации о ККТ
        /// </summary>
        public GetKKTInfoOperation() : base("GetCommonInfo")
        {
        }
    }
}