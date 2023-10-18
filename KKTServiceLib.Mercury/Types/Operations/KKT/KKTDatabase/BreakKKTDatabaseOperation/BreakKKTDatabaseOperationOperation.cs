#region

using System.ComponentModel;

#endregion

namespace KKTServiceLib.Mercury.Types.Operations.KKT.KKTDatabase.BreakKKTDatabaseOperation
{
    [Description("Прерывание текущей операции с базой данных ККТ")]
    public class BreakKKTDatabaseOperationOperation : Operation<BreakKKTDatabaseOperationResult>
    {
        /// <summary>
        /// Прерывание текущей операции с базой данных ККТ
        /// </summary>
        public BreakKKTDatabaseOperationOperation() : base("BreakOperation") { }
    }
}