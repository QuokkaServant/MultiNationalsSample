using System.Reflection;
using System.Globalization;

namespace MultiNationalsSample.Converters
{
    public class CurrencyFormatConverter : System.Windows.Data.IMultiValueConverter
    {
        public object? Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            if (values == null || values.Length != 2 ||
                values[0] is not double amount ||
                values[1] is not Country country || typeof(Country).GetField(country.ToString())?.GetCustomAttribute(typeof(CountryAttribute)) is not CountryAttribute attribute)
                return null;

            return amount.ToString(attribute.CurrencyFormat, culture.NumberFormat);
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
