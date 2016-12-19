using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using kursach.BLL.DTO;
using kursach.BLL.Infrastructure;
using kursach.BLL.Interfaces;
using kursach.Controls.DetailedInfo;
using kursach.Models;
using kursach.Util;
using Ninject;
using AutoMapper;
using System.Collections.Generic;
using System.ComponentModel;

namespace kursach.Controls
{
    /// <summary>
    ///     Interaction logic for ManagementControl.xaml
    /// </summary>
    public partial class ManagementControl : UserControl
    {
        public enum Desire { Department, Worker, Staff }
        private IDepartmentService deps;
        private IWorkerService works;
        private IStaffService stafs;
        private Desire desiredBehaviour;
        public ManagementControl(Desire d)
        {
            desiredBehaviour = d;
            IKernel k = new StandardKernel(new ServiceModule("CompanyConnection"), new MainModule());
            deps = k.Get<IDepartmentService>();
            works = k.Get<IWorkerService>();
            stafs = k.Get<IStaffService>();
            InitializeComponent();
        }
        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            Switcher.SwitchBack();
        }

        private void UserControl_Unloaded(object sender, RoutedEventArgs e)
        {
            deps.Dispose();
            works.Dispose();
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                switch (desiredBehaviour)
                {
                    case Desire.Department:
                        InfoGrid.ItemsSource = Mapper.Map<IEnumerable<DepartmentDTO>, IEnumerable<DepartmentViewModel>>(deps.GetAllDepartments());
                        break;
                    case Desire.Worker:
                        InfoGrid.ItemsSource = Mapper.Map<IEnumerable<WorkerDTO>, IEnumerable<WorkerViewModel>>(works.GetAllWorkers());
                        break;
                    case Desire.Staff:
                        InfoGrid.ItemsSource = Mapper.Map<IEnumerable<StaffDTO>, IEnumerable<StaffViewModel>>(stafs.GetAllStaff());
                        break;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
                Window.GetWindow(this).Cursor = Cursors.Arrow;
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            new DetailedInfoWindow(new AddControl(desiredBehaviour)).ShowDialog();
        }

        private void InfoGrid_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            switch (desiredBehaviour)
            {
                case Desire.Worker:
                    new DetailedInfoWindow(new InfoControl(((WorkerViewModel)InfoGrid.SelectedItem))).ShowDialog();
                    break;
                case Desire.Department:
                    new DetailedInfoWindow(new InfoMultiControl(((DepartmentViewModel)InfoGrid.SelectedItem))).ShowDialog();
                    break;
            }
        }

        private void RemoveButton_Click(object sender, RoutedEventArgs e)
        {
            if (InfoGrid.SelectedItem != null)
                works.RemoveWorker(((WorkerViewModel)InfoGrid.SelectedItem).Id);

        }

        private void SmallExitButton_Click(object sender, RoutedEventArgs e)
        {
            Window.GetWindow(this)?.Close();
        }

        private void InfoGrid_AutoGeneratingColumn(object sender, DataGridAutoGeneratingColumnEventArgs e)
        {

            PropertyDescriptor propertyDescriptor = (PropertyDescriptor)e.PropertyDescriptor;
            e.Column.Header = propertyDescriptor.DisplayName;
            if (propertyDescriptor.DisplayName == "AssignedDepartmentId" || propertyDescriptor.DisplayName == "AssignedPositionId")
            {
                e.Cancel = true;
            }
        }
    }
}