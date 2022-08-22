using CryptCurrTrack.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace CryptCurrTrack.ViewModel
{
    class CurrencyDetail_ViewModel
    {
        private Currency _currency;
        private CurrencyDetail_Model currencyDetail_Model;
        public CurrencyDetail_ViewModel(string currencyRank, TopCurrenciesList topCurrenciesList)
        {
            _currency = topCurrenciesList.Currency[int.Parse(currencyRank)-1];
            currencyDetail_Model = new CurrencyDetail_Model();
            Initialize();
        }


        public ObservableCollection<CurrencyDetails> Details
        {
            get {return currencyDetail_Model.Details;}
            //set { currencyDetail_Model.Details = value; }
        }


        
    


public ObservableCollection<MarketPrices> Markets
        {
            get
            {
                return currencyDetail_Model.Markets;
            }
        }

        public void Initialize() //async
        {
            currencyDetail_Model.Details.Add(new CurrencyDetails {Name = _currency.Name, Price = _currency.PriceUsd, PriceChange = _currency.Symbol, Volume = _currency.VolumeUsd24Hr });




            //await HttpInfor.GetHttpData("https://api.coincap.io/v2/assets?limit=" + listCount.ToString());

            //if (HttpInfor.responseBody.Contains("Exception Caught!")) return;

            //topCurr = JsonConvert.DeserializeObject<TopCurrenciesList>(HttpInfor.responseBody);

            //for (int i = 0; i < listCount; i++)
            //{
            //    _CryptList[i].Rank = topCurr.Currency[i].Rank;
            //    _CryptList[i].Id = topCurr.Currency[i].Id;
            //    _CryptList[i].Name = topCurr.Currency[i].Name;
            //}
        }
    }
}
