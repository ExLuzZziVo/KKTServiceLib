using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using KKTServiceLib.Shared.Types.Converters;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace MercuryKKTServiceLib.Types.Operations.KKT.GetKKTInfo
{
    [Description("Результат запроса информации о ККТ")]
    public class GetKKTInfoOperationResult : OperationResult
    {
        /// <summary>
        /// Название модели ККТ
        /// </summary>
        [Display(Name = "Название модели ККТ")]
        public string Model { get; set; }

        /// <summary>
        /// Заводской номер ККТ
        /// </summary>
        [Display(Name = "Заводской номер ККТ")]
        public string KktNum { get; set; }

        /// <summary>
        /// Заводской номер ФН
        /// </summary>
        [Display(Name = "Заводской номер ФН")]
        public string FnNum { get; set; }

        /// <summary>
        /// Версия ФФД ФН
        /// </summary>
        [Display(Name = "Версия ФФД ФН")]
        public string FfdFnVer { get; set; }

        /// <summary>
        /// Версия ФФД ККТ
        /// </summary>
        [Display(Name = "Версия ФФД ККТ")]
        public string FfdKktVer { get; set; }

        /// <summary>
        /// Итоговая версия ФФД (по которой работает ККТ)
        /// </summary>
        [Display(Name = "Итоговая версия ФФД (по которой работает ККТ)")]
        public string FfdTotalVer { get; set; }

        /// <summary>
        /// Версия прошивки ККТ
        /// </summary>
        [Display(Name = "Версия прошивки ККТ")]
        public string ProgramVer { get; set; }

        /// <summary>
        /// Дата выпуска прошивки ККТ
        /// </summary>
        [Display(Name = "Дата выпуска прошивки ККТ")]
        [JsonConverter(typeof(CustomDateTimeConverter), "yyyy-MM-dd")]
        public DateTime ProgramDate { get; set; }

        /// <summary>
        /// Текущие дата и время ККТ
        /// </summary>
        [Display(Name = "Текущие дата и время ККТ")]
        [JsonConverter(typeof(IsoDateTimeConverter))]
        public DateTime? DateTime { get; set; }

        /// <summary>
        /// Максимальное количество символов в строке чека для каждого шрифта
        /// </summary>
        [Display(Name = "Максимальное количество символов в строке чека для каждого шрифта")]
        public int[] Cpl { get; set; }

        /// <summary>
        /// Максимальная допустимая сумма для одного предмета расчета
        /// </summary>
        [Display(Name = "Максимальная допустимая сумма для одного предмета расчета")]
        public int MaxGoodsSum { get; set; }

        /// <summary>
        /// Максимальная допустимая сумма чека
        /// </summary>
        [Display(Name = "Максимальная допустимая сумма чека")]
        public int MaxCheckSum { get; set; }

        /// <summary>
        /// Максимальное количество предметов расчета в одном чеке
        /// </summary>
        [Display(Name = "Максимальное количество предметов расчета в одном чеке")]
        public int MaxGoodsQty { get; set; }
    }
}