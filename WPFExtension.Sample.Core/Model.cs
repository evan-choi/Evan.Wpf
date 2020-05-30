using System;
using System.Windows;

namespace WPFExtension.Sample
{
    public class Model : DependencyObject
    {
        public static readonly DependencyProperty TitleProperty =
            DependencyHelper.Register();
       
        public string Title
        {
            get { return this.GetValue<string>(TitleProperty); }
            set { SetValue(TitleProperty, value); }
        }
    }
}
