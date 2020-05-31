using System.Windows;

namespace Evan.Wpf.Sample
{
    public class Model : DependencyObject
    {
        public static readonly DependencyProperty TitleProperty = DependencyHelper.Register();

        public string Title
        {
            get => this.GetValue<string>(TitleProperty);
            set => SetValue(TitleProperty, value);
        }
    }
}
