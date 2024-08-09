using Loger;
using MexcApi.Entities;
using MexcApi.Responses;
using MexcApi.Responses.Futures;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace MexcApi.Api
{
    public class FuturesApi
    {
        public FuturesApi() => _httpClient = new HttpClient();

        private string _apiKey = "mx0vglknwYWLfNlZ4O";
        private HttpClient _httpClient;
        private string _endPoint = "https://contract.mexc.com/api/v1/";

        public async Task<List<Candle>> ContractKline(string symbol, string interval = "Min15", string start = "", string end = "") 
        {
            List<Candle> candles = new List<Candle>();
            try
            {
                //_httpClient.DefaultRequestHeaders.Add("apiKey", _apiKey);
                var response = await _httpClient.GetAsync($"{_endPoint}contract/kline/{symbol}?interval={interval}&start={start}&end={end}");

                HttpStatusCode StatusCode = response.StatusCode;

                if (!(StatusCode == HttpStatusCode.OK))
                    return candles;

                string data = await response.Content.ReadAsStringAsync();

                ApiResponse<FuturesKlinesApiResponse> klines = JsonConvert.DeserializeObject<ApiResponse<FuturesKlinesApiResponse>>(data);

                for (int i = 0; i < klines.data.time.Count; i++)
                {
                    candles.Add(new Candle()
                    {
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
            catch (Exception ex)
            {
                LogVisualisator.Log(Loger.Enums.LogType.Error, ex.Message);
            }

            return candles;
        }

        public async Task<List<FuturesContractDetail>> ContractDetail(string symbol = "")
        {
            var response = await _httpClient.GetAsync($"{_endPoint}contract/detail?symbol={symbol}");

            string data = await response.Content.ReadAsStringAsync();

            ApiResponse<List<FuturesContractDetail>> contractsDetail = JsonConvert.DeserializeObject<ApiResponse<List<FuturesContractDetail>>>(data);

            return contractsDetail.data;          
        }

        public async Task<FuturesContractTicker> ContractTicker(string symbol = "")
        {
            var response = await _httpClient.GetAsync($"{_endPoint}contract/ticker?symbol={symbol}");

            string data = await response.Content.ReadAsStringAsync();

            ApiResponse<FuturesContractTicker> contractsTicker = JsonConvert.DeserializeObject<ApiResponse<FuturesContractTicker>>(data);

            return contractsTicker.data;
        }
    }
}
