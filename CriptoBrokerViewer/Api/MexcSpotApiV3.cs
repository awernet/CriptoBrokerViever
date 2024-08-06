using CriptoBrokerViewer.JsonClasses;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace CriptoBrokerViewer.Api
{
    public sealed class MexcSpotApiV3
    {
        private string _apiSecretKey = "37495c9dfbe84278afabdd95f31c7a4b";
        private string _apiKey = "mx0vglknwYWLfNlZ4O";
        public async Task<Ticker24h> Klines(string symbol)
        {
            try
            {
                using (var client = new HttpClient())
                {
                    client.DefaultRequestHeaders.Add("apiKey", _apiKey);
                    var response = await client.GetAsync($"https://api.mexc.com/api/v3/ticker/24hr?symbol={symbol}");

                    HttpStatusCode StatusCode = response.StatusCode;

                    if (!(StatusCode == HttpStatusCode.OK))
                        return new Ticker24h();

                    string data = await response.Content.ReadAsStringAsync();
                    Ticker24h ticker24h = JsonConvert.DeserializeObject<Ticker24h>(data);
                    return ticker24h;
                }
            }
            catch (Exception ex) { Console.WriteLine(ex.ToString()); }
            return new Ticker24h();
        }
        public async Task<Order> NewOrder(string symbol, string side = "SELL", string type = "MARKET")
        {
            try
            {
                using (var client = new HttpClient())
                {
                    client.DefaultRequestHeaders.Add("apiKey", _apiKey);
                    var response = await client.GetAsync($"https://api.mexc.com//api/v3/order?symbol={symbol}&side={side}&type={type}");

                    HttpStatusCode StatusCode = response.StatusCode;

                    if (!(StatusCode == HttpStatusCode.OK))
                        return new Order();

                    string data = await response.Content.ReadAsStringAsync();
                    Order order = JsonConvert.DeserializeObject<Order>(data);
                    return order;
                }
            }
            catch (Exception ex) { Console.WriteLine(ex.ToString()); }
            return new Order();

        }
    }

    

    public class Order
    {
        public string symbol { get; set; }
        public long orderId { get; set; }
        public int orderListId { get; set; }
        public decimal price { get; set; }
        public int origQty { get; set; }
        public string type { get; set; }
        public string side { get; set; }
        public long transactTime { get; set; }
    }
        public class Ticker24h
        {
            public string symbol { get; set; }
            public decimal priceChange { get; set; }
            public decimal priceChangePercent { get; set; }
            public decimal prevClosePrice { get; set; }
            public string lastPrice { get; set; }
            public string bidPrice { get; set; }
            public string bidQty { get; set; }
            public string askPrice { get; set; }
            public string askQty { get; set; }
            public string openPrice { get; set; }
            public string highPrice { get; set; }
            public string lowPrice { get; set; }
            public string volume { get; set; }
            public object quoteVolume { get; set; }
            public long openTime { get; set; }
            public long closeTime { get; set; }
            public object count { get; set; }
        }
}
