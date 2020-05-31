using System.Windows;

namespace Evan.Wpf
{
    public static class DependencyObjectExtension
    {
        public static T GetValue<T>(this DependencyObject obj, DependencyProperty property)
        {
            return (T)obj.GetValue(property);
        }
    }
}