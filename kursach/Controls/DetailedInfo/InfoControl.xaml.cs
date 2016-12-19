using System;
using System.Windows;
using System.Windows.Controls;
using kursach.Models;

namespace kursach.Controls.DetailedInfo
{
    /// <summary>
    ///     Interaction logic for RemoveControl.xaml
    /// </summary>
    public partial class InfoControl : UserControl
    {
        WorkerViewModel worker;
        public InfoControl(WorkerViewModel w)
        {
            worker = w;
            InitializeComponent();
        }

        private void Button_KeyDown(object sender, System.Windows.Input.KeyEventArgs e)
        {
            Window.GetWindow(this)?.Close();
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            NameBox.Text = worker.Name;
            SurnameBox.Text = worker.Surname;
            BankBox.Text = Convert.ToString(worker.BankAccount);
            DepartmentBox.Text = worker.AssignedDepartment.ToString();
            StaffBox.Text = worker.AssignedPosition.ToString();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Window.GetWindow(this)?.Close();

        }
    }
}