using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Data;

namespace Fooxboy.VKMessagerUWP.Converters
{
    public class DateTimeLogToStringConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            var date = (DateTime)value;
            return  $"({date.Hour}:{date.Minute}:{date.Second})";
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            return DateTime.Now;
        }
    }
}
