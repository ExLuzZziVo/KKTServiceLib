﻿using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace MercuryKKTServiceLib.Types.Operations.KKT.KKTDatabase.GetKKTDatabaseVersion
{
    [Description("Результат получения версии базы данных ККТ")]
    public class GetKKTDatabaseVersionResult : OperationResult
    {
        /// <summary>
        /// Текущая версия базы товаров в ККТ
        /// </summary>
        [Display(Name = "Текущая версия базы товаров в ККТ")]
        public string KktBaseVer { get; set; }

        /// <summary>
        /// Максимальная версия базы товаров ККТ, с которой может работать драйвер
        /// </summary>
        [Display(Name = "Максимальная версия базы товаров ККТ, с которой может работать драйвер")]
        public string DriverBaseVer { get; set; }
    }
}