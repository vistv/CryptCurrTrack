using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Text;

namespace CryptCurrTrack.Model
{
    class CurrencyDetail_Model :BaseModel
    {
        private readonly ObservableCollection<CurrencyDetails> _currencyDetails;
        private readonly ObservableCollection<MarketPrices> _markets;
        

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
        public string Name { set; get;}
        public string Price { set; get; }
        public string Volume { set; get; }
        public string PriceChange { set; get; }
    }

    class MarketPrices
    {
        public string Market { set; get; }
        public string Price { set; get; }
    }
}
