﻿using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using kursach.DataWorkers;
using Menu = kursach.Controls.Menu;

namespace kursach
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            
            WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;
            Switcher.PageSwitcher = this;
            Switcher.Switch(new Menu());
        }
        public void Navigate(UserControl nextPage) => Content = nextPage;

        public void Navigate(UserControl nextPage, object state)
        {
            Content = nextPage;
            ISwitchable s = nextPage as ISwitchable;

            if (s != null)
                s.UtilizeState(state);
            else
                throw new ArgumentException("NextPage is not ISwitchable! "
                  + nextPage.Name);
        }
    }
}