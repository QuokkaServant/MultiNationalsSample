using System.Reflection;
using System.Globalization;

namespace MultiNationalsSample.Converters
{
    public class CountryCurrencySymbolConverter : System.Windows.Data.IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is not Country country || typeof(Country).GetField(country.ToString())?.GetCustomAttribute(typeof(CountryAttribute)) is not CountryAttribute attribute)
                return System.Windows.DependencyProperty.UnsetValue;

            return attribute.CurrencySymbol;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
