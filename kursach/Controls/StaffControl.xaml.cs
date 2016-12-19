using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using kursach.BLL.DTO;
using kursach.BLL.Infrastructure;
using kursach.BLL.Interfaces;
using kursach.Models;
using kursach.Util;
using Ninject;

namespace kursach.Controls
{
    /// <summary>
    /// Interaction logic for StaffControl.xaml
    /// </summary>
    public partial class StaffControl : UserControl
    {
        private IStaffService s;
        public StaffControl()
        {
            InitializeComponent();
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            IKernel k = new StandardKernel(new ServiceModule("CompanyConnection"), new MainModule());
            s = k.Get<IStaffService>();
            AllStafGrid.ItemsSource = AutoMapper.Mapper.Map<IEnumerable<StaffDTO>,IEnumerable<StaffViewModel>>(s.GetAllStaff());
            CoolStaffGrid.ItemsSource = AutoMapper.Mapper.Map<IEnumerable<StaffDTO>, IEnumerable<StaffViewModel>>(s.GetAllStaff()).OrderBy(x=>x.Salary/x.WorkTime);
        }
        private void StafGrid_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {

        }
    }
}
