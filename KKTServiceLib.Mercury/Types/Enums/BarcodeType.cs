#region

using System.ComponentModel.DataAnnotations;

#endregion

namespace KKTServiceLib.Mercury.Types.Enums
{
    /// <summary>
    /// Тип ШК
    /// </summary>
    public enum BarcodeType : byte
    {
        /// <summary>
        /// EAN-8
        /// </summary>
        [Display(Name = "EAN-8")] EAN8 = 1,

        /// <summary>
        /// EAN-13
        /// </summary>
        [Display(Name = "EAN-13")] EAN13 = 2,

        /// <summary>
        /// Code 39
        /// </summary>
        [Display(Name = "Code 39")] CODE39 = 3,

        /// <summary>
        /// Qr code
        /// </summary>
        [Display(Name = "Qr code")] QR = 4
    }
}