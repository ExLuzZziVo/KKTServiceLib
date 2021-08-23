#region

using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

#endregion

namespace KKTServiceLib.Atol.Types.Common.FiscalDocuments
{
    [Description("Фискальный документ")]
    public class FiscalDocumentParams
    {
        /// <summary>
        /// Номер ФД
        /// </summary>
        [Display(Name = "Номер ФД")]
        public uint FiscalDocumentNumber { get; set; }

        /// <summary>
        /// Фискальный признак документа
        /// </summary>
        [Display(Name = "Фискальный признак документа")]
        public string FiscalDocumentSign { get; set; }

        /// <summary>
        /// Дата и время ФД
        /// </summary>
        [Display(Name = "Дата и время ФД")]
        public DateTime FiscalDocumentDateTime { get; set; }

        /// <summary>
        /// Номер смены
        /// </summary>
        [Display(Name = "Номер смены")]
        public uint ShiftNumber { get; set; }

        /// <summary>
        /// Номер ФН
        /// </summary>
        [Display(Name = "Номер ФН")]
        public string FnNumber { get; set; }

        /// <summary>
        /// РНМ
        /// </summary>
        [Display(Name = "РНМ")]
        public string RegistrationNumber { get; set; }

        /// <summary>
        /// Адрес сайта ФНС
        /// </summary>
        [Display(Name = "Адрес сайта ФНС")]
        public string FnsUrl { get; set; }
    }
}