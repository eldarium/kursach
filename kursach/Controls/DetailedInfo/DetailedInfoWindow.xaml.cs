using System.Windows;
using System.Windows.Controls;

namespace kursach.Controls.DetailedInfo
{
    /// <summary>
    ///     Interaction logic for DetailedInfoWindow.xaml
    /// </summary>
    public partial class DetailedInfoWindow : Window
    {

        public DetailedInfoWindow(UserControl c)
        {
            WindowStartupLocation = WindowStartupLocation.CenterScreen;
            InitializeComponent();
            Content = c;
        }

    }
}