#region

using System.ComponentModel;

#endregion

namespace AtolKKTServiceLib.Types.Operations.Fiscal.Fn.GetFnInfo
{
    [Description("Запрос информации о ФН")]
    public class GetFnInfoOperation : Operation<GetFnInfoResult>
    {
        /// <summary>
        /// Запрос информации о ФН
        /// </summary>
        public GetFnInfoOperation() : base("getFnInfo")
        {
        }
    }
}