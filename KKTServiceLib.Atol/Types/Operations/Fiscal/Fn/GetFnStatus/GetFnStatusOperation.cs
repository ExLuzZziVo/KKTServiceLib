#region

using System.ComponentModel;

#endregion

namespace KKTServiceLib.Atol.Types.Operations.Fiscal.Fn.GetFnStatus
{
    [Description("Запрос состояния ФН")]
    public class GetFnStatusOperation: Operation<GetFnStatusResult>
    {
        /// <summary>
        /// Запрос состояния ФН
        /// </summary>
        public GetFnStatusOperation(): base("getFnStatus") { }
    }
}