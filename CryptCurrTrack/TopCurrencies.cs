﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;



namespace CryptCurrTrack
{
    public class Currency
    {
        [JsonProperty("id")]
        public string Id { get; set; }


        [JsonProperty("rank")]
        public string Rank { get; set; }


        [JsonProperty("symbol")]
        public string Symbol { get; set; }


        [JsonProperty("name")]
        public string Name { get; set; }


        [JsonProperty("supply")]
        public string Supply { get; set; }


        [JsonProperty("maxSupply")]
        public string MaxSupply { get; set; }


        [JsonProperty("marketCapUsd")]
        public string MarketCapUsd { get; set; }


        [JsonProperty("volumeUsd24Hr")]
        public string VolumeUsd24Hr { get; set; }


        [JsonProperty("priceUsd")]
        public string PriceUsd { get; set; }


        [JsonProperty("changePercent24Hr")]
        public string ChangePercent24Hr { get; set; }


        [JsonProperty("vwap24Hr")]
        public string Vwap24Hr { get; set; }


        [JsonProperty("explorer")]
        public string Explorer { get; set; }

    }

    public class TopCurrenciesList
    {
        [JsonProperty("data")]
        public List<Currency> Currency { get; set; }

        [JsonProperty("timestamp")]
        public string Timestamp { get; set; }
    }

}
