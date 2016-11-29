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
using System.Windows.Shapes;
using kursach.Controls.Detailed_Info;

namespace kursach
{
    /// <summary>
    /// Interaction logic for DetailedInfoWindow.xaml
    /// </summary>
    public partial class DetailedInfoWindow : Window
    {
        public enum Desire { Add, Info}
        public DetailedInfoWindow()
        {
            WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;
            InitializeComponent();
        }

        private CompanyEntity _info;

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
