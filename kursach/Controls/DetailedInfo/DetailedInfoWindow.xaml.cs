using System.Windows;

namespace kursach.Controls.DetailedInfo
{
    /// <summary>
    ///     Interaction logic for DetailedInfoWindow.xaml
    /// </summary>
    public partial class DetailedInfoWindow : Window
    {

        public DetailedInfoWindow(AddControl c)
        {
            WindowStartupLocation = WindowStartupLocation.CenterScreen;
            InitializeComponent();
            Content = c;
        }
        
    }
}