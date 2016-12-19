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
using AutoMapper;
using kursach.BLL.DTO;
using kursach.Models;

namespace kursach.Controls.DetailedInfo
{
    /// <summary>
    /// Interaction logic for InfoStaffControl.xaml
    /// </summary>
    public partial class InfoStaffControl : UserControl
    {
        private StaffViewModel w;
        public InfoStaffControl()
        {
            InitializeComponent();
        }

        private void Button_KeyDown(object sender, KeyEventArgs e)
        {
            Window.GetWindow(this)?.Close();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

            Window.GetWindow(this)?.Close();
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            StaffBox.ItemsSource = w.AssignedWorkers;
            NameBox.Text =w.AssignedWorkers.OrderByDescending(x =>
            {
                decimal sum = x.WorkerProjects.Sum(projectViewModel => projectViewModel.Cost);
                return x.Age/(double) sum;
            }).First().ToString();
        }
    }
}
