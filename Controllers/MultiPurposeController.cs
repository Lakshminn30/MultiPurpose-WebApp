using APIHelperModule;
using CurrencyConverterHelper;
using CurrencyConverterHelper.Model;
using Microsoft.AspNetCore.Mvc;
using MultiPurpose_WebApp.Models;
using NewsFeederHelper;
using System.Diagnostics;

namespace MultiPurpose_WebApp.Controllers
{
    public class MultiPurposeController : Controller
    {
        private readonly ILogger<MultiPurposeController> _logger;
        private readonly IAPIHelper _apiHelper;
        private readonly CurrencyConverter _currencyConverter;
        private readonly NewsFeeder _newsFeeder;
        public MultiPurposeController(ILogger<MultiPurposeController> logger, IAPIHelper APIHelper, CurrencyConverter currencyConverter, NewsFeeder newsFeeder)
        {
            _logger = logger;
            _apiHelper = APIHelper;
            _currencyConverter = currencyConverter;
            _newsFeeder = newsFeeder;
        }

        public async Task<IActionResult> Index()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> CurrencyConvertor()
        {
            var allCurrencyCode = await _currencyConverter.GetAllCurrencyCode();
            var currencyFullForm = await _currencyConverter.GetCurrencyFullForm();
            var fromCurrencyToCurrency = new FromCurrencyToCurrency()
            {
                AllCurrencyCode = allCurrencyCode,
                CurrencyFullFrom = currencyFullForm
            };

            return View(fromCurrencyToCurrency);
        }

        [HttpPost]
        public async Task<JsonResult> CurrenciesForBaseCurrency(string currencyCode)
        {
            var _baseCurrency = await _currencyConverter.GetCurrenciesForBaseCurrency(currencyCode);
            return new JsonResult( new { baseCurrency = _baseCurrency });
        }

        [HttpGet]
        public async Task<IActionResult> NewsFeed()
        {
            var newsFeedViewModel = await _newsFeeder.GetNewsFeedViewModel();
            return View(newsFeedViewModel);
        }

        [HttpPost]
        public async Task<JsonResult> NewsFeedForGivenCategoryAndCountry(string category, string country)
        {
            var _newsFeed = await _newsFeeder.GetNewsFeedBasedOnCategoryAndCountry(category, country);
            return new JsonResult(new { newsFeed = _newsFeed });
        }
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}