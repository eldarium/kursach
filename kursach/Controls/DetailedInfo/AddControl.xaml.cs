using System;
using System.Windows;
using System.Windows.Controls;
using kursach.Classes;
using kursach.DataWorkers;

namespace kursach.Controls.DetailedInfo
{
    /// <summary>
    /// Interaction logic for AddControl.xaml
    /// </summary>
    public partial class AddControl : UserControl
    {
        public AddControl()
        {
            InitializeComponent();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Window.GetWindow(this)?.Close();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            MainWorker.AddWorker(new Worker(NameBox.Text, SurnameBox.Text,Convert.ToInt64(BankBox.Text), new Department("asdsad"),  new Staff("jtyjt")));
        }
    }
}
