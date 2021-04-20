﻿using System.ComponentModel;

namespace MercuryKKTServiceLib.Types.Operations.KKT.KKTDatabase.ReadKKTDatabaseValues
{
    [Description("Начать чтение товаров из базы данных ККТ")]
    public class ReadKKTDatabaseOperationValues : Operation<ReadKKTDatabaseValuesResult>
    {
        /// <summary>
        /// Начать чтение товаров из базы данных ККТ
        /// </summary>
        public ReadKKTDatabaseOperationValues() : base("ReadGoodsBase")
        {
        }
    }
}