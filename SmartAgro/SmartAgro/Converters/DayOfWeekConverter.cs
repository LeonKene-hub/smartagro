using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartAgro.Converters
{
    public class DayOfWeekConverter : IValueConverter
    {
        public object? Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            if (value is DateTime date)
            {
                culture = new CultureInfo("pt-BR");

                string dayOfWeek = date.ToString("ddd", culture);
                return char.ToUpper(dayOfWeek[0]).ToString() + dayOfWeek[1] + dayOfWeek[2];

            }
            return value;
        }

        public object? ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
