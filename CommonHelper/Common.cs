using Newtonsoft.Json.Linq;

namespace CommonHelper
{
    public class Common
    {
        public static string BaseCurrencyAPI => System.Configuration.ConfigurationManager.AppSettings["BaseCurrencyAPI"];
        public static string DefaultBaseCurrency => System.Configuration.ConfigurationManager.AppSettings["DefaultBaseCurrency"];
        public static string CurrencyFullFormAPI => System.Configuration.ConfigurationManager.AppSettings["CurrencyFullFormAPI"];
        public static string NewsFeedAPI => System.Configuration.ConfigurationManager.AppSettings["NewsFeedAPI"];
        public static string NewsCategory => System.Configuration.ConfigurationManager.AppSettings["NewsCategory"];
        public static Dictionary<string, string> CountryCodeDictionary
        {
            get
            {
                var countryCode = System.Configuration.ConfigurationManager.AppSettings["CountryCode"];
                var jObject = JObject.Parse(countryCode);
                var countryCodeDict = jObject.ToObject<Dictionary<string, string>>();
                return countryCodeDict;
            }
        }
        public static string DefaultNewsCategory => System.Configuration.ConfigurationManager.AppSettings["DefaultNewsCategory"];
        public static string DefaultCountryToFetchNews => System.Configuration.ConfigurationManager.AppSettings["DefaultCountryToFetchNews"];
    }
}