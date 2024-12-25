#region

using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using KKTServiceLib.Mercury.Types.Enums;
using KKTServiceLib.Mercury.Types.Operations.KKT.SalesJournal.GetSalesJournal;

#endregion

namespace KKTServiceLib.Mercury.Types.Common.MarkingCodes
{
    [Description("Информация о коде маркировки")]
    [JsonDerivedType(typeof(MarkingCodeCorrectedInfo))]
    [JsonDerivedType(typeof(JournalMarkingCodeInfo))]
    public class MarkingCodeInfo
    {
        /// <summary>
        /// Тип кода маркировки
        /// </summary>
        [Display(Name = "Тип кода маркировки")]
        public MarkingCodeCheckImcType? McType { get; set; }

        /// <summary>
        /// Идентификатор товара
        /// </summary>
        [Display(Name = "Идентификатор товара")]
        public string McGoodsID { get; set; }
    }
}