#region

using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Serialization;

#endregion

namespace AtolKKTServiceLib.Types.Enums
{
    /// <summary>
    /// Выравнивание
    /// </summary>
    [JsonConverter(typeof(StringEnumConverter), typeof(CamelCaseNamingStrategy))]
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