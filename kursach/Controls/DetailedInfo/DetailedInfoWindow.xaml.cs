using System.Windows;

namespace kursach.Controls.DetailedInfo
{
    /// <summary>
    ///     Interaction logic for DetailedInfoWindow.xaml
    /// </summary>
    public partial class DetailedInfoWindow : Window
    {
        public enum Desire
        {
            Add,
            Info
        }

        private CompanyEntity _info;

        public DetailedInfoWindow()
        {
            WindowStartupLocation = WindowStartupLocation.CenterScreen;
            InitializeComponent();
        }

        public void Init(Desire d)
        {
            switch (d)
            {
                case Desire.Add:
                    Content = new AddControl();
                    break;
                case Desire.Info:
                    Content = new InfoControl();
                    break;
            }
        }

        public void AddInfo(CompanyEntity info)
        {
            _info = info;
        }
    }
}