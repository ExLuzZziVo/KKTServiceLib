#region

using System.ComponentModel;

#endregion

namespace KKTServiceLib.Atol.Types.Operations.Fiscal.Fn.GetFnInfo
{
    [Description("Запрос информации о ФН")]
    public class GetFnInfoOperation: Operation<GetFnInfoResult>
    {
        /// <summary>
        /// Запрос информации о ФН
        /// </summary>
        public GetFnInfoOperation(): base("getFnInfo") { }
    }
}