#region

using System.ComponentModel.DataAnnotations;

#endregion

namespace KKTServiceLib.Mercury.Types.Enums
{
    /// <summary>
    /// Тип кода маркировки
    /// </summary>
    public enum MarkingCodeCheckImcType: ushort
    {
        /// <summary>
        /// Неопознанный КМ
        /// </summary>
        [Display(Name = "Неопознанный КМ")] ImcUnrecognized = 0,

        /// <summary>
        /// Короткий КМ
        /// </summary>
        [Display(Name = "Короткий КМ")] ImcShort = 1,

        /// <summary>
        /// КМ со значением кода проверки длиной 88 символов, подлежащим проверке в ФН
        /// </summary>
        [Display(Name = "КМ со значением кода проверки длиной 88 символов, подлежащим проверке в ФН")]
        ImcFmVerifyCode88 = 2,

        /// <summary>
        /// КМ со значением кода проверки длиной 44 символа, не подлежащим проверке в ФН
        /// </summary>
        [Display(Name = "КМ со значением кода проверки длиной 44 символа, не подлежащим проверке в ФН")]
        ImcVerifyCode44 = 3,

        /// <summary>
        /// КМ со значением кода проверки длиной 44 символа, подлежащим проверке в ФН
        /// </summary>
        [Display(Name = "КМ со значением кода проверки длиной 44 символа, подлежащим проверке в ФН")]
        ImcFmVerifyCode44 = 4,

        /// <summary>
        /// КМ со значением кода проверки длиной 4 символа, не подлежащим проверке в ФН
        /// </summary>
        [Display(Name = "КМ со значением кода проверки длиной 4 символа, не подлежащим проверке в ФН")]
        ImcVerifyCode4 = 5
    }
}