#region

using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

#endregion

namespace KKTServiceLib.Mercury.Types.Operations.KKT.KKTDatabase.GetKKTDatabaseProgress
{
    [Description("Результат получения прогресса выполнения операции с базой данных ККТ")]
    public class GetKKTDatabaseProgressResult: OperationResult
    {
        /// <summary>
        /// Имя команды
        /// </summary>
        [Display(Name = "Имя команды")]
        public string CmdRefer { get; set; }

        /// <summary>
        /// Код текущего статуса выполнения операции
        /// </summary>
        [Display(Name = "Код текущего статуса выполнения операции")]
        public int OpStatus { get; set; }

        /// <summary>
        /// Прогресс выполнения
        /// </summary>
        [Display(Name = "Прогресс выполнения")]
        public int Progress { get; set; }
    }
}