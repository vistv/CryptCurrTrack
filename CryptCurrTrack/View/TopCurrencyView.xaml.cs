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

 //       public event EventHandler ListItemDoublecliked;

 //       public string itemClickedRank;
        //private void MakeListItemDoublecliked(EventArgs e)
        //{
        //    if (ListItemDoublecliked != null)
        //    {
        //        ListItemDoublecliked(this, e);
        //    }
        //}
        public TopCurrencyView()
        {
            InitializeComponent();

            _viewModel = new MainWindow_ViewModel();

            DataContext = _viewModel;
            _viewModel.Initialize();
        }

        void ListView_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (((FrameworkElement)e.OriginalSource).DataContext as MainWindow_Model != null)
            {
                ((MainWindow)System.Windows.Application.Current.MainWindow).OpenCurrencyDetailWindow((((FrameworkElement)e.OriginalSource).DataContext as CurrencyShortDetails).Rank, _viewModel.GetTopCurrenciesList());
            }
        }

        private void onSearchButton_Click(object sender, RoutedEventArgs e)
        {
            _viewModel.Search("");
        }

        private void onClearButton_Click(object sender, RoutedEventArgs e)
        {
           // _viewModel.Clear();
        }




    }
}
