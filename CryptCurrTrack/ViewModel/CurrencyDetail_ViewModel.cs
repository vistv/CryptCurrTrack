using CryptCurrTrack.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace CryptCurrTrack.ViewModel
{
    class CurrencyDetail_ViewModel
    {
        private readonly Currency _currency;
        private readonly CurrencyDetail_Model currencyDetail_Model;
        private MarketPriceList marketPriceList;
        public CurrencyDetail_ViewModel(string currencyRank, TopCurrenciesList topCurrenciesList)
        {
            _currency = topCurrenciesList.Currency[int.Parse(currencyRank)-1];
            currencyDetail_Model = new CurrencyDetail_Model();
            //Initialize();
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

        public async void Initialize() //async
        {
            currencyDetail_Model.Details.Add(new CurrencyDetails
            {
                Name = _currency.Name,
                Price = _currency.PriceUsd.Substring(0, 13),
                PriceChange = _currency.ChangePercent24Hr.Substring(0, 13),
                Volume = _currency.VolumeUsd24Hr.Substring(0,13) });

            await HttpInfor.GetHttpData("https://api.coincap.io/v2/markets?quoteSymbol=USD&baseSymbol=" + _currency.Symbol);

            if (HttpInfor.responseBody.Contains("Exception Caught!"))
            {
                return;
            }

            marketPriceList = JsonConvert.DeserializeObject<MarketPriceList>(HttpInfor.responseBody);

            for (int i = 0; i < marketPriceList.MarketPrices.Count; ++i)
            {
                currencyDetail_Model.Markets.Add(new MarketPrices
                {
                    Market = marketPriceList.MarketPrices[i].ExchangeId,
                    Price = marketPriceList.MarketPrices[i].PriceUsd.Substring(0, 13)
                });
            }
        }
    }
}
