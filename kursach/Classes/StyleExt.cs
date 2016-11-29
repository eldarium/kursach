using System.Windows;
using System.Windows.Media;

namespace kursach.Classes
{
    public class StyleExt
    {
        public static readonly DependencyProperty ColorProperty =
        DependencyProperty.RegisterAttached("Color", typeof(Color), typeof(StyleExt), new PropertyMetadata(Color.FromArgb(0,0,0,0)));

        public static void SetColor(DependencyObject element, Color value)
        {
            element.SetValue(ColorProperty, value);
        }

        public static Color GetColor(DependencyObject element)
        {
            return (Color)element.GetValue(ColorProperty);
        }
    }
}
