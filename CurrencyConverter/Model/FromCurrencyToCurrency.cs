using System.ComponentModel;

namespace CurrencyConverterHelper.Model
{
    public class FromCurrencyToCurrency
    {
        public List<string> AllCurrencyCode { get; set; }

        [DisplayName("From Currency")]
        public string FromCurrencyCode { get; set; }

        [DisplayName("To Currency")]
        public string ToCurrencyCode { get; set;}
        public Dictionary<string, string> CurrencyFullFrom { get; set; }
    }
}
