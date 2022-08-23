using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Text;

namespace CryptCurrTrack.Model
{
    class ExchangeModel : BaseModel
    {
        private readonly ObservableCollection<CurrencySymbol> _currencySymbols;

        public ExchangeModel()
        {
            _currencySymbols = new ObservableCollection<CurrencySymbol>();
            _currencySymbols.CollectionChanged += CurrencySymbolChanged;

        }
        private void CurrencySymbolChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            OnPropertyChange("Details");
        }

        public ObservableCollection<CurrencySymbol> CurrencySymbols
        {
            get { return _currencySymbols; }
        }

    }


    class CurrencySymbol
    {
        public string Symbol { set; get; }
    }

    
}
