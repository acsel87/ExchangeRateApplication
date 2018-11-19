using ER_Library.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace ER_Library.Helpers
{
    public class ApiHelper
    {
        public static List<CurrencyModel> GetCurrency()
        {
            using (WebClient webClient = new WebClient())
            {
                List<CurrencyModel> currency = new List<CurrencyModel>();

                webClient.BaseAddress = GlobalConfig.GetAppConfig("BaseAddress");

                NameValueCollection query = new NameValueCollection();               
                webClient.Headers.Clear();
                webClient.Headers.Add(HttpRequestHeader.ContentType, "application/json");
                webClient.Encoding = System.Text.Encoding.UTF8;

                string response = webClient.DownloadString("");

                currency = JsonConvert.DeserializeObject<List<CurrencyModel>>(response);

                return currency;
            }
        }

        public static List<KeyValuePair<DateTime, decimal>> GetRates(DateTime _startDate, DateTime _endDate, int currency_id, int skipValue)
        {
            using (WebClient webClient = new WebClient())
            {
                List<KeyValuePair<DateTime, decimal>> rates = new List<KeyValuePair<DateTime, decimal>>();

                string startDate = _startDate.ToShortDateString();
                string endDate = _endDate.ToShortDateString();             

                webClient.BaseAddress = GlobalConfig.GetAppConfig("BaseAddress");

                NameValueCollection query = new NameValueCollection();
                query["startDate"] = startDate;
                query["endDate"] = endDate;
                query["currency_id"] = currency_id.ToString();
                query["skipValue"] = skipValue.ToString();
                webClient.QueryString.Add(query);
                webClient.Headers.Clear();
                webClient.Headers.Add(HttpRequestHeader.ContentType, "application/json");

                string response = webClient.DownloadString("");

                rates = JsonConvert.DeserializeObject<List<KeyValuePair<DateTime, decimal>>>(response);

                return rates;
            }
        }
    }
}
