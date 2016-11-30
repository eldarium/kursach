using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using kursach.Controls.DetailedInfo;

namespace kursach.Controls
{
    /// <summary>
    ///     Interaction logic for ManagementControl.xaml
    /// </summary>
    public partial class ManagementControl : UserControl
    {
        public enum ManagementType
        {
            Workers,
            Departments
        };

        private readonly DbContext _context;
        private readonly DetailedInfoWindow _helper;
        private readonly ManagementType _type;
        private Window upWin;

        public ManagementControl(ManagementType type)
        {
            _helper = new DetailedInfoWindow();
            _type = type;
            switch (type)
            {
                case ManagementType.Workers:
                    _context = new WorkerContext();
                    _context.Set<Worker>().LoadAsync();
                    break;
                case ManagementType.Departments:
                    _context = new DepartmentContext();
                    _context.Set<Department>().LoadAsync();
                    break;
            }
            InitializeComponent();
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            Switcher.SwitchBack();
        }

        private void UserControl_Unloaded(object sender, RoutedEventArgs e)
        {
            _context.Dispose();
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            upWin = Window.GetWindow(this);
            try
            {
                switch (_type)
                {
                    case ManagementType.Workers:
                        InfoGrid.ItemsSource = _context.Set<Worker>().Local.ToBindingList();
                        break;
                    case ManagementType.Departments:
                        InfoGrid.ItemsSource = _context.Set<Department>().Local.ToBindingList();
                        break;
                }
            }
            catch
            {
                MessageBox.Show("Error connecting to the db!");
            }
            upWin.Cursor = Cursors.Arrow;
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            _helper.Init(DetailedInfoWindow.Desire.Add);
            _helper.ShowDialog();
        }

        private void InfoGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            RemoveButton.IsEnabled = true;
        }

        private void InfoGrid_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            _helper.AddInfo((CompanyEntity) InfoGrid.SelectedItem);
            _helper.Init(DetailedInfoWindow.Desire.Info);
        }

        private void RemoveButton_Click(object sender, RoutedEventArgs e)
        {
            switch (_type)
            {
                case ManagementType.Workers:
                    MainWorker.RemoveWorker((Worker) InfoGrid.SelectedItem);
                    break;
                case ManagementType.Departments:
                    _context.Set<Department>().Remove((Department) InfoGrid.SelectedItem);
                    break;
            }
        }

        private void SmallExitButton_Click(object sender, RoutedEventArgs e)
        {
            Window.GetWindow(this)?.Close();
        }
    }
}