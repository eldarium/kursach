using System.Collections.Generic;
using System.Windows.Controls;

namespace kursach
{
    internal class Switcher
    {
        private static readonly Stack<UserControl> History;

        static Switcher()
        {
            History = new Stack<UserControl>();
        }

        public static MainWindow PageSwitcher { private get; set; }

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