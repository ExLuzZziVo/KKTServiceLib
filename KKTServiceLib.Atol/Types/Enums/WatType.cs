#region

using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using CoreLib.CORE.Helpers.Converters;

#endregion

namespace KKTServiceLib.Atol.Types.Enums
{
    /// <summary>
    /// Налоговая ставка
    /// </summary>
    [JsonConverter(typeof(JsonCamelCaseStringEnumConverter))]
    public enum WatType: byte
    {
        /// <summary>
        /// НДС не облагается
        /// </summary>
        [Display(Name = "НДС не облагается")] None,

        /// <summary>
        /// НДС 0%
        /// </summary>
        [Display(Name = "НДС 0%")] Vat0,

        /// <summary>
        /// НДС 10%
        /// </summary>
        [Display(Name = "НДС 10%")] Vat10,

        /// <summary>
        /// НДС 10/110
        /// </summary>
        [Display(Name = "НДС 10/110")] Vat110,

        /// <summary>
        /// НДС 20%
        /// </summary>
        [Display(Name = "НДС 20%")] Vat20,

        /// <summary>
        /// НДС 20/120
        /// </summary>
        [Display(Name = "НДС 20/120")] Vat120
    }
}