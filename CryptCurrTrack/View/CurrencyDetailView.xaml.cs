using CryptCurrTrack.ViewModel;
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
    /// <summary>
    /// Interaction logic for CurrencuDetailView.xaml
    /// </summary>
    public partial class CurrencyDetailView : Page
    {

        private readonly CurrencyDetail_ViewModel viewModel;
        public CurrencyDetailView(string currencyId, TopCurrenciesList topCurrenciesList)
        {
            InitializeComponent();

            viewModel = new CurrencyDetail_ViewModel(currencyId, topCurrenciesList);

            DataContext = viewModel;
            viewModel.Initialize();
        }
    }
}
