using System;
using System.Windows;
using System.Windows.Controls;
using kursach.BLL.Interfaces;

namespace kursach.Controls.DetailedInfo
{
    /// <summary>
    ///     Interaction logic for AddControl.xaml
    /// </summary>
    public partial class AddControl : UserControl
    {
        private IDepartmentService deps;
        private IWorkerService works;
        public AddControl( IDepartmentService deps)
        {
            this.deps = deps;
            InitializeComponent();
        }
        public AddControl(IWorkerService works)
        {
            this.works = works;
            InitializeComponent();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Window.GetWindow(this)?.Close();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
        }
    }
}