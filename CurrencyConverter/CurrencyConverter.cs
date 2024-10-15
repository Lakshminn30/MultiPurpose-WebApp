using APIHelperModule;
using CommonHelper;
using CurrencyConverterHelper.Model;
using Newtonsoft.Json.Linq;

namespace CurrencyConverterHelper
{
    public class CurrencyConverter
    {
        private readonly IAPIHelper _apiHelper;
        public CurrencyConverter(IAPIHelper apiHelper) 
        { 
            _apiHelper = apiHelper;
        }

        private static Dictionary<string, string> currencyFullForm;
        private static List<BaseCurrencyModel> baseCurrencyModels = new List<BaseCurrencyModel>();
        public async Task<BaseCurrencyModel> GetCurrenciesForBaseCurrency(string baseCurrencyCode)
        {
            if (baseCurrencyModels.Any(bc => bc.Base.ToLower().Equals(baseCurrencyCode)))
            {
                return baseCurrencyModels.First(bc => bc.Base.ToLower().Equals(baseCurrencyCode));
            }
            
            var jsonObjectResponse =(JObject) await _apiHelper.ExecuteAPI(string.Format(Common.BaseCurrencyAPI, baseCurrencyCode));
            var responseBaseCurrencyModel = jsonObjectResponse.ToObject<BaseCurrencyModel>();

            if(responseBaseCurrencyModel != null && !baseCurrencyModels.Any(bc => bc.Base.ToLower().Equals(responseBaseCurrencyModel.Base))) baseCurrencyModels.Add(responseBaseCurrencyModel); 
            return responseBaseCurrencyModel;
        }

        public async Task<Dictionary<string, string>> GetCurrencyFullForm()
        {
            if(currencyFullForm == null)
            {
                var responseJsonObject = (JObject) await _apiHelper.ExecuteAPI(Common.CurrencyFullFormAPI);
                currencyFullForm = responseJsonObject.ToObject<Dictionary<string, string>>();
            }
            return currencyFullForm;
        }
        public async Task<List<string>> GetAllCurrencyCode()
        {
            List<string> currencyCode = new List<string>();    

            if(!baseCurrencyModels.Any())
            {
                await GetCurrenciesForBaseCurrency(Common.DefaultBaseCurrency);
            }
            var firstBaseCurrency = baseCurrencyModels.First();
            currencyCode = firstBaseCurrency.Rates.Select(x => x.Key).ToList();

            return currencyCode;
        }
    }
}