using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace kursach.Controls
{
    /// <summary>
    /// Interaction logic for Menu.xaml
    /// </summary>
    public partial class Menu : UserControl, ISwitchable
    {
        private Window upWin;
        public Menu()
        {
            InitializeComponent();
        }

        private void ExitButton_Click(object sender, RoutedEventArgs e)
        {
            upWin?.Close();
        }
        

        public void UtilizeState(object state)
        {
            throw new NotImplementedException();
        }

        private void WorkersButton_Click(object sender, RoutedEventArgs e)
        {
            upWin.Cursor = Cursors.Wait;
            Switcher.Switch(new ManagementControl(ManagementControl.ManagementType.Workers));
        }

        private void DepartmentsButton_Click(object sender, RoutedEventArgs e)
        {
            upWin.Cursor = Cursors.Wait;
            Switcher.Switch(new ManagementControl(ManagementControl.ManagementType.Departments));
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            upWin = Window.GetWindow(this);
            upWin.Cursor = Cursors.Arrow;

        }
    }
}