using APIHelperModule;
using CommonHelper;
using NewsFeederHelper.Model;
using Newtonsoft.Json.Linq;
using System.Text.RegularExpressions;
using static System.Net.Mime.MediaTypeNames;

namespace NewsFeederHelper
{
    public class NewsFeeder
    {
        private readonly IAPIHelper _apiHelper;
        public NewsFeeder(IAPIHelper apiHelper)
        {
            _apiHelper = apiHelper;
        }
        public async Task<List<string>> GetAllNewsCategory()
        {
            return Common.NewsCategory.Split(',').ToList();
        }
        public async Task<List<string>> GetAllCoutries()
        {
            return Common.CountryCodeDictionary.Keys.ToList();
        }

        public static string StripTagsRegex(string source)
        {
            
            source = Regex.Replace(source, @"\[[^\]]*\]", string.Empty);
            return Regex.Replace(source, "<.*?>", string.Empty);
        }
        public async Task<NewsResponseModel> GetNewsFeedBasedOnCategoryAndCountry(string category, string country)
        {

            var newsFeedResponse = (JObject) await _apiHelper.ExecuteAPI(string.Format(Common.NewsFeedAPI, category.ToLower(), Common.CountryCodeDictionary[country]));
            var newsFeedResponseObject = newsFeedResponse.ToObject<NewsResponseModel>();
            newsFeedResponseObject.Articles = newsFeedResponseObject.Articles?.Where(x => x != null && !string.IsNullOrEmpty(x.Content)).ToList();

            foreach (var article in  newsFeedResponseObject.Articles)
            {
                if (article != null && article.Content != null)
                {
                    article.Content = StripTagsRegex(article.Content);
                }
            }
            return newsFeedResponseObject;
        }

        public async Task<NewsFeedViewModel> GetNewsFeedViewModel()
        {
           return new NewsFeedViewModel
           {
                NewsCategories = await GetAllNewsCategory(),
                Countries = await GetAllCoutries(),
                NewsCategory = Common.DefaultNewsCategory,
                Country = Common.DefaultCountryToFetchNews
           };
        }


    }
}