#region

using CoreLib.CORE.Helpers.StringHelpers;

#endregion

namespace KKTServiceLib.Shared.Helpers
{
    public static class RegexHelper
    {
        /// <summary>
        /// Штрихкод
        /// </summary>
        public const string BarcodePattern = @"^\d{1,18}$";

        /// <summary>
        /// Реквизиты 1304 - 1306 (GS1.0, GS1.M, КМК)
        /// </summary>
        public const string BarcodeTags1304_1306Pattern = @"^01[0-9]{14}21[0-9a-zA-Z]{1,20}$";

        /// <summary>
        /// Реквизит 1308 (ЕГАИС-2.0)
        /// </summary>
        public const string BarcodeTag1308Pattern = @"^[0-9A-Z]{23}$";

        /// <summary>
        /// Реквизит 1309 (ЕГАИС-3.0)
        /// </summary>
        public const string BarcodeTag1309Pattern = @"^[0-9A-Z]{14}$";

        /// <summary>
        /// Номер телефона
        /// </summary>
        public const string PhoneNumberPattern = @"^[+][1-9]\d{10}$";

        /// <summary>
        /// IP-адрес или Url-адрес
        /// </summary>
        public const string IPAddressOrUrlPattern = RegexExtensions.IpAddressPattern + "|" + RegexExtensions.UrlPattern;

        /// <summary>
        /// Номер телефона или Email
        /// </summary>
        public const string EmailAddressOrPhoneNumberPattern =
            RegexExtensions.EmailAddressPattern + "|" + PhoneNumberPattern;

        /// <summary>
        /// Код страны происхождения
        /// </summary>
        public const string CountryOfOriginCodePattern = @"^\d{3}$";
    }
}