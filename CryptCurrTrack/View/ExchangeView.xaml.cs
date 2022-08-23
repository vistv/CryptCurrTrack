using CryptCurrTrack.ViewModel;
using System;
using System.Collections.Generic;
using System.Globalization;
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
    /// Interaction logic for ExchangeView.xaml
    /// </summary>
    public partial class ExchangeView : Page
    {

        private readonly Exchange_ViewModel viewModel;

        public ExchangeView()
        {
            InitializeComponent();

            viewModel = new Exchange_ViewModel();

            DataContext = viewModel;
            viewModel.Initialize();



        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            int firstCurrencyIndex = FirstCurrencyCombo.SelectedIndex;
            int secondCurrencyIndex = SecondCurrencyCombo.SelectedIndex;

            if (firstCurrencyIndex == -1 || secondCurrencyIndex == -1)
            {
                MessageBox.Show("Sellect both currencies, please");
                return;
            }

            string amount = AmountTextBox.Text;
            float amount_fl;
            
            float.TryParse(amount, out amount_fl);
            
            if (amount_fl == 0)
            {
                float.TryParse(amount, NumberStyles.Any, new CultureInfo("en-en"), out amount_fl);
            }
            
            if (amount_fl == 0 && amount != "0")
            {
                MessageBox.Show("Enter number in text field, please");
                return;
            }

            float firstCurrencyPrice, secondCurrencyPrice;

            float.TryParse(viewModel.SortedcurrencyRateList[firstCurrencyIndex].RateUsd, NumberStyles.Any, new CultureInfo("en-en"), out firstCurrencyPrice);
            float.TryParse(viewModel.SortedcurrencyRateList[secondCurrencyIndex].RateUsd, NumberStyles.Any, new CultureInfo("en-en"), out secondCurrencyPrice);

            if (secondCurrencyPrice == 0)
            {
                MessageBox.Show("Invalid cross-course received from server, sorry...");
                return;
            }
            
            float result = amount_fl * firstCurrencyPrice / secondCurrencyPrice;

            RezultLabel.Text = result.ToString();

        }
    }
}
