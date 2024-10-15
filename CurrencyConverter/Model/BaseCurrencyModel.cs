using Newtonsoft.Json;

namespace CurrencyConverterHelper.Model
{
    public class BaseCurrencyModel
    {
        [JsonProperty("provider")]
        public string Provider { get; set; }

        [JsonProperty("terms")]
        public string Terms { get; set; }

        [JsonProperty("base")]
        public string Base { get; set; }

        [JsonProperty("date")]
        public string Date { get; set; }

        [JsonProperty("rates")]
        public Dictionary<string, float> Rates { get; set; }
    }
}
