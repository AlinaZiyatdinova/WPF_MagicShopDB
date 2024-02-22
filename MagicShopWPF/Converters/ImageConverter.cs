using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace MagicShopWPF.Converters
{
    internal class ImageConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            string filename = value.ToString().Trim().ToLower();
            if (filename == string.Empty)
            {
                return Environment.CurrentDirectory + @"\Images\no_photo.png";
            }
            return Environment.CurrentDirectory + @"\Images\" + filename;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
