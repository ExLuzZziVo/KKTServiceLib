#region

using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

#endregion

namespace KKTServiceLib.Mercury.Types.Operations.KKT.KKTDatabase.ConvertKKTDatabaseToBin
{
    [Description("Результат конвертации базы товаров во внутренний формат ККТ")]
    public class ConvertKKTDatabaseToBinResult: OperationResult
    {
        /// <summary>
        /// База товаров ККТ в base64
        /// </summary>
        [Display(Name = "База товаров ККТ в base64")]
        public string Base { get; set; }
    }
}