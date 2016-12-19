using System.Windows.Controls;
using kursach.Controls.DetailedInfo;
using kursach.Models;

namespace kursach.Controls.Search
{
    /// <summary>
    /// Interaction logic for SearchRsultControl.xaml
    /// </summary>
    public partial class SearchRsultControl : UserControl
    {
        private SearchResult result;
        public SearchRsultControl(SearchResult s)
        {
            InitializeComponent();
            result = s;
        }

        private void UserControl_Loaded(object sender, System.Windows.RoutedEventArgs e)
        {
            foreach (var v in result.Result)
            {
                ResultsView.Items.Add(v.ToString());
            }
        }
        
    }
}
