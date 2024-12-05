namespace MultiNationalsSample
{
    /// <summary>
    /// Country code (ISO-3166-1)
    /// </summary>
    [Flags]
    public enum Country : long
    {
        /*
         * Since the long type in the Flags enum uses 64 bits, 
         * a total of 64 different countries can be defined, from 1 < 0 to 1 < 63.
         */

        [Country(Language.ko, "KRW", "₩", true, CountryExtension.IntegerFormat, "Republic of Korea")]
        KR = 1 << 0,

        [Country(Language.en, "USD", "$", true, CountryExtension.TwoDecimalPlacesFormat, "United States of America")]
        US = 1 << 1,

        [Country(Language.zh_CN, "CNY", "元", false, CountryExtension.IntegerFormat, "People's Republic of China")]
        CN = 1 << 2,

        [Country(Language.zh_TW, "TWD", "NT$", true, CountryExtension.TwoDecimalPlacesFormat, "Taiwan")]
        TW = 1 << 3,

        [Country(Language.en, "GBP", "£", true, CountryExtension.TwoDecimalPlacesFormat, "United Kingdom")]
        GB = 1 << 4,

        [Country(Language.fr, "EUR", "€", false, CountryExtension.TwoDecimalPlacesFormat, "French Republic")]
        FR = 1 << 5,

        [Country(Language.it, "EUR", "€", false, CountryExtension.TwoDecimalPlacesFormat/*, "Italian Republic"*/)]
        IT = 1 << 6,

        // TODO : When adding a country, add a country code to the enum.
    }
}
