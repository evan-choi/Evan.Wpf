using System.Windows;

namespace WPFExtension
{
    public static class DependencyObjectEx
    {
        public static T GetValue<T>(this DependencyObject obj, DependencyProperty property)
        {
            return (T)obj.GetValue(property);
        }
    }
}