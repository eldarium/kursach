using System;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media.Animation;
using kursach.BLL.Interfaces;
using kursach.BLL.Infrastructure;
using Ninject;
using kursach.Util;
using System.Linq;
namespace kursach.Controls
{
    /// <summary>
    ///     Interaction logic for SearchButton.xaml
    /// </summary>
    public partial class SearchButton : UserControl
    {
        private readonly DoubleAnimation _oa, _oc;
        private IWorkerService works;
        IDepartmentService deps;
        IStaffService stafs;
        IProjectService projs;
        public SearchButton()
        {
            InitializeComponent();
            _oa = new DoubleAnimation
            {
                From = SearchBox.Width,
                To = 200,
                Duration = TimeSpan.FromSeconds(0.2)
            };
            _oc = new DoubleAnimation
            {
                From = SearchScopeBox.Width,
                To = 100,
                Duration = TimeSpan.FromSeconds(0.2)
            };
            IKernel k = new StandardKernel(new ServiceModule("CompanyConnection"), new MainModule());
            deps = k.Get<IDepartmentService>();
            works = k.Get<IWorkerService>();
            stafs = k.Get<IStaffService>();
            projs = k.Get<IProjectService>();
        }

        private void SearchButton_MouseEnter(object sender, MouseEventArgs e)
        {
            SearchScopeBox.BeginAnimation(WidthProperty, _oc);
            SearchBox.BeginAnimation(WidthProperty, _oa);
            if (SearchScopeBox.HasItems) return;
            SearchScopeBox.Items.Add("робітники");
            SearchScopeBox.Items.Add("відділення");
            SearchScopeBox.Items.Add("посади");
            SearchScopeBox.Items.Add("проекти");
            SearchScopeBox.Items.Add("Розширений пошук...");
        }

        private void UserControl_Loaded(object sender, System.Windows.RoutedEventArgs e)
        {
        }

        private void Button_KeyDown(object sender, KeyEventArgs e)
        {
            String tosearch =(String) SearchScopeBox.SelectedItem;
            switch (SearchScopeBox.SelectedIndex)
            {
                case 0:
                    var k = from d in works.GetAllWorkers()
                            where
Convert.ToString(d.WorkerId).Contains(tosearch) || d.Name.Contains(tosearch) || d.Surname.Contains(tosearch) || Convert.ToString(d.BankAccount).Contains(tosearch)
                            select d;
                    break;
                case 1:
                    var r = from d in deps.GetAllDepartments()
                            where
Convert.ToString(d.DepartmentId).Contains(tosearch) || d.Name.Contains(tosearch)
                            select d;
                    break;
                case 2:
                    var m = from d in stafs.GetAllStaff()
                            where
Convert.ToString(d.StaffId).Contains(tosearch) || d.Name.Contains(tosearch)
                            select d;
                    break;
                case 3:
                    var l = from d in projs.GetAllProjects()
                            where
Convert.ToString(d.ProjectId).Contains(tosearch) || d.Name.Contains(tosearch) || Convert.ToString(d.Cost).Contains(tosearch)
                            select d;
                    break;
            }
        }

        private void SearchButton_MouseLeave(object sender, MouseEventArgs e)
        {
            var ob = new DoubleAnimation
            {
                From = SearchBox.Width,
                To = 0,
                Duration = TimeSpan.FromSeconds(0.2)
            };
            var od = new DoubleAnimation
            {
                From = SearchScopeBox.Width,
                To = 0,
                Duration = TimeSpan.FromSeconds(0.2)
            };
            SearchScopeBox.BeginAnimation(WidthProperty, od);
            SearchBox.BeginAnimation(WidthProperty, ob);
        }
    }
}