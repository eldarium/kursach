using System.Windows.Controls;
using kursach.Models;

namespace kursach.Controls.DetailedInfo
{
    /// <summary>
    ///     Interaction logic for RemoveControl.xaml
    /// </summary>
    public partial class InfoControl : UserControl
    {
        DepartmentViewModel department;
        WorkerViewModel worker;
        public InfoControl(DepartmentViewModel d)
        {
            department = d;
            InitializeComponent();
        }
        public InfoControl(WorkerViewModel w)
        {
            worker = w;
            InitializeComponent();
        }
    }
}