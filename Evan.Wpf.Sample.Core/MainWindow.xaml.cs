using System.Windows;
using System;

namespace Evan.Wpf.Sample.Core
{
    public partial class MainWindow
    {
        public MainWindow()
        {
            InitializeComponent();

            var model = new Model()
            {
                Title = "Hello Depedency Helper!"
            };

            DataContext = model;

            Model.TitleProperty.AddValueChanged(model, TitlePropertyChanged);

            Text = "A piece of text";
        }

        public static readonly DependencyProperty TextProperty = DependencyHelper.Register();

        public string Text
        {
            get => (string)GetValue(TextProperty);
            set => SetValue(TextProperty, value);
        }

        private void TitlePropertyChanged(object sender, EventArgs e)
        {
            Console.WriteLine("Changed");
        }
    }
}
