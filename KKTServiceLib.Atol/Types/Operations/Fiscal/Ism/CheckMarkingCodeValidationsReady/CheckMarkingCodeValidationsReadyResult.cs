#region

using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

#endregion

namespace KKTServiceLib.Atol.Types.Operations.Fiscal.Ism.CheckMarkingCodeValidationsReady
{
    [Description("Результат проверки состояния фоновой проверки")]
    public class CheckMarkingCodeValidationsReadyResult
    {
        /// <summary>
        /// Признак завершения фоновых проверок КМ
        /// </summary>
        [Display(Name = "Признак завершения фоновых проверок КМ")]
        public bool ValidationReady { get; set; }
    }
}