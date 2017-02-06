using System.Windows;

namespace WPFExtension
{
    public class DependencyObjectEx : DependencyObject
    {
        protected T GetValue<T>(DependencyProperty property)
        {
            return (T)base.GetValue(property);
        }
    }
}
