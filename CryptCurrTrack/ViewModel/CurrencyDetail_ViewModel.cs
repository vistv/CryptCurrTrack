using System;
using System.Collections.Generic;
using System.Text;

namespace CryptCurrTrack.ViewModel
{
    class CurrencyDetail_ViewModel
    {
        private string _currencyId;
        public CurrencyDetail_ViewModel(string currencyId)
        {
            _currencyId = currencyId;
        }


        public void Initialize() //async
        {
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
