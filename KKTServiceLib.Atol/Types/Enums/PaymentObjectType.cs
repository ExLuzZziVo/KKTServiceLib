#region

using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using CoreLib.CORE.Helpers.Converters;

#endregion

namespace KKTServiceLib.Atol.Types.Enums
{
    /// <summary>
    /// Тип предмета расчета
    /// </summary>
    [JsonConverter(typeof(JsonCamelCaseStringEnumConverter))]
    public enum PaymentObjectType: byte
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
        /// Туристический налог
        /// </summary>
        [Display(Name = "Туристический налог")] TouristTax = 18,

        /// <summary>
        /// Залог
        /// </summary>
        [Display(Name = "Залог")] Deposit = 19,

        /// <summary>
        /// Расход
        /// </summary>
        [Display(Name = "Расход")] Consumption = 20,

        /// <summary>
        /// Взносы на ОПС ИП
        /// </summary>
        [Display(Name = "Взносы на ОПС ИП")] SoleProprietorCpiContributions = 21,

        /// <summary>
        /// Вносы на ОПС
        /// </summary>
        [Display(Name = "Вносы на ОПС")] CpiContributions = 22,

        /// <summary>
        /// Взносы на ОМС ИП
        /// </summary>
        [Display(Name = "Взносы на ОМС ИП")] SoleProprietorCmiContributions = 23,

        /// <summary>
        /// Взносы на ОМС
        /// </summary>
        [Display(Name = "Взносы на ОМС")] CmiContributions = 24,

        /// <summary>
        /// Взносы на ОСС
        /// </summary>
        [Display(Name = "Взносы на ОСС")] CsiContributions = 25,

        /// <summary>
        /// Платеж казино
        /// </summary>
        [Display(Name = "Платеж казино")] CasinoPayment = 26,

        /// <summary>
        /// Выдача денежных средств
        /// </summary>
        [Display(Name = "Выдача денежных средств")]
        FundsIssuance = 27,

        /// <summary>
        /// Подакцизный товар, подлежащий маркировке (без КМ)
        /// </summary>
        [Display(Name = "Подакцизный товар, подлежащий маркировке (без КМ)")]
        ExciseWithoutMarking = 30,

        /// <summary>
        /// Подакцизный товар, подлежащий маркировке (с КМ)
        /// </summary>
        [Display(Name = "Подакцизный товар, подлежащий маркировке (с КМ)")]
        ExciseWithMarking = 31,

        /// <summary>
        /// Товар, подлежащий маркировке (без КМ)
        /// </summary>
        [Display(Name = "Товар, подлежащий маркировке (без КМ)")]
        CommodityWithoutMarking = 32,

        /// <summary>
        /// Товар, подлежащий маркировке (с КМ)
        /// </summary>
        [Display(Name = "Товар, подлежащий маркировке (с КМ)")]
        CommodityWithMarking = 33
    }
}
