namespace KKTServiceLib.Shared.Helpers
{
    public static class RegexHelper
    {
        /// <summary>
        /// ИНН физ. лица/ИП
        /// </summary>
        public const string PhysicalVatinPattern = @"^\d{12}$";

        /// <summary>
        /// ИНН юр. лица
        /// </summary>
        public const string EntityVatinPattern = @"^\d{10}$";

        /// <summary>
        /// ИНН
        /// </summary>
        public const string VatinPattern = EntityVatinPattern + "|" + PhysicalVatinPattern;

        /// <summary>
        /// КПП
        /// </summary>
        public const string KPPPattern = @"^\d{9}$";

        /// <summary>
        /// Url-адрес
        /// </summary>
        public const string UrlPattern =
            @"^(http:\/\/www\.|https:\/\/www\.|http:\/\/|https:\/\/)?[a-z0-9]+([\-\.]{1}[a-z0-9]+)*\.[a-z]{2,5}(:[0-9]{1,5})?(\/.*)?$";

        /// <summary>
        /// Штрихкод
        /// </summary>
        public const string BarcodePattern = @"^\d{1,18}$";

        /// <summary>
        /// GTIN
        /// </summary>
        public const string GTINPattern = @"^((\d{8})|(\d{12,14}))$";

        /// <summary>
        /// EAN8
        /// </summary>
        public const string BarcodeEAN8Pattern = @"^\d{8}$";

        /// <summary>
        /// EAN13
        /// </summary>
        public const string BarcodeEAN13Pattern = @"^\d{13}$";

        /// <summary>
        /// UPCA
        /// </summary>
        public const string BarcodeUPCAPattern = @"^\d{12}$";

        /// <summary>
        /// UPCE
        /// </summary>
        public const string BarcodeUPCEPattern = @"^\d{6}$";

        /// <summary>
        /// ITF
        /// </summary>
        public const string BarcodeITFPattern = @"^\d{6}$";

        /// <summary>
        /// ITF14
        /// </summary>
        public const string BarcodeITF14Pattern = @"^\d{14}$";

        /// <summary>
        /// CODE39
        /// </summary>
        public const string BarcodeCODE39Pattern = @"^([*]?)(?:[0-9A-Z/.,%$+\s-]+)*(\1)$";

        /// <summary>
        /// CODE93
        /// </summary>
        public const string BarcodeCODE93Pattern =
            @"^[*](?:[0-9A-Z/.,%$+\s-]|(\(\$\)[A-Z])|(\(%\)[A-Z])|(\(\+\)[A-Z])|(\(/\)[A-CF-JLZ])+)*[*]$";

        /// <summary>
        /// CODE128
        /// </summary>
        public const string BarcodeCODE128Pattern = @"^[\x00-\x7F]*$";

        /// <summary>
        /// CODABAR
        /// </summary>
        public const string BarcodeCODABARPattern = @"^[0-9A-D/.$+:-]*$";

        /// <summary>
        /// GS1-128
        /// </summary>
        public const string BarcodeGS1_128Pattern = @"^(\(\d{2,4}\)[A-Za-z0-9]+)*$";

        /// <summary>
        /// PDF417
        /// </summary>
        public const string BarcodePDF417Pattern = @"^[\x00-\xFF]*$";

        /// <summary>
        /// CODE39 EXTENDED
        /// </summary>
        public const string BarcodeCODE39_EXTENDEDPattern = @"^[\x00-\x7F]*$";

        /// <summary>
        /// Код маркировки меховых изделий
        /// </summary>
        public const string BarcodeFurPattern = @"^[A-Z]{2}-[0-9]{6}-[A-Z]{10}$";

        /// <summary>
        /// ЕГАИС-2.0
        /// </summary>
        public const string BarcodeEgais20Pattern = @"^[0-9A-Z]{68}$";

        /// <summary>
        /// ЕГАИС-3.0
        /// </summary>
        public const string BarcodeEgais30Pattern = @"^[0-9A-Z]{150}$";

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
        /// IP-адрес
        /// </summary>
        public const string IPAddressPattern =
            @"^(0[0-7]{10,11}|0(x|X)[0-9a-fA-F]{8}|(\b4\d{8}[0-5]\b|\b[1-3]?\d{8}\d?\b)|((2[0-5][0-5]|1\d{2}|[1-9]\d?)|(0(x|X)[0-9a-fA-F]{2})|(0[0-7]{3}))(\.((2[0-5][0-5]|1\d{2}|\d\d?)|(0(x|X)[0-9a-fA-F]{2})|(0[0-7]{3}))){3})$";

        /// <summary>
        /// IP-адрес или Url-адрес
        /// </summary>
        public const string IPAddressOrUrlPattern = IPAddressPattern + "|" + UrlPattern;

        /// <summary>
        /// Email
        /// </summary>
        public const string EmailAddressPattern =
            @"\A(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?)\Z";

        /// <summary>
        /// Номер телефона или Email
        /// </summary>
        public const string EmailAddressOrPhoneNumberPattern = EmailAddressPattern + "|" + PhoneNumberPattern;

        /// <summary>
        /// Код страны происхождения
        /// </summary>
        public const string CountryOfOriginCodePattern = @"^\d{3}$";

        /// <summary>
        /// Base64
        /// </summary>
        public const string Base64Pattern = @"^(?:[A-Za-z\d+/]{4})*(?:[A-Za-z\d+/]{3}=|[A-Za-z\d+/]{2}==)?$";
    }
}