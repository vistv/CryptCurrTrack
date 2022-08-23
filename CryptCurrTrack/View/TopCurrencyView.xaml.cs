using CryptCurrTrack.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace CryptCurrTrack.View
{
    
    public partial class TopCurrencyView : Page
    {
        private readonly MainWindow_ViewModel _viewModel;

        public TopCurrencyView()
        {
            InitializeComponent();

            _viewModel = new MainWindow_ViewModel();

            DataContext = _viewModel;
            _viewModel.Initialize();
        }

        void ListView_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (((FrameworkElement)e.OriginalSource).DataContext as CurrencyShortDetails != null)
            {
                ((MainWindow)System.Windows.Application.Current.MainWindow).OpenCurrencyDetailWindow((((FrameworkElement)e.OriginalSource).DataContext as CurrencyShortDetails).Rank, _viewModel.GetTopCurrenciesList());
            }
        }

        private void OnSearchButton_Click(object sender, RoutedEventArgs e)
        {
            _viewModel.Search(SearchTextBox.Text);
            GridLabel.Content = "Search results:";
        }

        private void OnClearButton_Click(object sender, RoutedEventArgs e)
        {
            SearchTextBox.Text = "";
           _viewModel.Clear();
            GridLabel.Content = "Top currencies top list:";

        }


    }
}
