using System;
using System.Windows.Input;
using System.ComponentModel;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using CryptCurrTrack.Model;

namespace CryptCurrTrack
{

    class MainWindow_ViewModel
    {
        private IList<MainWindow_Model> _CryptList;
        private TopCurrenciesList topCurr;
        private const int listCount = 20;
        public MainWindow_ViewModel()
        {
            _CryptList = new List<MainWindow_Model> { };

            topCurr = new TopCurrenciesList();
  
            for (int i = 0; i < listCount; i++)
            _CryptList.Add(new MainWindow_Model { Rank = "", Id = "", Name = "" });
        }

        public IList<MainWindow_Model> CryptList
        {
            get { return _CryptList; }
            set { _CryptList = value; }
        }
               
        public async void Initialize()
        {
            await HttpInfor.GetHttpData("https://api.coincap.io/v2/assets?limit=" + listCount.ToString());

            if (HttpInfor.responseBody.Contains("Exception Caught!")) return;

            topCurr = JsonConvert.DeserializeObject<TopCurrenciesList>(HttpInfor.responseBody);

            for (int i = 0; i < listCount; i++)
            {
                _CryptList[i].Rank = topCurr.Currency[i].Rank;
                _CryptList[i].Id = topCurr.Currency[i].Id;
                _CryptList[i].Name = topCurr.Currency[i].Name;
            }
        }
    }
}