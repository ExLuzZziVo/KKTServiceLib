#region

using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using CoreLib.CORE.Helpers.Converters;

#endregion

namespace KKTServiceLib.Atol.Types.Enums
{
    /// <summary>
    /// Тип кода маркировки
    /// </summary>
    [JsonConverter(typeof(JsonCamelCaseStringEnumConverter))]
    public enum MarkingCodeCheckImcType : byte
    {
        /// <summary>
        /// Определить тип КМ автоматически
        /// </summary>
        [Display(Name = "Определить тип КМ автоматически")]
        Auto,

        /// <summary>
        /// Неопознанный КМ
        /// </summary>
        [Display(Name = "Неопознанный КМ")] ImcUnrecognized,

        /// <summary>
        /// Короткий КМ
        /// </summary>
        [Display(Name = "Короткий КМ")] ImcShort,

        /// <summary>
        /// КМ со значением кода проверки длиной 88 символов, подлежащим проверке в ФН
        /// </summary>
        [Display(Name = "КМ со значением кода проверки длиной 88 символов, подлежащим проверке в ФН")]
        ImcFmVerifyCode88,

        /// <summary>
        /// КМ со значением кода проверки длиной 44 символа, не подлежащим проверке в ФН
        /// </summary>
        [Display(Name = "КМ со значением кода проверки длиной 44 символа, не подлежащим проверке в ФН")]
        ImcVerifyCode44,

        /// <summary>
        /// КМ со значением кода проверки длиной 44 символа, подлежащим проверке в ФН
        /// </summary>
        [Display(Name = "КМ со значением кода проверки длиной 44 символа, подлежащим проверке в ФН")]
        ImcFmVerifyCode44,

        /// <summary>
        /// КМ со значением кода проверки длиной 4 символа, не подлежащим проверке в ФН
        /// </summary>
        [Display(Name = "КМ со значением кода проверки длиной 4 символа, не подлежащим проверке в ФН")]
        ImcVerifyCode4
    }
}