using WPFExtension;
using System.Windows;
using System;

namespace WPFExtension.Sample
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            var model = new Model()
            {
                Title = "Hello Depedency Helper!"
            };

            this.DataContext = model;

            Model.TitleProperty.AddValueChanged(model, TitlePropertyChanged);

            this.Text = "A piece of text";
        }


        public static DependencyProperty TextProperty = DependencyHelper.Register();

        public string Text
        {
            get { return (string)GetValue(TextProperty); }
            set { SetValue(TextProperty, value); }
        }

        private void TitlePropertyChanged(object sender, EventArgs e)
        {
            Console.WriteLine("Changed");
        }
    }
}
