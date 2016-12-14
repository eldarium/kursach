using System;
using System.Windows;
using System.Windows.Controls;

namespace kursach.Controls.DetailedInfo
{
    /// <summary>
    ///     Interaction logic for AddControl.xaml
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
        }
    }
}