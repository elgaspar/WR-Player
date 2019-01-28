using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Markup;

namespace WR_Player.Views.Converters
{
    class SecondsToStringConverter : MarkupExtension, IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            int seconds = (int)value;

            if (seconds == -1)
                return "";

            TimeSpan ts = new TimeSpan(0, 0, seconds);
            int hours = ts.Hours;
            if (hours > 0)
                return string.Format("{0:h\\:mm\\:ss}", ts);
            else
                return string.Format("{0:m\\:ss}", ts);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }

        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            return this;
        }
    }
}
