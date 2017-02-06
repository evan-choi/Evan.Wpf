using System;
using System.Windows;

namespace WPFExtension.Sample
{
    public class Model : DependencyObjectEx
    {
        public static readonly DependencyProperty TitleProperty =
            DependencyHelper.Register();
       
        public string Title
        {
            get { return GetValue<string>(TitleProperty); }
            set { SetValue(TitleProperty, value); }
        }
    }
}
