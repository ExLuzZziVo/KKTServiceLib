#region

using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using KKTServiceLib.Atol.Types.Common.Warnings;
using KKTServiceLib.Atol.Types.Enums;

#endregion

namespace KKTServiceLib.Atol.Types.Operations.Fiscal.Fn.GetFnInfo
{
    [Description("Информация о ФН")]
    public class FnInfo
    {
        /// <summary>
        /// Заводской номер ФН
        /// </summary>
        [Display(Name = "Заводской номер ФН")]
        public string Serial { get; set; }

        /// <summary>
        /// Версия ФН
        /// </summary>
        [Display(Name = "Версия ФН")]
        public string Version { get; set; }

        /// <summary>
        /// Исполнение ФН (только для ФН-М)
        /// </summary>
        [Display(Name = "Исполнение ФН (только для ФН-М)")]
        public string Execution { get; set; }

        /// <summary>
        /// Количество проведенных регистраций
        /// </summary>
        [Display(Name = "Количество проведенных регистраций")]
        public uint NumberOfRegistrations { get; set; }

        /// <summary>
        /// Количество оставшихся регистраций
        /// </summary>
        [Display(Name = "Количество оставшихся регистраций")]
        public uint RegistrationsRemaining { get; set; }

        /// <summary>
        /// Срок действия ФН
        /// </summary>
        [Display(Name = "Срок действия ФН")]
        public DateTime ValidityDate { get; set; }

        /// <summary>
        /// Версия ФФД ККТ
        /// </summary>
        [Display(Name = "Версия ФФД ККТ")]
        public string FfdVersion { get; set; }

        /// <summary>
        /// ФН содержит URI сервера ОКП
        /// </summary>
        [Display(Name = "ФН содержит URI сервера ОКП")]
        public bool FnContainsKeysUpdaterServerUri { get; set; }

        /// <summary>
        /// Версия ФФД ФН
        /// </summary>
        [Display(Name = "Версия ФФД ФН")]
        public string FnFfdVersion { get; set; }

        /// <summary>
        /// Фаза жизни ФН
        /// </summary>
        [Display(Name = "Фаза жизни ФН")]
        public FnLivePhaseType LivePhase { get; set; }

        /// <summary>
        /// Предупреждения ФН
        /// </summary>
        [Display(Name = "Предупреждения ФН")]
        public FnWarning Warnings { get; set; }
    }
}