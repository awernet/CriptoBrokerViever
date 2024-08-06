using CriptoBrokerViewer.JsonClasses;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace CriptoBrokerViewer.Api
{
    public sealed class MexcApiSpotV2
    {
        private string _apiKey = "mx0vglknwYWLfNlZ4O";
        public async Task<List<Candle>> MarketKline(string symbol, string interval = "1d", string start_time = "", int limit = 1000)
        {
            List<Candle> historicalDayData = new List<Candle>();

            try
            {
                using (var client = new HttpClient())
                {
                    client.DefaultRequestHeaders.Add("apiKey", _apiKey);
                    string response = await client.GetStringAsync($"https://www.mexc.com/open/api/v3/market/klinesapi/v2/market/kline?symbol={symbol}&interval={interval}&start_time={start_time}&limit={limit}");

                    HistoricalDataTemplate historicalTemplate = JsonConvert.DeserializeObject<HistoricalDataTemplate>(response);

                    foreach (var history in historicalTemplate.data)
                        historicalDayData.Add(new Candle(history));
                }
            }
            catch (Exception ex) { Console.WriteLine(ex.ToString()); }

            return historicalDayData;
        }

        public async Task<Ticker> MarketTicker(string symbol)
        {
            Ticker tickers = new Ticker();
            try
            {
                using (var client = new HttpClient())
                {
                    var response = await client.GetAsync($"https://api.mexc.com/api/v3/ticker/24hr?symbol={symbol}");

                    HttpStatusCode StatusCode = response.StatusCode;

                    if (!(StatusCode == HttpStatusCode.OK))
                        return tickers;

                    string data = await client.GetStringAsync($"https://www.mexc.com/open/api/v2/market/ticker?symbol={symbol}");

                    MarketTickerTemplate marketTickets = JsonConvert.DeserializeObject<MarketTickerTemplate>(data);
                    foreach (var marketTicker in marketTickets.data)
                    {
                        tickers.change_rate = marketTicker.change_rate;
                    }
                }
            }
            catch (Exception ex) { Console.WriteLine(ex.ToString()); }

            return tickers;
        }

    }
}
