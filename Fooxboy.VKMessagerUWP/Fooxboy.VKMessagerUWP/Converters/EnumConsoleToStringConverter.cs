using Fooxboy.VKMessagerUWP.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Data;

namespace Fooxboy.VKMessagerUWP.Converters
{
    public class EnumConsoleToStringConverter: IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            var type = (TypeLog)value;
            if (type == TypeLog.Error) return "[ERROR]";
            else if (type == TypeLog.Info) return "[INFO]";
            else if (type == TypeLog.Json) return "[JSON]";
            else if (type == TypeLog.Waring) return "[WARING]";
            else return "[UNKNOWN]";
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            var str = (string)value;
            if (str == "[ERROR]") return TypeLog.Error;
            else if (str == "[INFO]") return TypeLog.Info;
            else if (str == "[JSON]") return TypeLog.Json;
            else if (str == "[WARING]") return TypeLog.Waring;
            else return null;
        }
    }
}
