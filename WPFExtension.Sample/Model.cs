using System;
using System.Windows;

namespace WPFExtension.Sample
{
    public class Model : DependencyObject
    {
        public static readonly DependencyProperty TitleProperty =
            DependencyHelper.Register();

        private static void TitleChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
        }

        public string Title
        {
            get { return (string)GetValue(TitleProperty); }
            set { SetValue(TitleProperty, value); }
        }
    }
}
