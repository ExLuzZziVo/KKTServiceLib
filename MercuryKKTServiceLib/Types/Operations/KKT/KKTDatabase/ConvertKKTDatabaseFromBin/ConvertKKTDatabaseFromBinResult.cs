using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using MercuryKKTServiceLib.Types.Common;
using MercuryKKTServiceLib.Types.Enums;

namespace MercuryKKTServiceLib.Types.Operations.KKT.KKTDatabase.ConvertKKTDatabaseFromBin
{
    [Description("Результат конвертации базы товаров из внутреннего формата ККТ")]
    public class ConvertKKTDatabaseFromBinResult : OperationResult
    {
        /// <summary>
        /// Версия внутренней базы товаров ККТ
        /// </summary>
        [Display(Name = "Версия внутренней базы товаров ККТ")]
        public KKTDatabaseVersion BaseVersion { get; set; }

        /// <summary>
        /// Товары
        /// </summary>
        [Display(Name = "Товары")]
        public Product[] Base { get; set; }
    }
}