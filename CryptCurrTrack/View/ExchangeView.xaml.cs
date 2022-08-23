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
    }
}
