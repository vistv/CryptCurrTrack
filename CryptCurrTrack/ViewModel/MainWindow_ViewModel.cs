using System;
using System.Windows.Input;
using System.ComponentModel;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using CryptCurrTrack.Model;
using System.Collections.ObjectModel;

namespace CryptCurrTrack
{

    class MainWindow_ViewModel
    {
        private readonly MainWindow_Model mainWindow_Model;

    
        private TopCurrenciesList topCurr;
        private const int listCount = 100;
        
        public TopCurrenciesList GetTopCurrenciesList()
        {
            return topCurr;
        }

        public MainWindow_ViewModel()
        {
            mainWindow_Model = new MainWindow_Model();
 
            topCurr = new TopCurrenciesList();
        }

        public ObservableCollection<CurrencyShortDetails> CurrencyShortDetail
        {
            get { return mainWindow_Model.ShortDetails; }
      
        }


        public async void Initialize()
        {
            await HttpInfor.GetHttpData("https://api.coincap.io/v2/assets?limit=" + listCount.ToString());

            if (HttpInfor.responseBody.Contains("Exception Caught!")) return;

            topCurr = JsonConvert.DeserializeObject<TopCurrenciesList>(HttpInfor.responseBody);

            for (int i = 0; i < topCurr.Currency.Count; ++i)
            {
                mainWindow_Model.ShortDetails.Add(new CurrencyShortDetails
                {
                    Name = topCurr.Currency[i].Name,
                    Id = topCurr.Currency[i].Id,
                    Rank = topCurr.Currency[i].Rank
                });
            }
        }

        public async void Search(string query)
        {
            await HttpInfor.GetHttpData("https://api.coincap.io/v2/assets?search=" + query);

            if (HttpInfor.responseBody.Contains("Exception Caught!")) return;

            topCurr = JsonConvert.DeserializeObject<TopCurrenciesList>(HttpInfor.responseBody);

        }
    }
}