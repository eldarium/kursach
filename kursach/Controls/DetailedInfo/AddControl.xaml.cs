using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using AutoMapper;
using kursach.BLL.DTO;
using kursach.BLL.Infrastructure;
using kursach.BLL.Interfaces;
using kursach.Models;
using kursach.Util;
using Ninject;

namespace kursach.Controls.DetailedInfo
{
    /// <summary>
    ///     Interaction logic for AddControl.xaml
    /// </summary>
    public partial class AddControl : UserControl
    {
        private IDepartmentService deps;
        private IWorkerService works;
        private ManagementControl.Desire desire;
        IStaffService stafs;
        public AddControl(ManagementControl.Desire desire)
        {
            IKernel k = new StandardKernel(new ServiceModule("CompanyConnection"), new MainModule());
            deps = k.Get<IDepartmentService>();
            works = k.Get<IWorkerService>();
             stafs = k.Get<IStaffService>();
            this.desire = desire;
            InitializeComponent();
            foreach (var department in deps.GetAllDepartments())
            {
                DepartmentBox.Items.Add(AutoMapper.Mapper.Map<DepartmentDTO,DepartmentViewModel> (department));
            }
            foreach (var staf in stafs.GetAllStaff())
            {
                StaffBox.Items.Add(AutoMapper.Mapper.Map<StaffDTO, StaffViewModel>(staf));
            }
            if (desire != ManagementControl.Desire.Department) {  return; }
            SurnamePanel.Visibility = Visibility.Hidden;
            BankPanel.Visibility = Visibility.Hidden;
            DepartmentPanel.Visibility = Visibility.Hidden;
            StaffPanel.Visibility = Visibility.Hidden;
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Window.GetWindow(this)?.Close();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            switch (desire)
            {
                case ManagementControl.Desire.Worker:
                    try
                    {
                        if(NameBox.Text.Count(x=>Char.IsDigit(x))!=0 || SurnameBox.Text.Count(x=>Char.IsDigit(x))!=0)
                            throw new Exception("В імені та призвищі не може бути цифр");
                        var d = Mapper.Map<DepartmentViewModel, DepartmentDTO>((DepartmentViewModel)DepartmentBox.SelectedItem);
                        var s = Mapper.Map<StaffViewModel, StaffDTO>((StaffViewModel) StaffBox.SelectedItem);
                        works.AddWorker(new WorkerDTO
                        {
                            AssignedDepartment = deps.GetDepartment(d.Id),
                            AssignedDepartmentId = d.Id,
                            AssignedPosition = stafs.GetAllStaff().First(x=>x.Id==s.Id),
                            AssignedPositionId = s.Id,
                            StartDate = DateTime.Today,
                            BankAccount = Convert.ToInt64(BankBox.Text),
                            Name = NameBox.Text,
                            Surname = SurnameBox.Text
                        });
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                    break;
                    case ManagementControl.Desire.Department:
                    try
                    {
                        deps.AddDepartment(new DepartmentDTO
                        {
                            Name = NameBox.Text
                        });
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                    break;
            }
            Window.GetWindow(this)?.Close();
        }
        
    }
}