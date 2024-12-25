#region

using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using KKTServiceLib.Mercury.Types.Common.MarkingCodes;

#endregion

namespace KKTServiceLib.Mercury.Types.Operations.KKT.SalesJournal.GetSalesJournal
{
    [Description("Информация о коде маркировки")]
    public class JournalMarkingCodeInfo: MarkingCodeInfo
    {
        /// <summary>
        /// Контрольный код КМ
        /// </summary>
        [Display(Name = "Контрольный код КМ")]
        public int? Crc { get; set; }

        /// <summary>
        /// Итоговый результат проверки КМ
        /// </summary>
        /// <remarks>
        /// Необработанное значение тега 2106, сформированного ФН по результатам проверки КМ в ФН и ИСМ
        /// </remarks>
        [Display(Name = "Итоговый результат проверки КМ")]
        public int? McCheckResultRaw { get; set; }

        /// <summary>
        /// Дробное количество маркированного товара, выраженное в виде правильной дроби
        /// </summary>
        [Display(Name = "Дробное количество маркированного товара, выраженное в виде правильной дроби")]
        public FractionalNumber Part { get; set; }
    }
}