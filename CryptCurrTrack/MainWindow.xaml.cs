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
using System.Windows.Navigation;
using System.Windows.Shapes;
using CryptCurrTrack.View;

namespace CryptCurrTrack
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        private Page topCurrencyView;
        
        private Page exchangeView;
        public MainWindow()
        {
            InitializeComponent();
            if (topCurrencyView == null) topCurrencyView = new TopCurrencyView();
            Main.Content = topCurrencyView;
            MainButton.Visibility = Visibility.Collapsed;
        }

        private void ButtonMain_Click(object sender, RoutedEventArgs e)
        {
            
            if (topCurrencyView == null) topCurrencyView = new TopCurrencyView();
            Main.Content = topCurrencyView;
            ExchangeButton.Visibility = Visibility.Visible;
            MainButton.Visibility = Visibility.Collapsed;
        }


        private void ButtonExchange_Click(object sender, RoutedEventArgs e)
        {
            if (exchangeView == null) exchangeView = new ExchangeView();
            Main.Content = exchangeView;
            MainButton.Visibility = Visibility.Visible;
            ExchangeButton.Visibility = Visibility.Collapsed;

        }

        public void OpenCurrencyDetailWindow(string itemClickedRank, TopCurrenciesList currencyInfo)
        {
            Page currencyDetailView = new CurrencyDetailView(itemClickedRank, currencyInfo);
            Main.Content = currencyDetailView;
            ExchangeButton.Visibility = Visibility.Visible;
            MainButton.Visibility = Visibility.Visible;
        }

        
    }
}
