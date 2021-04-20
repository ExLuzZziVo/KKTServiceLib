﻿using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using MercuryKKTServiceLib.Types.Common;

namespace MercuryKKTServiceLib.Types.Operations.KKT.KKTDatabase.GetKKTDatabaseValues
{
    [Description("Результат получения товаров в результате чтения базы данных ККТ")]
    public class GetKKTDatabaseValuesResult : OperationResult
    {
        /// <summary>
        /// Товары
        /// </summary>
        [Display(Name = "Товары")]
        public Product[] Base { get; set; }
    }
}