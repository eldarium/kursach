using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace kursach
{
    class Switcher
    {
        private static readonly Stack<UserControl> History; 
        public static MainWindow PageSwitcher { private get; set; }

        static Switcher()
        {
            History = new Stack<UserControl>();
        }

        public static void SwitchBack()
        {
            History.Pop();
            PageSwitcher.Navigate(History.Peek());
        }

        public static void Switch(UserControl newPage)
        {
            History.Push(newPage);
            PageSwitcher.Navigate(newPage);
        }

        public static void Switch(UserControl newPage, object state)
        {
            History.Push(newPage);
            PageSwitcher.Navigate(newPage, state);
        }
    }
}
