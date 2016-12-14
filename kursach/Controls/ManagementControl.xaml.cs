using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using kursach.Controls.DetailedInfo;

namespace kursach.Controls
{
    /// <summary>
    ///     Interaction logic for ManagementControl.xaml
    /// </summary>
    public partial class ManagementControl : UserControl
    {
        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            Switcher.SwitchBack();
        }

        private void UserControl_Unloaded(object sender, RoutedEventArgs e)
        {
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
        }

        private void InfoGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
        }

        private void InfoGrid_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
        }

        private void RemoveButton_Click(object sender, RoutedEventArgs e)
        {
        }

        private void SmallExitButton_Click(object sender, RoutedEventArgs e)
        {
            Window.GetWindow(this)?.Close();
        }
    }
}