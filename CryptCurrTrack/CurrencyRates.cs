using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace CryptCurrTrack
{
    public class CurrencyRate
    {
        [JsonProperty("id")]
        public string Id { get; set; }


        [JsonProperty("symbol")]
        public string Symbol { get; set; }


        [JsonProperty("currencySymbol")]
        public string CurrencySymbol { get; set; }


        [JsonProperty("type")]
        public string Type { get; set; }


        [JsonProperty("rateUsd")]
        public string RateUsd { get; set; }

    }

    public class CurrencyRateList
    {
        [JsonProperty("data")]
        public List<CurrencyRate> CurrencyRate { get; set; }

        [JsonProperty("timestamp")]
        public string Timestamp { get; set; }
    }

}
