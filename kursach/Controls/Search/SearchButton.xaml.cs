using System;
using System.Linq;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media.Animation;
using kursach.BLL.Infrastructure;
using kursach.BLL.Interfaces;
using kursach.Controls.DetailedInfo;
using kursach.Models;
using kursach.Util;
using Ninject;

namespace kursach.Controls.Search
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
        }
        

        private void Button_KeyDown(object sender, KeyEventArgs e)
        {
            String tosearch = SearchBox.Text;
            switch (SearchScopeBox.SelectedIndex)
            {
                case 0:
                    var k = from d in works.GetAllWorkers()
                            where
Convert.ToString(d.Id).Contains(tosearch) || d.Name.Contains(tosearch) || d.Surname.Contains(tosearch) || Convert.ToString(d.BankAccount).Contains(tosearch)
                            select d;
                    new DetailedInfoWindow(new SearchRsultControl(new SearchResult(typeof (WorkerViewModel), k)))
                        .ShowDialog();
                    break;
                case 1:
                    var r = from d in deps.GetAllDepartments()
                            where
Convert.ToString(d.Id).Contains(tosearch) || d.Name.Contains(tosearch)
                            select d;
                    new DetailedInfoWindow(new SearchRsultControl(new SearchResult(typeof(DepartmentViewModel), r)))
                        .ShowDialog();
                    break;
                case 2:
                    var m = from d in stafs.GetAllStaff()
                            where
Convert.ToString(d.Id).Contains(tosearch) || d.Name.Contains(tosearch)
                            select d;
                    new DetailedInfoWindow(new SearchRsultControl(new SearchResult(typeof(StaffViewModel), m)))
                        .ShowDialog();
                    break;
                case 3:
                    var l = from d in projs.GetAllProjects()
                            where
Convert.ToString(d.Id).Contains(tosearch) || d.Name.Contains(tosearch) || Convert.ToString(d.Cost).Contains(tosearch)
                            select d;
                    new DetailedInfoWindow(new SearchRsultControl(new SearchResult(typeof(ProjectViewModel), l)))
                        .ShowDialog();
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