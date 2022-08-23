using CryptCurrTrack.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace CryptCurrTrack.ViewModel
{
    class Exchange_ViewModel
    {
        private CurrencyRateList currencyRateList;

        private readonly List<CurrencyRate> sortedcurrencyRateList;

        private readonly ExchangeModel exchangeModel;

        public Exchange_ViewModel()
        {
            sortedcurrencyRateList = new List<CurrencyRate>();

            exchangeModel = new ExchangeModel();
        }

  
        public List<CurrencyRate> SortedcurrencyRateList
        {
            get { return sortedcurrencyRateList; }
        }
        public ObservableCollection<CurrencySymbol> CurrencySymbols
        {
            get { return exchangeModel.CurrencySymbols; }
        }

        public async void Initialize()
        {
            

            await HttpInfor.GetHttpData("https://api.coincap.io/v2/rates/");

            if (HttpInfor.responseBody.Contains("Exception Caught!"))
            {
                return;
            }

            currencyRateList = JsonConvert.DeserializeObject<CurrencyRateList>(HttpInfor.responseBody);

            FillSortedCurrencyRateList();

            for (int i = 0; i < sortedcurrencyRateList.Count; ++i)
            {
                exchangeModel.CurrencySymbols.Add(new CurrencySymbol { Symbol = sortedcurrencyRateList[i].Symbol });
            }


        }

        private void FillSortedCurrencyRateList()
        {
            int count = currencyRateList.CurrencyRate.Count;
            if (count == 0) return;

            string maxString;
            int indexOfMax;


            while (currencyRateList.CurrencyRate.Count > 0)
            { 
                maxString = currencyRateList.CurrencyRate[0].Symbol;
                indexOfMax = 0;

                for (int i = 1; i < currencyRateList.CurrencyRate.Count; ++i)
                {
                    if (string.Compare(maxString, currencyRateList.CurrencyRate[i].Symbol) > 0)
                    {
                        maxString = currencyRateList.CurrencyRate[i].Symbol;
                        indexOfMax = i;
                    }
                }
                sortedcurrencyRateList.Add(currencyRateList.CurrencyRate[indexOfMax]);
                currencyRateList.CurrencyRate.RemoveAt(indexOfMax);
            }
        }
    }
}
