using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stopwatch.ViewModel
{
    using Windows.UI.Xaml.Data;

    class AngleConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            double parsedValue;
            if ((value != null)
                && double.TryParse(value.ToString(), out parsedValue)
                && (parameter != null))
                switch (parameter.ToString())
                {
                    case "Hours":
                        return parsedValue * 30;
                    case "Minutes":
                    case "Seconds":
                        return parsedValue * 6;
                }
            return 0;
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }
}
