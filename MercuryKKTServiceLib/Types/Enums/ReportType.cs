﻿using System.ComponentModel.DataAnnotations;

namespace MercuryKKTServiceLib.Types.Enums
{
    /// <summary>
    /// Тип отчета
    /// </summary>
    public enum ReportType : byte
    {
        /// <summary>
        /// Общий отчёт за смену
        /// </summary>
        [Display(Name = "Общий отчёт за смену")]
        XReport = 1
    }
}