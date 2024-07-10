#region

using System.ComponentModel.DataAnnotations;

#endregion

namespace KKTServiceLib.Mercury.Types.Operations
{
    /// <summary>
    /// Результат выполнения фискальной операции
    /// </summary>
    public abstract class FiscalOperationResult: OperationResult
    {
        /// <summary>
        /// Номер ФД
        /// </summary>
        [Display(Name = "Номер ФД")]
        public int FiscalDocNum { get; set; }

        /// <summary>
        /// Фискальный признак документа
        /// </summary>
        [Display(Name = "Фискальный признак документа")]
        public string FiscalSign { get; set; }
    }
}