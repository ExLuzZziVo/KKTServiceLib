﻿#region

using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using KKTServiceLib.Mercury.Types.Common.FiscalDocuments;
using KKTServiceLib.Mercury.Types.Enums;

#endregion

namespace KKTServiceLib.Mercury.Types.Common
{
    [Description("Информация о ФН")]
    public class FnInfo
    {
        /// <summary>
        /// Фаза жизни ФН
        /// </summary>
        [Display(Name = "Фаза жизни ФН")]
        public FnLivePhaseType Status { get; set; }

        /// <summary>
        /// Заводской номер ФН
        /// </summary>
        [Display(Name = "Заводской номер ФН")]
        public string FnNum { get; set; }

        /// <summary>
        /// Последний зарегистрированный в ФН документ
        /// </summary>
        [Display(Name = "Последний зарегистрированный в ФН документ")]
        public FiscalDocument LastDoc { get; set; }

        /// <summary>
        /// Фискальные документы, которые не были переданы ОФД
        /// </summary>
        [Display(Name = "Фискальные документы, которые не были переданы ОФД")]
        public UnsignedDocument UnsignedDocs { get; set; }
    }
}