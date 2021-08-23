using System.ComponentModel.DataAnnotations;

namespace KKTServiceLib.Mercury.Types.Enums
{
    /// <summary>
    /// Тип фискального чека
    /// </summary>
    public enum FiscalReceiptType : byte
    {
        [Display(Name = "Приход")] Sell = 0,
        [Display(Name = "Возврат прихода")] SellReturn = 1,
        [Display(Name = "Расход")] Buy = 2,
        [Display(Name = "Возврат расхода")] BuyReturn = 3,

        [Display(Name = "Чек коррекции - Приход")]
        SellCorrection = 4,

        [Display(Name = "Чек коррекции - Расход")]
        BuyCorrection = 5,

        [Display(Name = "Чек коррекции - Возврат прихода")]
        SellReturnCorrection = 6,

        [Display(Name = "Чек коррекции - Возврат расхода")]
        BuyReturnCorrection = 7
    }
}