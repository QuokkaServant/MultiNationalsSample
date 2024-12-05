namespace MultiNationalsSample
{
    public static class CountryExtension
    {
        /// <summary>
        /// Integer currency format
        /// </summary>
        public const string IntegerFormat = "#,0";

        /// <summary>
        /// Two decimal place currency format
        /// </summary>
        public const string TwoDecimalPlacesFormat = "#,0.00";
    }

    [AttributeUsage(AttributeTargets.Field)]
    public sealed class CountryAttribute : Attribute
    {
        /// <summary>
        /// Default language
        /// </summary>
        public Language Language { init; get; }

        /// <summary>
        /// Currency code
        /// </summary>
        public string CurrencyCode { init; get; }

        /// <summary>
        /// Currency symbol
        /// </summary>
        public string CurrencySymbol { init; get; }

        /// <summary>
        /// Whether the currency code is located in front of it
        /// </summary>
        public bool PlaceBeforeCurrencyCode { init; get; }

        /// <summary>
        /// Currency format
        /// </summary>
        public string CurrencyFormat { init; get; }

        public string? Description { init; get; }

        public CountryAttribute(Language language, string currencyCode, string currencySymbol, bool placeBeforeCurrencyCode, string currencyFormat, string? description = null)
        {
            Language = language;
            CurrencyCode = currencyCode;
            CurrencySymbol = currencySymbol;
            PlaceBeforeCurrencyCode = placeBeforeCurrencyCode;
            CurrencyFormat = currencyFormat;
            Description = description;
        }
    }
}
