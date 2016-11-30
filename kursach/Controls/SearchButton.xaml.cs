using System;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media.Animation;

namespace kursach.Controls
{
    /// <summary>
    ///     Interaction logic for SearchButton.xaml
    /// </summary>
    public partial class SearchButton : UserControl
    {
        private readonly DoubleAnimation _oa, _oc;

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