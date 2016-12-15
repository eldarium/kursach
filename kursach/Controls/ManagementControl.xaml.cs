using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using kursach.BLL.DTO;
using kursach.BLL.Infrastructure;
using kursach.BLL.Interfaces;
using kursach.BLL.Services;
using kursach.Controls.DetailedInfo;
using kursach.Models;
using kursach.Util;
using Ninject;

namespace kursach.Controls
{
    /// <summary>
    ///     Interaction logic for ManagementControl.xaml
    /// </summary>
    public partial class ManagementControl : UserControl
    {
        public enum Desire { Department, Worker, Staff}
        private IDepartmentService deps;
        private IWorkerService works;
        private IStaffService staffs;
        private Desire desiredBehaviour;
        public ManagementControl(Desire d)
        {
            desiredBehaviour = d;
            IKernel k = new StandardKernel(new ServiceModule("CompanyConnection"), new MainModule());
            deps = k.Get<IDepartmentService>();
            works = k.Get<IWorkerService>();
            staffs = k.Get<IStaffService>();
            InitializeComponent();
        }
        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            Switcher.SwitchBack();
        }

        private void UserControl_Unloaded(object sender, RoutedEventArgs e)
        {
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                switch (desiredBehaviour)
                {
                    case Desire.Department:
                        InfoGrid.ItemsSource = deps.GetAllDepartments();
                        break;
                    case Desire.Worker:
                        RemoveButton.Visibility = Visibility.Visible;
                        RemoveButton.IsEnabled = true;
                        works.AddWorker(new WorkerDTO {Name = "k", Surname = "j", AssignedDepartment = new DepartmentDTO() { Name = "1"}, AssignedPosition = new StaffDTO() {Name = "sd", Salary = 252, StaffId = 23, WorkTime = 152}, BankAccount = 5354534, Projects = null});
                        InfoGrid.ItemsSource = works.GetAllWorkers();
                        break;
                }
                Window.GetWindow(this).Cursor = Cursors.Arrow;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.InnerException.Message);
            }
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            switch (desiredBehaviour)
            {
                    case Desire.Worker:
                    new DetailedInfoWindow(new AddControl(works)).ShowDialog();
                    break;
                case Desire.Department:
                    new DetailedInfoWindow(new AddControl(deps)).ShowDialog();
                    break;
            }
        }

        private void InfoGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
        }

        private void InfoGrid_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            MessageBox.Show(Convert.ToString(((WorkerViewModel) InfoGrid.SelectedItem).WorkerId));
        }

        private void RemoveButton_Click(object sender, RoutedEventArgs e)
        {
            if(InfoGrid.SelectedItem != null)
                works.RemoveWorker(((WorkerViewModel) InfoGrid.SelectedItem).WorkerId);
        }

        private void SmallExitButton_Click(object sender, RoutedEventArgs e)
        {
            Window.GetWindow(this)?.Close();
        }
    }
}