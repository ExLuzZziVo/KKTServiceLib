#region

using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

#endregion

namespace KKTServiceLib.Atol.Types.Common.FiscalDocuments
{
    [Description("Фискальный документ о закрытии смены")]
    public class CloseShiftFiscalDocumentParams : FiscalDocumentParams
    {
        /// <summary>
        /// Количество чеков за смену
        /// </summary>
        [Display(Name = "Количество чеков за смену")]
        public uint ReceiptsCount { get; set; }
    }
}