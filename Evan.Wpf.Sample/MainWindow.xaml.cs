using Evan.Wpf;
using System.Windows;
using System;

namespace Evan.Wpf.Sample
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
        }

        private void TitlePropertyChanged(object sender, EventArgs e)
        {
            Console.WriteLine("Changed");
        }
    }
}
