#region

using System.ComponentModel;

#endregion

namespace KKTServiceLib.Mercury.Types.Operations.KKT.GetKKTInfo
{
    [Description("Запрос информации о ККТ")]
    public class GetKKTInfoOperation: Operation<GetKKTInfoOperationResult>
    {
        /// <summary>
        /// Запрос информации о ККТ
        /// </summary>
        public GetKKTInfoOperation(): base("GetCommonInfo") { }
    }
}