#region

using System.ComponentModel;

#endregion

namespace KKTServiceLib.Atol.Types.Operations.KKT.GetMCUInfo
{
    [Description("Запрос информации о микроконтроллере")]
    public class GetMCUInfoOperation: Operation<GetMCUInfoResult>
    {
        /// <summary>
        /// Запрос информации о микроконтроллере
        /// </summary>
        public GetMCUInfoOperation(): base("getMcu") { }
    }
}