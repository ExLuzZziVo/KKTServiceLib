#region

using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Serialization;

#endregion

namespace KKTServiceLib.Atol.Types.Enums
{
    /// <summary>
    /// Тип маркируемого предмета
    /// </summary>
    [JsonConverter(typeof(StringEnumConverter), typeof(CamelCaseNamingStrategy))]
    public enum NomenclatureCodeType : byte
    {
        /// <summary>
        /// Меховые изделия
        /// </summary>
        [Display(Name = "Меховые изделия")] Furs,

        /// <summary>
        /// Лекарства
        /// </summary>
        [Display(Name = "Лекарства")] Medicines,

        /// <summary>
        /// Табачная продукция
        /// </summary>
        [Display(Name = "Табачная продукция")] Tobacco,

        /// <summary>
        /// Обувь
        /// </summary>
        [Display(Name = "Обувь")] Shoes
    }
}