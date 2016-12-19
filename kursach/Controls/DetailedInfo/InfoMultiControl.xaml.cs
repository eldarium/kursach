using System;
using System.Collections.Generic;
using System.ComponentModel;
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
using kursach.Models;

namespace kursach.Controls.DetailedInfo
{
    /// <summary>
    /// Interaction logic for InfoMultiControl.xaml
    /// </summary>
    public partial class InfoMultiControl : UserControl
    {
        DepartmentViewModel department;
        public InfoMultiControl(DepartmentViewModel d)
        {
            department = d;
            InitializeComponent();
        }

        private void StaffBox_AutoGeneratingColumn(object sender, DataGridAutoGeneratingColumnEventArgs e)
        {
            PropertyDescriptor propertyDescriptor = (PropertyDescriptor) e.PropertyDescriptor;
            e.Column.Header = propertyDescriptor.DisplayName;
            if (propertyDescriptor.DisplayName == "AssignedDepartmentId" || propertyDescriptor.DisplayName == "AssignedPositionId")
            {
                e.Cancel = true;
            }
        }

        private void Button_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Window.GetWindow(this)?.Close();

        }
    }
}
