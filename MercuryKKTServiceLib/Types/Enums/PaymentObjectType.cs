#region

using System.ComponentModel.DataAnnotations;

#endregion

namespace MercuryKKTServiceLib.Types.Enums
{
    /// <summary>
    /// Тип предмета расчета
    /// </summary>
    public enum PaymentObjectType : byte
    {
        /// <summary>
        /// Товар
        /// </summary>
        [Display(Name = "Товар")] Commodity = 1,

        /// <summary>
        /// Подакцизный товар
        /// </summary>
        [Display(Name = "Подакцизный товар")] Excise = 2,

        /// <summary>
        /// Работа
        /// </summary>
        [Display(Name = "Работа")] Job = 3,

        /// <summary>
        /// Услуга
        /// </summary>
        [Display(Name = "Услуга")] Service = 4,

        /// <summary>
        /// Ставка азартной игры
        /// </summary>
        [Display(Name = "Ставка азартной игры")]
        GamblingBet = 5,

        /// <summary>
        /// Выигрыш азартной игры
        /// </summary>
        [Display(Name = "Выигрыш азартной игры")]
        GamblingPrize = 6,

        /// <summary>
        /// Лотерейный билет
        /// </summary>
        [Display(Name = "Лотерейный билет")] Lottery = 7,

        /// <summary>
        /// Выигрыш лотереи
        /// </summary>
        [Display(Name = "Выигрыш лотереи")] LotteryPrize = 8,

        /// <summary>
        /// Предоставление результатов интеллектуальной деятельности
        /// </summary>
        [Display(Name = "Предоставление результатов интеллектуальной деятельности")]
        IntellectualActivity = 9,

        /// <summary>
        /// Платеж
        /// </summary>
        [Display(Name = "Платеж")] Payment = 10,

        /// <summary>
        /// Агентское вознаграждение
        /// </summary>
        [Display(Name = "Агентское вознаграждение")]
        AgentCommission = 11,

        /// <summary>
        /// Составной предмет расчета
        /// </summary>
        [Display(Name = "Составной предмет расчета")]
        Composite = 12,

        /// <summary>
        /// Иной предмет расчета
        /// </summary>
        [Display(Name = "Иной предмет расчета")]
        Another = 13,

        /// <summary>
        /// Имущественное право
        /// </summary>
        [Display(Name = "Имущественное право")]
        ProprietaryLaw = 14,

        /// <summary>
        /// Внереализационный доход
        /// </summary>
        [Display(Name = "Внереализационный доход")]
        NonOperatingIncome = 15,

        /// <summary>
        /// Иные платежи и взносы
        /// </summary>
        [Display(Name = "Иные платежи и взносы")]
        OtherContributions = 16,

        /// <summary>
        /// Торговый сбор
        /// </summary>
        [Display(Name = "Торговый сбор")] MerchantTax = 17,

        /// <summary>
        /// Курортный сбор
        /// </summary>
        [Display(Name = "Курортный сбор")] ResortFee = 18,

        /// <summary>
        /// Залог
        /// </summary>
        [Display(Name = "Залог")] Deposit = 19
    }
}