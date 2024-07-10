#region

using System.ComponentModel;

#endregion

namespace KKTServiceLib.Mercury.Types.Operations.KKT.KKTDatabase.GetKKTDatabaseProgress
{
    [Description("Получение прогресса выполнения операции с базой данных ККТ")]
    public class GetKKTDatabaseProgressOperation: Operation<GetKKTDatabaseProgressResult>
    {
        /// <summary>
        /// Получение прогресса выполнения операции с базой данных ККТ
        /// </summary>
        public GetKKTDatabaseProgressOperation(): base("GetProgress") { }
    }
}