using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Net.Http.Json;
using System.Text.Json.Serialization;

namespace APIHelperModule
{
    public class APIHelper : IAPIHelper
    {
        private readonly HttpClient _httpClient;

        public APIHelper(HttpClient httpClient)z    
        {
            _httpClient = httpClient;
        }
        public async Task<dynamic> ExecuteAPI(string api)
        {
            var response = await _httpClient.GetAsync(api);
            var data = await response?.Content?.ReadAsStringAsync();
            var jObject = JObject.Parse(data);

            return jObject;
        }
    }
}