using System;
using System.Windows.Data;

namespace Measures.Helper
{
    public class DoubleStringConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            double dbl;
            string str = (string)value;
            if (string.IsNullOrEmpty(str))
            {
                return string.Empty;
            }
            else if (double.TryParse(value.ToString(), out dbl))
                return dbl;
            else
                return value;
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            return value;
        }
    }
}
