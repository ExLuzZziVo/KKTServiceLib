using System.ComponentModel;

namespace KKTServiceLib.Mercury.Types.Operations.KKT.KKTDatabase.GetKKTDatabaseVersion
{
    [Description("Получение версии базы данных ККТ")]
    public class GetKKTDatabaseVersionOperation : Operation<GetKKTDatabaseVersionResult>
    {
        /// <summary>
        /// Получение версии базы данных ККТ
        /// </summary>
        public GetKKTDatabaseVersionOperation() : base("GetBaseVer") { }
    }
}