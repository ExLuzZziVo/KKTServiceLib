#region

using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using CoreLib.CORE.Helpers.Converters;

#endregion

namespace KKTServiceLib.Atol.Types.Enums
{
    /// <summary>
    /// Выравнивание
    /// </summary>
    [JsonConverter(typeof(JsonCamelCaseStringEnumConverter))]
    public enum AlignmentType : byte
    {
        /// <summary>
        /// Выравнивание по левому краю
        /// </summary>
        [Display(Name = "Выравнивание по левому краю")]
        Left,

        /// <summary>
        /// Выравнивание по центру
        /// </summary>
        [Display(Name = "Выравнивание по центру")]
        Center,

        /// <summary>
        /// Выравнивание по правому краю
        /// </summary>
        [Display(Name = "Выравнивание по правому краю")]
        Right
    }
}