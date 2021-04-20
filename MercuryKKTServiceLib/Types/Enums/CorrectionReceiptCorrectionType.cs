#region

using System.ComponentModel.DataAnnotations;

#endregion

namespace MercuryKKTServiceLib.Types.Enums
{
    /// <summary>
    /// Тип коррекции
    /// </summary>
    public enum CorrectionReceiptCorrectionType : byte
    {
        /// <summary>
        /// Самостоятельно
        /// </summary>
        [Display(Name = "Самостоятельно")] Self = 0,

        /// <summary>
        /// По предписанию
        /// </summary>
        [Display(Name = "По предписанию")] Instruction = 1
    }
}