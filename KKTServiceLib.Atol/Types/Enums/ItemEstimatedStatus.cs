using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Serialization;

namespace KKTServiceLib.Atol.Types.Enums
{
    /// <summary>
    /// Планируемый статус КМ
    /// </summary>
    [JsonConverter(typeof(StringEnumConverter), typeof(CamelCaseNamingStrategy))]
    public enum ItemEstimatedStatus : byte
    {
        /// <summary>
        /// Штучный товар, реализован
        /// </summary>
        [Display(Name = "Штучный товар, реализован")]
        ItemPieceSold = 1,

        /// <summary>
        /// Мерный товар, в стадии реализации
        /// </summary>
        [Display(Name = "Мерный товар, в стадии реализации")]
        ItemDryForSale = 2,

        /// <summary>
        /// Штучный товар, возвращен
        /// </summary>
        [Display(Name = "Штучный товар, возвращен")]
        ItemPieceReturn = 3,

        /// <summary>
        /// Часть товара, возвращена
        /// </summary>
        [Display(Name = "Часть товара, возвращена")]
        ItemDryReturn = 4,

        /// <summary>
        /// Статус товара, не изменился
        /// </summary>
        [Display(Name = "Статус товара, не изменился")]
        ItemStatusUnchanged = 255
    }
}