#region

using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using CoreLib.CORE.Helpers.Converters;

#endregion

namespace KKTServiceLib.Atol.Types.Enums
{
    /// <summary>
    /// Планируемый статус КМ
    /// </summary>
    [JsonConverter(typeof(JsonCamelCaseStringEnumConverter))]
    public enum ItemEstimatedStatus: byte
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
        /// Часть мерного товара, возвращена
        /// </summary>
        [Display(Name = "Часть мерного товара, возвращена")]
        ItemDryReturn = 4,

        /// <summary>
        /// Штучный товар, в стадии реализации
        /// </summary>
        [Display(Name = "Штучный товар, в стадии реализации")]
        ItemPieceForSale = 5,

        /// <summary>
        /// Мерный товар, реализован
        /// </summary>
        [Display(Name = "Мерный товар, реализован")]
        ItemDrySold = 6,

        /// <summary>
        /// Статус товара не изменился
        /// </summary>
        [Display(Name = "Статус товара не изменился")]
        ItemStatusUnchanged = 255
    }
}
