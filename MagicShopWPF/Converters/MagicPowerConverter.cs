using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace MagicShopWPF.Converters
{
    internal class MagicPowerConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            int filename = int.Parse(value.ToString());
            if (filename >= 1 && filename <= 19)
            {
                return "#";
            }
            else if (filename >= 20 && filename <= 39)
            {
                return "##";
            }
            else if (filename >= 40 && filename <= 59)
            {
                return "###";
            }
            else if (filename >= 60 && filename <= 79)
            {
                return "####";
            }
            else if (filename >= 80 && filename <= 99)
            {
                return "#####";
            }
            else if (filename >= 100)
            {
                return "######";
            }
            else
                return "";
          
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
