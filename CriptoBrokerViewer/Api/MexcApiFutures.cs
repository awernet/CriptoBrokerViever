using CriptoBrokerViewer.JsonClasses;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace CriptoBrokerViewer.Api
{
    public class MexcApiFutures
    {
        private string _apiKey = "mx0vglknwYWLfNlZ4O";
        public async Task<List<Candle>> ContractKline(string symbol, string interval = "Min15", string start = "", string end = "")
        {
            List<Candle> candles = new List<Candle>();

            try
            {
                using (var client = new HttpClient())
                {
                    client.DefaultRequestHeaders.Add("apiKey", _apiKey);
                    var response = await client.GetAsync($"https://contract.mexc.com/api/v1/contract/kline/{symbol}?interval={interval}&start={start}&end={end}");

                    HttpStatusCode StatusCode = response.StatusCode;

                    if (!(StatusCode == HttpStatusCode.OK))
                        return candles;

                    string data = await response.Content.ReadAsStringAsync();
                    //string response = await client.GetStringAsync($"https://contract.mexc.com/api/v1/contract/kline/{symbol}?interval={interval}&start={start}&end={end}");

                    FutureResponse<Klines> klines = JsonConvert.DeserializeObject<FutureResponse<Klines>>(data);

                    for (int i = 0; i < klines.data.time.Count; i++)
                    {
                        candles.Add(new Candle() {
                            time = klines.data.time[i],
                            open = klines.data.open[i],
                            close = klines.data.close[i],
                            high = klines.data.high[i],
                            low = klines.data.low[i],
                            vol = klines.data.vol[i],
                            amount = klines.data.amount[i]
                        });
                    }
                }
            }
            catch (Exception ex) { Console.WriteLine(ex.ToString()); }

            return candles;
        }

        public async Task<List<ContractDetail>> ContractDetail(string symbol = "")
        {       
            using (var client = new HttpClient())
            {
                string response = await client.GetStringAsync($"https://contract.mexc.com/api/v1/contract/detail?symbol={symbol}");
                FutureResponse<List<ContractDetail>> contractTemplate = JsonConvert.DeserializeObject<FutureResponse<List<ContractDetail>>>(response);

                return contractTemplate.data;
            }
        }

        public async Task<ContractTicker> ContractTicker(string symbol = "")
        {
            Console.WriteLine(symbol);
            using (var client = new HttpClient())
            {
                
                string response = await client.GetStringAsync($"https://contract.mexc.com/api/v1/contract/ticker?symbol={symbol}");
                FutureResponse<ContractTicker> contractTemplate = JsonConvert.DeserializeObject<FutureResponse<ContractTicker>>(response);

                return contractTemplate.data;
            }
        }
    }
}
