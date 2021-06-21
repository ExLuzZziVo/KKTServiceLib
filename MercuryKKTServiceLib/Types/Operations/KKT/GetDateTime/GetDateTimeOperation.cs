using System.ComponentModel;

namespace MercuryKKTServiceLib.Types.Operations.KKT.GetDateTime
{
    [Description("Запрос даты и времени ККТ")]
    public class GetDateTimeOperation : Operation<GetDateTimeResult>
    {
        /// <summary>
        /// Запрос даты и времени ККТ
        /// </summary>
        public GetDateTimeOperation() : base("GetDateTime") { }
    }
}