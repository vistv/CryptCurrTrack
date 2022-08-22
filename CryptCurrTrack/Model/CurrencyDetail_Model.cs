using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Text;

namespace CryptCurrTrack.Model
{
    class CurrencyDetail_Model :BaseModel
    {
        private ObservableCollection<CurrencyDetails> _currencyDetails;
        private ObservableCollection<MarketPrices> _markets;
        

        public CurrencyDetail_Model()
        {
            _currencyDetails = new ObservableCollection<CurrencyDetails>();
            _currencyDetails.CollectionChanged += Details_CollectionChanged;

            _markets = new ObservableCollection<MarketPrices>();
            _markets.CollectionChanged += Markets_CollectionChanged;
        }


        private void Details_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            OnPropertyChange("Details");
        }

        private void Markets_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            OnPropertyChange("Markets");
        }

        public ObservableCollection<CurrencyDetails> Details
        {
            get { return _currencyDetails; }
        }

        public ObservableCollection<MarketPrices> Markets
        {
            get { return _markets; }
        }
    }

    class CurrencyDetails
    {
        public string Name;
        public string Price;
        public string Volume;
        public string PriceChange;
    }

    class MarketPrices
    {
        public string Market;
        public string Price;
    }
}
