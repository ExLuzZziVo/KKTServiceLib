#region

using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

#endregion

namespace KKTServiceLib.Atol.Types.Common.Warnings
{
    [Description("Флаги предупреждений")]
    public class WarningFlags
    {
        /// <summary>
        /// Документ закрыт, но не допечатан
        /// </summary>
        [Display(Name = "Документ закрыт, но не допечатан")]
        public bool NotPrinted { get; set; }
        
        /// <summary>
        /// Контейнер для отправки пуст
        /// </summary>
        [Display(Name = "Контейнер для отправки пуст")]
        public bool DataForSendIsEmpty { get; set; }
    }
}