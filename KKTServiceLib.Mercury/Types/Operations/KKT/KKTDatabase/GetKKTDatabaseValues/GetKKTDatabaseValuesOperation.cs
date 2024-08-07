﻿#region

using System.ComponentModel;

#endregion

namespace KKTServiceLib.Mercury.Types.Operations.KKT.KKTDatabase.GetKKTDatabaseValues
{
    [Description("Получение товаров в результате чтения базы данных ККТ")]
    public class GetKKTDatabaseValuesOperation: Operation<GetKKTDatabaseValuesResult>
    {
        /// <summary>
        /// Получение товаров в результате чтения базы данных ККТ
        /// </summary>
        public GetKKTDatabaseValuesOperation(): base("GetGoodsBase") { }
    }
}