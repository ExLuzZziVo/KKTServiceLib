#region

using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using KKTServiceLib.Mercury.Types.Common.KKT;

#endregion

namespace KKTServiceLib.Mercury.Types.Operations.Fiscal.KKTRegistration.GetKKTRegistrationInfo
{
    public class KKTWorkParamsInfo: KKTWorkParams
    {
        [JsonConstructor]
        private KKTWorkParamsInfo() { }

        /// <summary>
        /// Признак работы в составе автоматического устройства для расчётов
        /// </summary>
        /// <remarks>
        /// Значение по умолчанию: false
        /// </remarks>
        [Display(Name = "Признак работы в составе автоматического устройства для расчётов")]
        public bool? ForAutomat { get; set; } = false;

        /// <summary>
        /// Признак работы с маркированными товарами
        /// </summary>
        /// <remarks>
        /// Значение по умолчанию: false
        /// </remarks>
        [Display(Name = "Признак работы с маркированными товарами")]
        public bool? ForMarkedGoods { get; set; } = false;

        /// <summary>
        /// Признак применения ККТ для приёма ставок и выплате выигрышей при проведении азартных игр
        /// </summary>
        /// <remarks>
        /// Значение по умолчанию: false
        /// </remarks>
        [Display(Name = "Признак применения ККТ для приёма ставок и выплате выигрышей при проведении азартных игр")]
        public bool? ForGamble { get; set; } = false;

        /// <summary>
        /// Признак применения ККТ для реализации лотерейных билетов и выплате выигрышей при проведении лотерей
        /// </summary>
        /// <remarks>
        /// Значение по умолчанию: false
        /// </remarks>
        [Display(Name =
            "Признак применения ККТ для реализации лотерейных билетов и выплате выигрышей при проведении лотерей")]
        public bool? ForLottery { get; set; } = false;

        /// <summary>
        /// Признак применения ККТ в ломбардах
        /// </summary>
        /// <remarks>
        /// Значение по умолчанию: false
        /// </remarks>
        [Display(Name = "Признак применения ККТ в ломбардах")]
        public bool? ForLombard { get; set; } = false;

        /// <summary>
        /// Признак применения ККТ при осуществлении деятельности по страхованию
        /// </summary>
        /// <remarks>
        /// Значение по умолчанию: false
        /// </remarks>
        [Display(Name = "Признак применения ККТ при осуществлении деятельности по страхованию")]
        public bool? ForInsurance { get; set; } = false;
    }
}