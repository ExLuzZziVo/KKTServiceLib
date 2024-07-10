#region

using System.ComponentModel;

#endregion

namespace KKTServiceLib.Mercury.Types.Operations.KKT.GetDateTime
{
    [Description("Запрос даты и времени ККТ")]
    public class GetDateTimeOperation: Operation<GetDateTimeResult>
    {
        /// <summary>
        /// Запрос даты и времени ККТ
        /// </summary>
        public GetDateTimeOperation(): base("GetDateTime") { }
    }
}