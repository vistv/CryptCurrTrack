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
            var item = ((FrameworkElement)e.OriginalSource).DataContext as MainWindow_Model;
            if (item != null)
            {
                MessageBox.Show("Item's Double Click handled!");
            }
        }
    }
}
