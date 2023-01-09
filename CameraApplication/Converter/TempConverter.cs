using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace CameraApplication.Converter
{
    public class TempConverter : IValueConverter
    {
        public TempConverter()
        {

        }

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var 결과값 = value as string;

            if (결과값 is null)
                결과값 = ((int)value).ToString("N0");

            if (결과값 is "0")
                결과값 = "";

            return 결과값;
        }

        // 작업전
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value;
        }
    }

}
