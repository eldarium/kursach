using System;
using System.Windows;
using System.Windows.Controls;
using Menu = kursach.Controls.Menu;

namespace kursach
{
    /// <summary>
    ///     Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            WindowStartupLocation = WindowStartupLocation.CenterScreen;
            Switcher.PageSwitcher = this;
            Switcher.Switch(new Menu());
        }

        public void Navigate(UserControl nextPage) => Content = nextPage;

        public void Navigate(UserControl nextPage, object state)
        {
            Content = nextPage;
            var s = nextPage as ISwitchable;

            if (s != null)
                s.UtilizeState(state);
            else
                throw new ArgumentException("NextPage is not ISwitchable! "
                                            + nextPage.Name);
        }
    }
}