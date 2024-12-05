using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartAgro.Converters
{
    public class CategoryConverter : IValueConverter
    {
        public object? Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            var id = (int)value;

            switch (id)
            {
                case 1: return "Tubérculo";
                case 2: return "Cereal";
                case 3: return "Fruto";
                case 4: return "Verdura";
                case 5: return "Raiz";
                    default: return "Sem categoria";
            }
        }

        public object? ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
