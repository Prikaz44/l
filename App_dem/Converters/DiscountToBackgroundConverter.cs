using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Media;

namespace App_dem.Converters
{
    // Конвертер для фона скидки (>15%)
    public class DiscountToBackgroundConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            try
            {
                if (value != null)
                {
                    if (value != null && int.TryParse(value.ToString(), out int discount))
                    {
                        if (discount > 15)
                        {
                            return new SolidColorBrush((Color)ColorConverter.ConvertFromString("#2E8B57"));
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Ошибка в конвертере: {ex.Message}");
            }

            return Brushes.Transparent;
            //return Brushes.Black;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }

    // Конвертер для цвета строки (если товара нет на складе)
    public class StockToBackgroundConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            try
            {
                if (value != null && int.TryParse(value.ToString(), out int stock))
                {
                    if (stock == 0)
                    {
                        return new SolidColorBrush(Colors.LightBlue);
                    }
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Ошибка в конвертере: {ex.Message}");
            }

            return Brushes.Transparent;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
