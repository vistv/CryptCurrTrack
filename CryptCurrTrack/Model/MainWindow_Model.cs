using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Text;


namespace CryptCurrTrack.Model
{

    sealed class MainWindow_Model : BaseModel 
    {
        private readonly ObservableCollection<CurrencyShortDetails> _currencyShortDetails;

        private string query = "USD";

        public string Query
        {
            get { return query; }
            set
            {
                if (query != value)
                {
                    query = value;
                    OnPropertyChange("Query");
                }
            }
        }


        public MainWindow_Model()
        {
            _currencyShortDetails = new ObservableCollection<CurrencyShortDetails>();
            _currencyShortDetails.CollectionChanged += ShortDetails_CollectionChanged;

        }

        private void ShortDetails_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            OnPropertyChange("Details");
        }

        public ObservableCollection<CurrencyShortDetails> ShortDetails
        {
            get { return _currencyShortDetails; }
        }

    }
}

class CurrencyShortDetails
{
    public string Name { set; get; }
    public string Id { set; get; }
    public string Rank { set; get; }
 
}