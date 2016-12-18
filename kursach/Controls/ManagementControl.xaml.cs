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
        private Desire desiredBehaviour;
        public ManagementControl(Desire d)
        {
            desiredBehaviour = d;
            IKernel k = new StandardKernel(new ServiceModule("CompanyConnection"), new MainModule());
            deps = k.Get<IDepartmentService>();
            works = k.Get<IWorkerService>();
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
                        InfoGrid.ItemsSource = deps.GetAllDepartments();
                        break;
                    case Desire.Worker:
                        var w = works.GetAllWorkers();
                        Mapper.Initialize(cfg =>
                        {
                            cfg.CreateMap<WorkerDTO, WorkerViewModel>();
                            cfg.CreateMap<DepartmentDTO, DepartmentViewModel>();
                            cfg.CreateMap<StaffDTO, StaffViewModel>();
                            cfg.CreateMap<ProjectDTO, ProjectViewModel>();
                            cfg.CreateMap<WorkerDTO, WorkerViewModel>().ReverseMap();
                            cfg.CreateMap<DepartmentDTO, DepartmentViewModel>().ReverseMap();
                            cfg.CreateMap<StaffDTO, StaffViewModel>().ReverseMap();
                            cfg.CreateMap<ProjectDTO, ProjectViewModel>().ReverseMap();
                        });
                        InfoGrid.ItemsSource = Mapper.Map<IEnumerable<WorkerDTO>,IEnumerable<WorkerViewModel>>(w);
                        break;
                }
                Window.GetWindow(this).Cursor = Cursors.Arrow;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
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
         
        private void InfoGrid_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            switch (desiredBehaviour)
            {
                case Desire.Worker:
                    new DetailedInfoWindow(new InfoControl(((WorkerViewModel)InfoGrid.SelectedItem))).ShowDialog();
                    break;
            }
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