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
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace kursach.Controls
{
    /// <summary>
    /// Interaction logic for SearchButton.xaml
    /// </summary>
    public partial class SearchButton : UserControl
    {
        readonly DoubleAnimation _oa, _oc;
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
        }
        
        private void SearchButton_MouseEnter(object sender, MouseEventArgs e)
        {
            SearchScopeBox.BeginAnimation(WidthProperty, _oc);
           SearchBox.BeginAnimation(WidthProperty, _oa);
        }

        private void SearchButton_MouseLeave(object sender, MouseEventArgs e)
        {
            DoubleAnimation ob = new DoubleAnimation
            {
                From = SearchBox.Width,
                To = 0,
                Duration = TimeSpan.FromSeconds(0.2)
            };
            DoubleAnimation od = new DoubleAnimation
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
