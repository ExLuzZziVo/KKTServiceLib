#region

using System.ComponentModel.DataAnnotations;

#endregion

namespace KKTServiceLib.Atol.Types.Enums
{
    /// <summary>
    /// Часовая зона
    /// </summary>
    public enum TimeZone: byte
    {
        /// <summary>
        /// UTC+2
        /// </summary>
        [Display(Name = "UTC+2")] UTC_2 = 1,

        /// <summary>
        /// UTC+3
        /// </summary>
        [Display(Name = "UTC+3")] UTC_3 = 2,

        /// <summary>
        /// UTC+4
        /// </summary>
        [Display(Name = "UTC+4")] UTC_4 = 3,

        /// <summary>
        /// UTC+5
        /// </summary>
        [Display(Name = "UTC+5")] UTC_5 = 4,

        /// <summary>
        /// UTC+6
        /// </summary>
        [Display(Name = "UTC+6")] UTC_6 = 5,

        /// <summary>
        /// UTC+7
        /// </summary>
        [Display(Name = "UTC+7")] UTC_7 = 6,

        /// <summary>
        /// UTC+8
        /// </summary>
        [Display(Name = "UTC+8")] UTC_8 = 7,

        /// <summary>
        /// UTC+9
        /// </summary>
        [Display(Name = "UTC+9")] UTC_9 = 8,

        /// <summary>
        /// UTC+10
        /// </summary>
        [Display(Name = "UTC+10")] UTC_10 = 9,

        /// <summary>
        /// UTC+11
        /// </summary>
        [Display(Name = "UTC+11")] UTC_11 = 10,

        /// <summary>
        /// UTC+12
        /// </summary>
        [Display(Name = "UTC+12")] UTC_12 = 11
    }
}