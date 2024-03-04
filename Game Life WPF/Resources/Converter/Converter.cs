using System.Globalization;
using System.Windows.Data;
using System.Windows.Media;
using System.Drawing;
using System.Windows;

namespace Game_Life_WPF.Resources.Converter
{
    public class ColorToBrushConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is System.Windows.Media.Color color)
            {
                return new SolidColorBrush(color);
            }
            return Binding.DoNothing;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return Binding.DoNothing;
        }
    }

    public class DrawingColorToMediaColorConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is System.Drawing.Color drawingColor)
            {
                return System.Windows.Media.Color.FromArgb(drawingColor.A, drawingColor.R, drawingColor.G, drawingColor.B);
            }
            return DependencyProperty.UnsetValue;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is System.Windows.Media.Color drawingColor)
            {
                return System.Drawing.Color.FromArgb(drawingColor.A, drawingColor.R, drawingColor.G, drawingColor.B);
            }
            return Binding.DoNothing;
        }
    }
}
