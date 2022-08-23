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

            int index = 0;

            for (int i = 0; i < topCurrenciesList.Currency.Count; ++i)
            {
                if (topCurrenciesList.Currency[i].Rank == currencyRank)
                {
                    index = i;
                }
            }


            _currency = topCurrenciesList.Currency[index];
            currencyDetail_Model = new CurrencyDetail_Model();
            
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

            await HttpInfor.GetHttpData("https://api.coincap.io/v2/markets?baseSymbol=" + _currency.Symbol);

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
                    Price = marketPriceList.MarketPrices[i].PriceQuote.Substring(0, 13),
                    Units = marketPriceList.MarketPrices[i].QuoteSymbol
                });
            }
        }
    }
}
